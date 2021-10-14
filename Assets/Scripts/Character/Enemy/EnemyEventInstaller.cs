using UnityEngine;
using Zenject;

namespace Character.Enemy
{
    public class EnemyEventInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IEnemyEventObserver>()
                     .To<EnemyEvent>()
                     .FromComponentInHierarchy()
                     .AsCached();

            Container.Bind<IEenmyEventObservable>()
                     .To<EnemyEvent>()
                     .FromComponentInHierarchy()
                     .AsCached();
        }
    }
}
