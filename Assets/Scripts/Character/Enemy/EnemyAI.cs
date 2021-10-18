using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script;
using MoonSharp.Interpreter;

namespace Character.Enemy
{
    /// <summary>
    /// AI
    /// </summary>
    [MoonSharpUserData]
    public class EnemyAI : MonoBehaviour
    {
        /// <summary>
        /// スクリプト実行オブジェクト
        /// </summary>
        private ScriptExecutor script = new ScriptExecutor();

        /// <summary>
        /// スクリプトが格納されたディレクトリ
        /// </summary>
        private static readonly string scriptDirectory = "Resources/Scripts/EnemyAI/";

        void Awake()
        {
            script.SetObject("AI", this);
        }

        /// <summary>
        /// スクリプトの読み込み
        /// </summary>
        /// <param name="scriptName">スクリプト名</param>
        public void Load(string scriptName)
        {
            script.Load(scriptDirectory + scriptName);
        }

        /// <summary>
        /// 実行
        /// /// </summary>
        public void Execute()
        {
            script.Execute();
        }

        void Update()
        {
            if (script.IsFinished)
            {
                // 終了したら最初からやり直す
                script.Execute();
            }
        }
    }
}
