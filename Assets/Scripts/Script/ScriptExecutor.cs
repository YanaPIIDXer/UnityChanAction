﻿using System;
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
        /// コルーチン
        /// </summary>
        private DynValue coroutine = null;

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
        public void Execute(string filePath)
        {
            var textAsset = Resources.Load<TextAsset>(filePath);
            var sourceLines = textAsset.text.Split('\n');
            var source = "";
            foreach (var l in sourceLines)
            {
                var line = l.Replace("\t", "").Replace(" ", "");        // コメントアウトの判定が面倒なのでインデントは消す
                source += line;
                foreach (var method in yieldMethods)
                {
                    if (line.Contains(method) && line.IndexOf("#") != 0 && line.IndexOf("--") != 0)
                    {
                        source += "\ncoroutine.yield()";
                        break;
                    }
                }
            }

            DynValue function = scriptInterpreter.DoString(source);
            coroutine = scriptInterpreter.CreateCoroutine(function);
        }

        /// <summary>
        /// レジューム
        /// </summary>
        public void Resume()
        {
            if (coroutine.Coroutine.State != CoroutineState.Dead)
            {
                coroutine.Coroutine.Resume();
            }
        }
    }
}
