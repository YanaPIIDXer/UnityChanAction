using UnityEngine;
using Zenject;
using Character.Player;

namespace ControlInput
{
    public class PlayerControlInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IPlayerControl>()
                     .To<PlayerControl>()
                     .FromNewComponentOnNewGameObject()
                     .AsCached();
        }
    }
}
