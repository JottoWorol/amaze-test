using System;
using Core.Infrastructure;
using Zenject;

namespace Core.Player
{
    public class Player : IInitializable, IDisposable
    {
        private readonly CubeDetectionHandler _cubeDetectionHandler;
        private readonly DropAreaDetectionHandler _dropAreaDetectionHandler;
        private readonly PlayerView _view;

        public Player(PlayerView view, CubeDetectionHandler cubeDetectionHandler,
            DropAreaDetectionHandler dropAreaDetectionHandler)
        {
            _view = view;
            _cubeDetectionHandler = cubeDetectionHandler;
            _dropAreaDetectionHandler = dropAreaDetectionHandler;
        }

        public void Dispose()
        {
            _view.CubeDetector.CubeDetected -= OnCubeDetected;
            _view.DropAreaDetector.DropAreaDetected -= OnDropAreaDetected;
        }

        public void Initialize()
        {
            _view.CubeDetector.CubeDetected += OnCubeDetected;
            _view.DropAreaDetector.DropAreaDetected += OnDropAreaDetected;
        }

        private void OnDropAreaDetected()
        {
            _dropAreaDetectionHandler.OnDropAreaDetected();
        }

        private void OnCubeDetected(CubeView view)
        {
            _cubeDetectionHandler.OnCubeViewDetected(view);
        }
    }
}