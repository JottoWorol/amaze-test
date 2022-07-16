using Core.Animation.Player;
using Core.Camera;
using Core.Infrastructure;
using Core.Joystick;
using Core.Level;
using Core.Player;
using Core.Utils;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameCompositionRoot : MonoInstaller
    {
        [SerializeField] private SceneData _sceneData;
        [SerializeField] private StaticData _staticData;
        [SerializeField] private UISceneData _uiSceneData;
        
        public override void InstallBindings()
        {
            BindInfrastructure();
            
            Container.BindSingle<PlayerSpawner>().NonLazy();
            Container.BindSingle<MoveJoystick>().NonLazy();
            Container.BindSingle<PlayerMove>();
            Container.BindSingle<LevelLoader>();
            Container.BindSingle<DropArea>();
            Container.BindSingle<CameraSetup>();
            Container.BindSingle<PlayerAnimation>();
            Container.BindSingle<CubeSpawn>();
            Container.BindSingle<CubeContainer>();
            Container.BindSingle<CubePool>();
            Container.BindSingle<SmoothMoveUpdate>();
        }

        private void BindInfrastructure()
        {
            Container.BindInstance(_sceneData);
            Container.BindInstance(_staticData);
            Container.BindInstance(_uiSceneData);
        }
        
        
    }
}