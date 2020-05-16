using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Models
{
    public class PlayerData
    {
        private float _speed;
        public float Speed
        {
            get
            {
                return _speed;
            }
            set
            {
                _speed = value;
            }
        }

        public PlayerData(float speed)
        {
            Speed = speed;
        }

        public PlayerData()
        {

        }
    }


}