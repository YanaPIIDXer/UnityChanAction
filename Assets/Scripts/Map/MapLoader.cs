using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Master;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Map
{
    /// <summary>
    /// マップ読み込みインタフェース
    /// </summary>
    public interface IMapLoad
    {
        /// <summary>
        /// 読み込み開始
        /// </summary>
        IObservable<Unit> BeginLoad { get; }

        /// <summary>
        /// 読み込み完了
        /// </summary>
        IObservable<MapData> OnLoad { get; }
    }

    /// <summary>
    /// マップ読み込みクラス
    /// </summary>
    public class MapLoader : MonoBehaviour, IMapLoad
    {
        /// <summary>
        /// 読み込み開始
        /// </summary>
        public IObservable<Unit> BeginLoad => beginLoadSubject;

        /// <summary>
        /// 読み込み開始Subject
        /// </summary>
        private Subject<Unit> beginLoadSubject = new Subject<Unit>();

        /// <summary>
        /// 読み込み完了
        /// </summary>
        public IObservable<MapData> OnLoad => onLoadSubject;

        /// <summary>
        /// 読み込み完了Subject
        /// </summary>
        private Subject<MapData> onLoadSubject = new Subject<MapData>();

        /// <summary>
        /// 現在読み込まれているファイル名
        /// </summary>
        private string currentFileName = "";

        /// <summary>
        /// 読み込み
        /// </summary>
        /// <param name="mapId">マップＩＤ</param>
        /// <returns></returns>
        public async UniTaskVoid Load(int mapId)
        {
            MapData data = MapMaster.Get(mapId);
            Debug.Assert(data != null, "Invalid MapID:" + mapId);

            beginLoadSubject.OnNext(Unit.Default);
            if (currentFileName != "")
            {
                await SceneManager.UnloadSceneAsync(currentFileName);
            }

            await SceneManager.LoadSceneAsync(data.FileName, LoadSceneMode.Additive);
            onLoadSubject.OnNext(data);
            currentFileName = data.FileName;
        }
    }
}
