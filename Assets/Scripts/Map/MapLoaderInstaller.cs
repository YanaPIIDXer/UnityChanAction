using UnityEngine;
using Zenject;

namespace Map
{
    public class MapLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IMapLoad>()
                     .To<MapLoader>()
                     .FromNewComponentOnNewGameObject()
                     .AsCached();
        }
    }
}
