using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game.Scripts.Models;
using UnityEngine.UIElements;
using Game.Scripts.Controllers;

namespace Game.Scripts.Behaviours
{
    public class ArrowBehaviour : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private Transform _centerOfMass;
        private Vector3 currPoint;
        private Vector3 currDir;
        private Vector3 prevPoint;
        private float rotateOffset;

        private bool isHit;
        private bool _followArc;
        private bool _firstFrame;

        private void Awake()
        {
            DOTween.Init();
        }
        void Start()
        {
            //_rb.velocity = GameConfig.Instance.ArrowSpeed * Vector3.one;
            _rb.centerOfMass = _centerOfMass.position;
            _firstFrame = true;
            _followArc = true;
        }

        // Update is called once per frame
        void Update()
        {
            //RotationChangeWhileFlying();
            RotateArrow();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player1" && !isHit)
            {
                Debug.Log("Hit!");
                isHit = true;
                //transform.SetParent(col.gameObject.transform);
                Player1Controller.Instance.GainLove(10f);
            }
            _followArc = false;
            _rb.velocity = Vector2.zero;
        }

        private void RotateArrow()
        {
            transform.LookAt(transform.position, _rb.velocity);
            //transform.rotation = Quaternion.LookRotation(_rb.velocity);
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

        private void FixedUpdate()
        {
            //if (_followArc && !_firstFrame)
            //{
            //    transform.right = _rb.velocity; // this line makes the arrow follow the parabolic arc
            //}
            _firstFrame = false;

        }

    }
}