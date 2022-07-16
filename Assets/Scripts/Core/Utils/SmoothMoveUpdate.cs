using Zenject;

namespace Core.Utils
{
    public class SmoothMoveUpdate : ITickable
    {
        public void Tick()
        {
            SmoothMove.Update();
        }
    }
}