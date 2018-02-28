using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class CoreMainMenu : WindowManager
{
    private void Start()
    {
        base.Initialization();

        SwithcWindow(0);
    }

    public void SwithcWindow(int index)
    {
        for(int i=0; i<ListWindow.Count; i++)
        {
            if(index == i)
            {
                ListWindow[i].ShowState(true);
            }
            else
            {
                ListWindow[i].ShowState(false);
            }
        }
    }
}
