using Core.Infrastructure;
using Core.Level;

namespace Core.Player
{
    public class CubeDetectionHandler
    {
        private readonly PlayerStorage _playerStorage;
        private readonly CubeContainer _cubeContainer;
        
        public CubeDetectionHandler(PlayerStorage playerStorage, CubeContainer cubeContainer)
        {
            _playerStorage = playerStorage;
            _cubeContainer = cubeContainer;
        }

        public void OnCubeViewDetected(CubeView view)
        {
            if(!_cubeContainer.TryGetCubeByView(view, out var cube) || !cube.IsCollectible)
                return;

            _playerStorage.TryAdd(cube);
        }
    }
}