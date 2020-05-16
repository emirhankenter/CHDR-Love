using Game.Scripts.Enums;
using Game.Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class InputController : MonoBehaviour
    {
        public static event Action FireClicked;
        private void Update()
        {
            if (Input.GetButton("Fire1") && FireController.Instance.cooldownTimer == 0)
            {
                FireClicked?.Invoke();
            }
        }

        //#region Singleton
        //private static InputController _instance;
        //public static InputController Instance { get { return _instance; } }

        //#endregion
    }
}