using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Paradigm
{
    public class SliderUI : CoreUI
    {
        #region Data

        public enum TTypeValue
        {
            Value,
            Percent
        }

        [Header("Data")]
        public TTypeValue TypeValue;
        [Range(0f, 1f)] public float Lerp = 0;
        public bool ShowValue = false;

        [Header("DataUI")]
        public TextMeshProUGUI TxtValue;

        [Header("LocalData")]
        private Slider _Slider;

        #endregion

        #region Core

        public void Initialization(float CurValue, float MaxValue)
        {
            _Slider = GetComponent<Slider>();

            if (_Slider)
            {
                _Slider.maxValue = MaxValue;

                SetValue(CurValue);
            }
        }

        public void SetValue(float _Value)
        {
            if (Lerp > 0)
            {
                SetSlider(_Slider, Mathf.Lerp(_Slider.value, _Value, Lerp));
            }
            else
            {
                SetSlider(_Slider, _Value);
            }

            SetTxtValue();
        }

        private void SetTxtValue()
        {
            if (ShowValue)
            {
                SetActive(TxtValue.gameObject, true);

                switch (TypeValue)
                {
                    case TTypeValue.Value:
                        SetString(TxtValue, _Slider.value + "%");
                        break;

                    case TTypeValue.Percent:
                        SetString(TxtValue, (_Slider.value * 100f / _Slider.maxValue) + "%");
                        break;
                }
            }
            else
            {
                SetActive(TxtValue.gameObject, false);
            }
        }

        #endregion
    }
}