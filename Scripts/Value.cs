using UnityEngine;
using System;

namespace Alprogram.Alvalues
{
    public class Value<T> : ScriptableObject
    {
        public Action OnValueChange;

        [SerializeField] private T currentValue;

        public T CurrentValue
        {
            get => currentValue;
            set
            {
                currentValue = value;
                OnValueChange?.Invoke();
            }

        }

        private void OnValidate() => OnValueChange?.Invoke();
    }
}
