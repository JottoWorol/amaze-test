using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Utils
{
    public static class SmoothMove
    {
        private static readonly List<IMove> MoveList = new List<IMove>();

        public static IMove DoLocalMove(Transform target, Vector3 endValue, float duration)
        {
            var move = new LocalMove(target, endValue, duration);
            move.Complete += OnMoveComplete;
            MoveList.Add(move);

            return move;
        }

        public static void KillById(object id)
        {
            for (var moveIndex = 0; moveIndex < MoveList.Count; moveIndex++)
            {
                var move = MoveList[moveIndex];
                if (id == move.Id) move.ForceComplete();
            }
        }

        private static void OnMoveComplete(IMove move)
        {
            move.Complete -= OnMoveComplete;
            MoveList.Remove(move);
        }


        public static void Update()
        {
            for (var moveIndex = 0; moveIndex < MoveList.Count; moveIndex++)
            {
                var move = MoveList[moveIndex];
                move.Update();
            }
        }
    }

    public interface IMove
    {
        object Id { get; }
        void Update();
        void ForceComplete();
        IMove SetId(object id);
        IMove OnComplete(Action callback);
        event Action<IMove> Complete;
    }
}