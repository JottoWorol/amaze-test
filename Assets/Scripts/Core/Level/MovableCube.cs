using System;
using Core.Infrastructure;
using Core.Player;
using Core.Utils;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Level
{
    public class MovableCube
    {
        public MovableCube(CubeView cubeView) => CubeView = cubeView;

        public CubeView CubeView { get; }
        public bool IsCollectible { get; private set; } = true;

        public void MoveTo(IStorageInfoProvider storageInfoProvider, Vector3 localPosition)
        {
            CubeView.Transform.SetParent(storageInfoProvider.Parent);

            SmoothMove.KillById(this);
            SmoothMove.DoLocalMove(CubeView.Transform, localPosition, CubeView.MoveDuration)
                .SetId(this).OnComplete(() => CubeView.Transform.localScale = Vector3.one * storageInfoProvider.Scale);
            CubeView.transform.localRotation = Quaternion.identity;
        }

        public void MoveToWithCompleteCallback(IStorageInfoProvider storageInfoProvider, Vector3 localPosition,
            Action onComplete)
        {
            CubeView.Transform.SetParent(storageInfoProvider.Parent);

            SmoothMove.KillById(this);
            SmoothMove.DoLocalMove(CubeView.Transform, localPosition, CubeView.MoveDuration)
                .SetId(this).OnComplete(() =>
                    {
                        CubeView.Transform.localScale = Vector3.one * storageInfoProvider.Scale;
                        onComplete();
                    }
                );
            CubeView.transform.localRotation = Quaternion.identity;
        }

        public void SetCollectible(bool isCollectible) => IsCollectible = isCollectible;
    }
}