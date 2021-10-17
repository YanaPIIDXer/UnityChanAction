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
    /// スクリプト実行クラス
    /// </summary>
    public class ScriptExecutor
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
    }
}
