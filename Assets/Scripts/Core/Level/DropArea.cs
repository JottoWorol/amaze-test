using Core.Infrastructure;
using Core.Player;
using UnityEngine;

namespace Core.Level
{
    public class DropArea : IStorageInfoProvider
    {
        public Transform Parent { get; }
        public float Scale { get; }
        
        public DropArea(SceneData sceneData)
        {
            Parent = sceneData.LevelView.DropAreaCollider.transform;
            Scale = 0;
        }
    }
}