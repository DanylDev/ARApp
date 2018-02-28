using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class MainMenu : WindowControll
{
    public CoreMainMenu coreMainMenu;

    public void Group()
    {
        coreMainMenu.SwithcWindow(1);
    }
}
