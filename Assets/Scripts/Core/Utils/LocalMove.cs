using System;
using UnityEngine;

namespace Core.Utils
{
    internal class LocalMove : IMove
    {
        private readonly Transform _targetTransform;
        private readonly Vector3 _from;
        private readonly Vector3 _to;
        private float _time;
        private readonly float _duration;

        private Action _onCompleteAction;
        
        public LocalMove(Transform targetTransform, Vector3 to, float duration)
        {
            _targetTransform = targetTransform;
            _to = to;
            _duration = duration;

            _from = targetTransform.localPosition;
        }

        public void Update()
        {
            if (_time > _duration)
                return;
            
            _time += Time.deltaTime;
            _targetTransform.localPosition = Vector3.Lerp(_from, _to, _time / _duration);

            if(_time >= _duration)
            {
                _onCompleteAction?.Invoke();
                Complete?.Invoke(this);
            }
        }

        public void ForceComplete()
        {
            Complete?.Invoke(this);
        }
        
        public IMove OnComplete(Action callback)
        {
            _onCompleteAction = callback;
            return this;
        }

        public IMove SetId(object id)
        {
            Id = id;
            return this;
        }

        public object Id { get; private set; }

        public event Action<IMove> Complete;
    }
}