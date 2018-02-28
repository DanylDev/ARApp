using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreProfile
{
    public string name;
    public int timeSecond;
    public int crashCounter;
    public int result
    {
        get { return 100 + timeSecond - (crashCounter * 10); }
        private set { }
    }

    public void Reset()
    {
        name = null;
        timeSecond = 0;
        crashCounter = 0;
    }
}
