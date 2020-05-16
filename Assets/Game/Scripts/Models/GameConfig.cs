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
        public float Player1Speed = 10f;
        public float Player2Speed = 5f;

        [Header("Arrow")]

        public float ArrowSpeed = 15f;
        public float ArrowCooldown = 0.5f;

    }
}