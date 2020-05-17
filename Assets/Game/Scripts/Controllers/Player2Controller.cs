using Game.Scripts.Enums;
using Game.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game.Scripts.Helpers;

namespace Game.Scripts.Controllers
{
    public class Player2Controller : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;

        public Animator Animator;

        private Vector2 _lookDirection;
        private float _lookAngle;

        private PlayerData _player2;

        private float _horizontalInput;
        private float _verticalInput;



        private void Start()
        {
            _player2 = new PlayerData(GameConfig.Instance.Player2Speed);
            RegisterEvents();
        }

        private void RegisterEvents()
        {
            InputController.FireClicked += OnFired;
        }

        private void UnregisterEvents()
        {
            InputController.FireClicked -= OnFired;
        }

        private void Update()
        {
            MovePlayer();

            _lookDirection = MouseHelper.GetMouseWorldPosition() - transform.position;
            _lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
            Debug.Log("Look Angle: " + _lookAngle);
            if (_lookAngle >= -90 && _lookAngle <= 80f)
            {
                //Debug.Log("Right");
                GetComponent<SpriteRenderer>().flipX = false;
                transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);

            }
            else if ((_lookAngle <= -90) || (_lookAngle >= 100f))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
            }

        }

        private void OnFired()
        {
            InputController.FireClicked -= OnFired;

            FireController.Instance.Fire(transform);
            InputController.FireClicked += OnFired;
        }

        private void MovePlayer()
        {
            _horizontalInput = _player2.Speed * Input.GetAxis("HorizontalPlayer2");
            //_verticalInput = _player2.Speed * Input.GetAxis("VerticalPlayer2");
            _verticalInput = Input.GetAxis("VerticalPlayer2") <= 0 ? 0 : GameConfig.Instance.Player2JumpForce * Mathf.Abs(Input.GetAxis("VerticalPlayer2"));
            _rb.AddForce(new Vector2(_horizontalInput, _verticalInput));


            //_rb.velocity = new Vector2(_horizontalInput, 0);

        }

        private void FixedUpdate()
        {
            if (_rb.velocity.magnitude > 2f)
            {
                _rb.velocity = _rb.velocity.normalized * 2f;
            }
        }
    }
}