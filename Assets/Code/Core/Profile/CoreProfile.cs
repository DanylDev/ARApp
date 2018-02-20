using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreProfile
{
    public int money;
    public int midleDistance;
    public int maximumDistance;

    public int curSwapID = 0;
    public int curFlyID = 1;
    public int curGravityID = 2;

    public bool hdMode = false;
    public bool soundMode = true;
    public bool musicMode = true;

    public bool premium = false;

    public bool tutorialSwap = false;
    public bool tutorialFly = false;
    public bool tutorialGravity = false;

    public int skillRunning = 0;
    public int skillShieldCounter = 0;
    public int skillMagnedTime = 0;
    public int skillMagnedRadius = 0;
}
