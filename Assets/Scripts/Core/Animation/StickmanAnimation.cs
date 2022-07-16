using UnityEngine;

namespace Core.Animation
{
    public abstract class StickmanAnimation
    {
        private static readonly int Idle = Animator.StringToHash("idle");
        private static readonly int Run = Animator.StringToHash("run");
        private static readonly int IsHolding = Animator.StringToHash("is_holding");
        protected abstract Animator Animator { get; set; }

        public void PlayIdle()
        {
            Animator.SetTrigger(Idle);
        }

        public void PlayRun()
        {
            Animator.SetTrigger(Run);
        }

        public void SetHolding(bool holding) => Animator.SetFloat(IsHolding, holding ? 1 : 0);
    }
}