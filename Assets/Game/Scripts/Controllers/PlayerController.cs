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
        [SerializeField] private Rigidbody2D _rb;

        private Vector2 _lookDirection;
        private float _lookAngle;

        private PlayerData _player1;
        private PlayerData _player2;

        private float _horizontalInput;
        private float _verticalInput;



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
            if (_player == PlayerEnum.Player1)
            {
                _horizontalInput = _player1.Speed * Input.GetAxis("HorizontalPlayer1");
                _verticalInput = _player1.Speed * Input.GetAxis("VerticalPlayer1");
            }
            else
            {
                _horizontalInput = _player2.Speed * Input.GetAxis("HorizontalPlayer2");
                _verticalInput = _player2.Speed * Input.GetAxis("VerticalPlayer2");


            }
            _rb.velocity = new Vector2(_horizontalInput, _verticalInput);
        }
    }
}