using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Paradigm
{
    public abstract class CoreUI : MonoBehaviour
    {
        #region Core

        protected void SetString(TextMeshProUGUI txt, string text)
        {
            if (txt && txt.text != text)
            {
                txt.text = text;
            }
            else
            {
                return;
            }
        }

        protected void SetTimeString(Text txt, int _seconds)
        {
            if (txt)
            {
                int minute = _seconds / 60;
                float seconds = _seconds % 60;

                string txtMin = null;
                string txtSec = null;

                if (minute < 10)
                {
                    txtMin = "0" + minute;
                }
                else
                {
                    txtMin = minute.ToString();
                }

                if (seconds < 10)
                {
                    txtSec = "0" + seconds;
                }
                else
                {
                    txtSec = seconds.ToString();
                }


                string result = txtMin + ":" + txtSec;

                if(txt.text != result)
                {
                    txt.text = txtMin + ":" + txtSec;
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }
        }

        protected void SetImage(Image Img, Sprite Sprt)
        {
            if (Img && Img.sprite != Sprt)
            {
                Img.sprite = Sprt;
            }
            else
            {
                return;
            }
        }

        protected void SetSlider(Slider _Slider, float Value)
        {
            if (_Slider && _Slider.value != Value)
            {
                _Slider.value = Value;
            }
            else
            {
                return;
            }
        }

        protected virtual void Sound(CoreSound.TTypeSound type)
        {
           // CoreAppControl.Instance.CoreSound.PlayOneShot(type);
        }

        #region Static

        public static void SetActive(GameObject Obj, bool State)
        {
            if (Obj && Obj.activeSelf != State)
            {
                Obj.SetActive(State);
            }
            else
            {
                return;
            }
        }

        public static string GetStringColor(string Text, DDebug.TColor Type = DDebug.TColor.Default)
        {
            foreach (var Item in CoreAppControl.Instance.DataDebug.ListDebug)
            {
                if (Item.TypeColor == Type)
                {
                    string StrColor = Item.Color.r.ToString("X2") + Item.Color.g.ToString("X2") + Item.Color.b.ToString("X2");
                    return "<color=#" + StrColor + ">" + Text + "</color>";
                }
            }

            return Text;
        }

        public static void DebugLog(string text, DDebug.TColor Type = DDebug.TColor.Default)
        {
            Debug.Log(GetStringColor("[System] ", DDebug.TColor.System) + GetStringColor(text, Type));
        }

        #endregion

        #endregion
    }
}