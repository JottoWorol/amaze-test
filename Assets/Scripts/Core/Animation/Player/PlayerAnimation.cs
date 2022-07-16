using System;
using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Animation.Player
{
    public class PlayerAnimation : StickmanAnimation, IInitializable, IDisposable
    {
        private readonly PlayerMove _playerMove;
        public PlayerAnimation(PlayerMove playerMove)
        {
            _playerMove = playerMove;
        }
        protected override Animator Animator { get; set; }
        public void Initialize()
        {
            _playerMove.StartedMoving += OnStartedMoving;
            _playerMove.StoppedMoving += OnStoppedMoving;
        }

        public void Dispose()
        {
            _playerMove.StartedMoving -= OnStartedMoving;
            _playerMove.StoppedMoving -= OnStoppedMoving;
        }
        
        public void SetAnimator(Animator animator)
        {
            Animator = animator;
        }

        private void OnStartedMoving()
        {
            if(Animator == null)
                return;
            
            PlayRun();
        }

        private void OnStoppedMoving()
        {
            if(Animator == null)
                return;
            
            PlayIdle();
        }
    }
}