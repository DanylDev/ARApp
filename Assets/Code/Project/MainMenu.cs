﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class MainMenu : WindowControll
{
    public void Play()
    {
        GameManager.Instance.StartGame();
    }
}
