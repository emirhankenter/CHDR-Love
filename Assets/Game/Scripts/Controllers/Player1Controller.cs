﻿using Game.Scripts.Enums;
using Game.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Game.Scripts.Helpers;

namespace Game.Scripts.Controllers
{
    public class Player1Controller : MonoBehaviour
    {
        public CharacterController2D Controller;
        public Animator Animator;

        private Vector2 _lookDirection;
        private float _lookAngle;

        private PlayerData _player1;

        private float _horizontalInput;
        private float _verticalInput;
        private bool _jump = false;

        private Man _man;


        #region Singleton
        private static Player1Controller _instance;
        public static Player1Controller Instance { get { return _instance; } }
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

        private void Start()
        {
            _player1 = new PlayerData(GameConfig.Instance.Player1Speed);
            _man = new Man(GameConfig.Instance.Player1MaxLove);
        }

        private void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
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

            _verticalInput = Input.GetAxis("VerticalPlayer1");

            //animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            //float verticalMove = joystick.Vertical;

            if (_verticalInput > 0f)
            {
                _jump = true;
                //Animator.SetBool("IsJumping", true);
            }
        }

        public void OnLanding()
        {
            //Animator.SetBool("IsJumping", false);
        }

        public void GainLove(float damage)
        {
            _man.Love += damage;
            Mathf.Clamp(_man.Love, 0f, GameConfig.Instance.Player1MaxLove);
            Debug.Log(damage + " damage taken.");
        }

        void FixedUpdate()
        {
            Controller.Move(_horizontalInput * Time.fixedDeltaTime, false, _jump);
            _jump = false;
        }

    }
}