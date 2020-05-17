using Game.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Models
{

    public class GameConfig : MonoBehaviour
    {
        #region Singleton
        private static GameConfig _instance;
        public static GameConfig Instance { get { return _instance; } }
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion
        [Header("PlayerSettings")]
        public float Player1Speed = 30f;
        public float Player1JumpForce = 200;
        public float Player1MaxLove = 100f;


        public float Player2Speed = 100f;
        public float Player2JumpForce = 100f;


        [Header("Arrow")]

        public float ArrowSpeed = 15f;
        public float ArrowCooldown = 2f;

    }
}