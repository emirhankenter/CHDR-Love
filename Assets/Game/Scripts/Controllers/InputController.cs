using Game.Scripts.Enums;
using Game.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {

        [SerializeField] private PlayerEnum _player; 

        private PlayerData _player1;
        private PlayerData _player2;

        private float HorizontalInput;
        private float VerticalInput;


        private void Update()
        {

            if (_player == PlayerEnum.Player1)
            {
                HorizontalInput = _player1.Speed * Input.GetAxis("HorizontalPlayer1");
                VerticalInput = _player1.Speed * Input.GetAxis("VerticalPlayer1");
            }
            else
            {
                HorizontalInput = _player2.Speed * Input.GetAxis("HorizontalPlayer2");
                VerticalInput = _player2.Speed * Input.GetAxis("VerticalPlayer2");
            }
        }




        //#region Singleton
        //private static InputController _instance;

        //public static InputController Instance { get { return _instance; } }

        //private void Awake()
        //{
        //    if (_instance != null && _instance != this)
        //    {
        //        Destroy(this.gameObject);
        //    }
        //    else
        //    {
        //        _instance = this;
        //    }
        //}
        //#endregion

    }
}