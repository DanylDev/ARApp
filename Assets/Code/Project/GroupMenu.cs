using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Paradigm;

public class GroupMenu : WindowControll
{
    public InputField inputName;

    public GameObject buttonOk;

    private void Awake()
    {
        SetActive(buttonOk, false);
    }

    private void Update()
    {
        InputControl();
    }

    public void Play()
    {
        Globals.Instance.coreProfile.name = inputName.text;
        GameManager.Instance.PreGame();
    }

    private void InputControl()
    {
        if(inputName.text.Length > 0)
        {
            SetActive(buttonOk, true);
        }
        else
        {
            SetActive(buttonOk, false);
        }
    }
}
