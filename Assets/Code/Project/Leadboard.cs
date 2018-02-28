using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class Leadboard : WindowControll
{
    [Header("UI")]
    public Transform content;
    public GameObject examplePrefab;
    public List<LeadboardPole> listResult = new List<LeadboardPole>();

    public override void Initialization()
    {
        base.Initialization();

        print("Hi");
    }

    private void Start()
    {
        examplePrefab.SetActive(false);

        InitList();
    }

    public void InitList()
    {
        for (int i = 0; i < listResult.Count; i++)
        {
            if (listResult[i]) { Destroy(listResult[i].gameObject); }
        }

        listResult = new List<LeadboardPole>();

        List<CoreProfile> getList = Globals.Instance.coreLeaderboard.listProfile;

        var temp = new CoreProfile();
        for (int i = 0; i < getList.Count; i++)
        {
            for (int w = 0; w < getList.Count; w++)
            {
                if(getList[i].result < getList[w].result)
                {
                    temp = getList[i];
                    getList[i] = getList[w];
                    getList[w] = temp;
                }
            }
        }

        for (int i = 0; i < getList.Count; i++)
        {
            if (listResult.Count < 10)
            {
                GameObject newPrefab = Instantiate(examplePrefab, content);
                newPrefab.SetActive(true);

                LeadboardPole Data = newPrefab.GetComponent<LeadboardPole>();
                Data.Initialization(getList[i].name, i + 1, getList[i].result, getList[i].name == Globals.Instance.coreProfile.name);

                listResult.Add(Data);
            }
            else
            {
                break;
            }
        }
    }

    public void NextGame()
    {
        GameManager.Instance.StopGame();
    }
}
