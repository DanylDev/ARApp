using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DataQuestUI : MonoBehaviour
{
    public TextMeshProUGUI txtName;
    public Image imgState;
    public bool state = false;
    public bool current;

    public int index;

    public Color enableColor;
    public Color disableColor;

    private void Update()
    {
        imgState.enabled = state;

        if(state || current)
        {
            txtName.color = enableColor;
        }
        else
        {
            txtName.color = disableColor;
        }
    }
}
