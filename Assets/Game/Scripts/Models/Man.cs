using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Models
{
    public class Man
    {
        protected float _love;
        protected float _maxLove;
        public float Love
        {
            get
            {
                return _love;
            }
            set
            {
                _love = value;
            }
        }

        public Man(float maxLove)
        {
            _maxLove = maxLove;
        }
    }
}