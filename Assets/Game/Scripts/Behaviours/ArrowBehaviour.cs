using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game.Scripts.Models;

namespace Game.Scripts.Behaviours
{
    public class ArrowBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        private Vector3 currPoint;
        private Vector3 currDir;
        private Vector3 prevPoint;
        private float rotateOffset;

        private void Awake()
        {
            DOTween.Init();
        }
        void Start()
        {
            _rb.velocity = GameConfig.Instance.ArrowSpeed * Vector3.right;
        }

        // Update is called once per frame
        void Update()
        {
            //RotationChangeWhileFlying();
        }

        void RotationChangeWhileFlying()
        {
            currPoint = transform.position;

            //get the direction (from previous pos to current pos)
            currDir = prevPoint - currPoint;

            //normalize the direction
            currDir.Normalize();

            //get angle whose tan = y/x, and convert from rads to degrees
            float rotationZ = Mathf.Atan2(currDir.y, currDir.x) * Mathf.Rad2Deg;
            Vector3 Vzero = Vector3.zero;

            //rotate z based on angle above + an offset (currently 90)
            transform.rotation = Quaternion.Euler(0, 0, rotationZ + rotateOffset);

            //store the current point as the old point for the next frame
            prevPoint = currPoint;
        }
    }
}