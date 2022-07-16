using System;
using System.Collections.Generic;
using Core.Level;
using UnityEngine;

namespace Core.Player
{
    public class PlayerStorage : IStorageInfoProvider
    {
        private readonly PlayerStorageConfig _playerStorageConfig;

        private readonly Stack<MovableCube> _storageStack = new Stack<MovableCube>();

        public PlayerStorage(Transform parent, PlayerStorageConfig playerStorageConfig)
        {
            Parent = parent;
            _playerStorageConfig = playerStorageConfig;
        }

        public int Count => _storageStack.Count;
        public Transform Parent { get; }
        public float Scale => _playerStorageConfig.ItemScale;

        public event Action ContentChanged;

        public bool TryAdd(MovableCube movableCube)
        {
            if (_storageStack.Count >= _playerStorageConfig.Capacity)
                return false;

            movableCube.MoveTo(this,
                Vector3.up * _storageStack.Count * _playerStorageConfig.ItemHeight
            );
            _storageStack.Push(movableCube);
            ContentChanged?.Invoke();
            return true;
        }

        public MovableCube GetLast() => _storageStack.Peek();

        public void Remove(MovableCube movableCube)
        {
            _storageStack.Pop();
            ContentChanged?.Invoke();
        }
    }

    public interface IStorageInfoProvider
    {
        Transform Parent { get; }
        float Scale { get; }
    }
}