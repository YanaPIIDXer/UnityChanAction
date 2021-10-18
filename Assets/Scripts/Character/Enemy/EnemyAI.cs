using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Script;
using MoonSharp.Interpreter;
using Character.Player;

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

        /// <summary>
        /// ターゲットとなるプレイヤー
        /// </summary>
        /// <value></value>
        public Player.Player TargetPlayer { set; private get; }

        #region Script Methods

        /// <summary>
        /// 近づく
        /// </summary>
        [Yield]
        public void Approach()
        {
            Debug.Log("Approach()");
        }

        /// <summary>
        /// 逃げる
        /// </summary>
        [Yield]
        public void RunAway()
        {
            Debug.Log("RunAway()");
        }

        /// <summary>
        /// ＡＩの切り替え
        /// </summary>
        /// <param name="nextAIScriptName">切り替えるＡＩのスクリプトファイル名</param>
        public void SwitchAI(string nextAIScriptName)
        {
            script.Load(scriptDirectory + nextAIScriptName);
            script.Execute();
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
