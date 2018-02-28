using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class CoreLeaderboard
{
    public List<CoreProfile> listProfile = new List<CoreProfile>();

    public void AddResult()
    {
        CoreProfile newResult = new CoreProfile();

        newResult.name = Globals.Instance.coreProfile.name;
        newResult.timeSecond = Globals.Instance.coreProfile.timeSecond;
        newResult.crashCounter = Globals.Instance.coreProfile.crashCounter;

        listProfile.Add(newResult);
    }
}
