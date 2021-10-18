using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script;
using MoonSharp.Interpreter;
using Cysharp.Threading.Tasks;

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
        private static readonly string scriptDirectory = "Scripts/EnemyAI/";

        #region Script Methods

        /// <summary>
        /// ログ出力＆Yieldテスト
        /// </summary>
        /// <param name="message">メッセージ</param>
        [Yield]
        public async void LogTest(string message)
        {
            Debug.Log(message);
            await UniTask.Delay(1500);
            Resume();
        }

        #endregion

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

        /// <summary>
        /// レジューム
        /// </summary>
        public void Resume()
        {
            script.Resume();
        }

        void Awake()
        {
            script.SetObject("AI", this);
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
