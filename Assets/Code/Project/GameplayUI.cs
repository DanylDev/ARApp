using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Paradigm;
using TMPro;

public class GameplayUI : WindowControll
{
    public TextMeshProUGUI txtTimer;
    public GameObject backToZone;
    public GameObject backToStartZone;

    public TextMeshProUGUI txtCrashCounter;

    [Header("TrafficLight")]
    public float minDistanceToLight = 5f;

    public GameObject parentLight;
    public List<Image> listImgLight = new List<Image>();

    ParadigmControl getLinkParadigm;

    private short indexTimer;

    public void Start()
    {
        InitTimer();

        SetActive(backToZone, false);
        SetActive(backToStartZone, false);

        getLinkParadigm = ParadigmControl.Instance;
    }

    public void Update()
    {
        TrafiicLightControl();
        CrashControl();
        TimerControl();
        ZoneControl();
    }

    private void InitTimer()
    {
        indexTimer = Globals.Instance.coreWorldTime.AddTimer(300);
    }

    private void TimerControl()
    {
        int allSecond = Globals.Instance.coreWorldTime.listDataTime[indexTimer].result.Seconds;
        allSecond += Globals.Instance.coreWorldTime.listDataTime[indexTimer].result.Minutes * 60;

        SetTimeString(txtTimer, + allSecond);

        if(allSecond <= 0)
        {
            GameManager.Instance.StopGame();
        }
    }

    private void ZoneControl()
    {
        Vector3 fixPos = Camera.main.transform.position;
        fixPos.y = PlayerControl.Instance.designerContructor.midleWorldPoint.y;

        if(Vector3.Distance(PlayerControl.Instance.designerContructor.midleWorldPoint, fixPos) >= 20)
        {
            SetActive(backToZone, true);
        }
        else
        {
            SetActive(backToZone, false);
        }
    }

    private void TrafiicLightControl()
    {
        bool find = false;
        TrafficLight getLight = null;

        for(int i=0; i<ParadigmControl.Instance.listLight.Count; i++)
        {
            if (Vector3.Distance(ParadigmControl.Instance.listLight[i].transform.position, Camera.main.transform.position) <= minDistanceToLight)
            {
                SetActive(parentLight, true);
                getLight = ParadigmControl.Instance.listLight[i];
                find = true;
                break;
            }
        }

        if(!find)
        {
            SetActive(parentLight, false);
            return;
        }

        int activeIndex = 0;

        switch(getLight.typeLight)
        {
            case TrafficLight.DataTrafficLight.TTypeLight.Red:
                activeIndex = 0;
                break;
            case TrafficLight.DataTrafficLight.TTypeLight.Yellow:
                activeIndex = 1;
                break;
            case TrafficLight.DataTrafficLight.TTypeLight.Green:
                activeIndex = 2;
                break;
        }

        for(int i=0; i<listImgLight.Count; i++)
        {
            if(activeIndex == i)
            {
                listImgLight[i].enabled = true;
            }
            else
            {
                listImgLight[i].enabled = false;
            }
        }
    }

    public void BackToZoneMode(bool state)
    {
        SetActive(backToStartZone, state);
    }

    public void CrashControl()
    {
        SetString(txtCrashCounter, GameManager.Instance.crashCounter.ToString());
    }
}
