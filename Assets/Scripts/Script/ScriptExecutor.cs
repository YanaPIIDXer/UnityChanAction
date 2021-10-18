using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoonSharp.Interpreter;

namespace Script
{
    /// <summary>
    /// yieldするメソッドに付けるAttribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class YieldAttribute : Attribute { }

    /// <summary>
    /// スクリプトレジュームインタフェース
    /// </summary>
    public interface IScriptResume
    {
        /// <summary>
        /// レジューム
        /// </summary>
        void Resume();
    }

    /// <summary>
    /// スクリプト実行クラス
    /// </summary>
    public class ScriptExecutor : IScriptResume
    {
        /// <summary>
        /// スクリプトインタプリタ
        /// </summary>
        private MoonSharp.Interpreter.Script scriptInterpreter = new MoonSharp.Interpreter.Script();

        /// <summary>
        /// 登録されている型
        /// </summary>
        /// <typeparam name="Type"></typeparam>
        /// <returns></returns>
        private HashSet<Type> typeHashSet = new HashSet<Type>();

        /// <summary>
        /// Yieldさせるメソッドリスト
        /// </summary>
        private HashSet<string> yieldMethods = new HashSet<string>();

        /// <summary>
        /// 読み込んだ関数
        /// </summary>
        private DynValue function = null;

        /// <summary>
        /// コルーチン
        /// </summary>
        private DynValue coroutine = null;

        /// <summary>
        /// 終了しているか？
        /// </summary>
        /// <returns></returns>
        public bool IsFinished => (coroutine != null && coroutine.Coroutine.State == CoroutineState.Dead);

        /// <summary>
        /// オブジェクトを設定
        /// </summary>
        /// <param name="name">オブジェクト名</param>
        /// <param name="obj">オブジェクトの実体</param>
        public void SetObject(string name, object obj)
        {
            Type type = obj.GetType();
            if (typeHashSet.Add(type))
            {
                UserData.RegisterAssembly(type.Assembly);
                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    if (method.GetCustomAttributes(typeof(YieldAttribute), true) != null)
                    {
                        yieldMethods.Add(method.Name);
                    }
                }
            }
            scriptInterpreter.Globals[name] = obj;
        }

        /// <summary>
        /// 実行
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        public void Load(string filePath)
        {
            var textAsset = Resources.Load<TextAsset>(filePath);
            if (textAsset == null)
            {
                Debug.LogError(filePath + "is invalid.");
                return;
            }

            var sourceLines = textAsset.text.Split('\n');
            var source = "return funciton()";
            foreach (var l in sourceLines)
            {
                var line = l.Replace("\t", "").Replace(" ", "");        // コメントアウトの判定が面倒なのでインデントは消す
                source += line;
                foreach (var method in yieldMethods)
                {
                    if (line.Contains(method) && line.IndexOf("#") != 0 && line.IndexOf("--") != 0)
                    {
                        // ログ出力などで文字列にメソッド名が仕込まれるケースを考慮
                        // 「"」をセパレータにしてSplitし、その結果の配列のインデックスが偶数のものは「ただの文字列」と見做す
                        var splitedLine = line.Split('"');
                        for (int i = 0; i < splitedLine.Length; i += 2)
                        {
                            if (splitedLine[i].Contains(method))
                            {
                                source += "\ncoroutine.yield()";
                            }
                        }
                        break;
                    }
                }
                source += "\n";
            }
            source += "end";
            function = scriptInterpreter.DoString(source);
        }

        /// <summary>
        /// 実行
        /// </summary>
        public void Execute()
        {
            if (function == null) { throw new Exception("スクリプトがロードされていません"); }
            coroutine = scriptInterpreter.CreateCoroutine(function);
        }

        /// <summary>
        /// レジューム
        /// </summary>
        /// <returns>スクリプトが終了したらfalse</returns>
        public void Resume()
        {
            if (coroutine == null) { throw new Exception("coroutineがnullです。"); }
            if (!IsFinished)
            {
                coroutine.Coroutine.Resume();
            }
        }
    }
}
