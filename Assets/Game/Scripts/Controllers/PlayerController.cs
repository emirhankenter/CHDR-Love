using Game.Scripts.Enums;
using Game.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game.Scripts.Helpers;

namespace Game.Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private PlayerEnum _player;

        public CharacterController2D Controller;
        public Animator Animator;

        private Vector2 _lookDirection;
        private float _lookAngle;

        private PlayerData _player1;
        private PlayerData _player2;

        private float _horizontalInput;
        private float _verticalInput;
        private bool _jump = false;



        private void Start()
        {
            if (_player == PlayerEnum.Player1)
            {
                _player1 = new PlayerData(GameConfig.Instance.Player1Speed);
            }
            else
            {
                _player2 = new PlayerData(GameConfig.Instance.Player2Speed);
            }
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
            if (_player == PlayerEnum.Player2)
            {
                _lookDirection = MouseHelper.GetMouseWorldPosition() - transform.position;
                _lookAngle = Mathf.Atan2(_lookDirection.y, _lookDirection.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0f, 0f, _lookAngle - 90f);
            }
        }

        private void OnFired()
        {
            if (_player == PlayerEnum.Player2)
            {
                InputController.FireClicked -= OnFired;

                FireController.Instance.Fire(transform);
                InputController.FireClicked += OnFired;
            }

        }

        private void MovePlayer()
        {
            //if (_player == PlayerEnum.Player1)
            //{
            //    _horizontalInput = _player1.Speed * Input.GetAxis("HorizontalPlayer1");
            //    _verticalInput = _player1.Speed * Input.GetAxis("VerticalPlayer1");
            //}
            //else
            //{
            //    _horizontalInput = _player2.Speed * Input.GetAxis("HorizontalPlayer2");
            //    _verticalInput = _player2.Speed * Input.GetAxis("VerticalPlayer2");


            //}
            //_rb.velocity = new Vector2(_horizontalInput, _verticalInput);


            if (_player == PlayerEnum.Player1)
            {
                if (Input.GetAxis("HorizontalPlayer1") >= .2f)
                {
                    _horizontalInput = _player1.Speed;
                }
                else if (Input.GetAxis("HorizontalPlayer1") <= -.2f)
                {
                    _horizontalInput = -_player1.Speed;

                }
                else
                {
                    _horizontalInput = 0f;
                }
                _verticalInput = _player1.Speed * Input.GetAxis("VerticalPlayer1");
            }
            else
            {
                if (Input.GetAxis("HorizontalPlayer2") >= .2f)
                {
                    _horizontalInput = _player2.Speed;
                }
                else if (Input.GetAxis("HorizontalPlayer2") <= -.2f)
                {
                    _horizontalInput = -_player2.Speed;

                }
                else
                {
                    _horizontalInput = 0f;
                }

                _verticalInput = _player2.Speed * Input.GetAxis("VerticalPlayer2");
            }


            //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            //float verticalMove = joystick.Vertical;

            if (_verticalInput >= .5f)
            {
                _jump = true;
                //Animator.SetBool("IsJumping", true);
            }
        }

        public void OnLanding()
        {
            //Animator.SetBool("IsJumping", false);
        }

        void FixedUpdate()
        {
            Controller.Move(_horizontalInput * Time.fixedDeltaTime, false, _jump);
            _jump = false;
        }
    }
}