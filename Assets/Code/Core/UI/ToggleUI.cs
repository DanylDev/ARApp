using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Paradigm
{
    public class ToggleUI : CoreUI
    {
        #region Data

        [Header("Data")]
        public GameObject active;

        [Header("LocalData")]
        private ToggleManagerUI _ToggleManagerUI;

        #endregion

        #region Core

        public void Initialization(ToggleManagerUI target)
        {
            _ToggleManagerUI = target;
        }

        public void OnEnter()
        {
            Sound(CoreSound.TTypeSound.Enter);
        }

        public void OnClick()
        {
            _ToggleManagerUI.Selected(this);
            Sound(CoreSound.TTypeSound.Click);
        }

        public void SwitchState(bool state)
        {
            SetActive(active, state);
        }

        #endregion
    }
}