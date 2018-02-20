using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Paradigm
{
    public class CoreAppManagerUI : CoreUI
    {
        #region Data

        [Header("LoadBar")]
        public Image LoadBarFill;
        public TextMeshProUGUI LoadBarPercet;

        #endregion

        #region Unity

        private void Awake()
        {
            Initialization();
        }

        private void Start()
        {

        }

        private void Update()
        {
            CoreUpdate();
        }

        #endregion

        #region Core

        #region Init

        public void Initialization()
        {
            DebugLog(GetStringColor("LoadManager Inittialization", DDebug.TColor.Apply));
        }

        public void CoreUpdate()
        {
            LoadBar();
        }

        #endregion

        private void LoadBar()
        {
            LoadBarFill.fillAmount = CoreAppControl.Instance.progress;
            SetString(LoadBarPercet, Mathf.CeilToInt(CoreAppControl.Instance.progress * 100).ToString() + "%");
        }

        #endregion
    }
}