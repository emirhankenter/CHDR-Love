using Game.Scripts.Enums;
using Game.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Game.Scripts.Controllers
{
    public class PlayerController : MonoBehaviour
    {

        [SerializeField] private PlayerEnum _player;
        [SerializeField] private Rigidbody2D _rb;

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
        }

        private void Update()
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
            MovePlayer();
        }

        private void MovePlayer()
        {
            _rb.velocity = new Vector2(_horizontalInput, _verticalInput);
        }
    }
}