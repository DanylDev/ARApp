using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Paradigm;

public class LeadboardPole : CoreUI
{
    public TextMeshProUGUI txtNumber;
    public TextMeshProUGUI txtName;
    public TextMeshProUGUI txtScore;

    public Image imgSelected;

    public void Initialization(string name, int number, int score, bool _selected)
    {
        SetString(txtNumber, number.ToString());
        SetString(txtName, name);
        SetString(txtScore, score.ToString());

        imgSelected.enabled = _selected;
    }
}
