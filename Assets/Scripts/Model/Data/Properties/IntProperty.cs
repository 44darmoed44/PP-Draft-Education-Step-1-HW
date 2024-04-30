using System;
using UnityEngine;

namespace Scripts.Model.Data.Properties
{
    [Serializable]
    public class IntProperty : PersistentProperty<int>
    {
        public IntProperty(int defaultValue) : base(defaultValue)
        {
        }

        protected override int Read(int defaultValue)
        {
            return _stored;
        }

        protected override void Write(int value)
        {
            _stored = value;
        }
    }
}   