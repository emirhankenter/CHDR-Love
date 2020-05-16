using Game.Scripts.Helpers;
using Game.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Scripts.Controllers
{
    public class FireController : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToFire;
        [SerializeField] private Transform _firePoint;
        public float cooldownTimer;

        private Vector2 _lookDirection;
        private float _lookAngle;
        private void Start()
        {
        }
        private void Update()
        {
            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
            }
            if (cooldownTimer < 0)
            {
                cooldownTimer = 0;
            }


        }

        public void Fire(Transform myTransform)
        {
            var _clone = Instantiate(_objectToFire, myTransform.position, myTransform.rotation);
            //_clone.transform.rotation.SetLookRotation(Camera.main.transform.position);
            _clone.GetComponent<Rigidbody2D>().velocity = _firePoint.up * GameConfig.Instance.ArrowSpeed;
            Cool();
        }

        private void Cool()
        {
            cooldownTimer = GameConfig.Instance.ArrowCooldown;
        }

        #region Singleton
        private static FireController _instance;
        public static FireController Instance { get { return _instance; } }
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
    }
}