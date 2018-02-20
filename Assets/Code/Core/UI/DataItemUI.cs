using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Paradigm
{
    public class DataItemUI : CoreUI
    {
        public int id;

        [Header("Data")]
        public TextMeshProUGUI label;
        public TextMeshProUGUI price;
        public Image icon;

        public void Initialization(int _id, string _label, int _price, Sprite _icon)
        {
            id = _id;
            SetString(label, _label);
            SetString(price, _price.ToString());
            SetImage(icon, _icon);
        }
    }
}