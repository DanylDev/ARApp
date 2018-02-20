using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public enum TType
    {
        MainMenu,
        Gameplay,
        BackToZone
    }

    public PlayerControl playerController;
    public CoreMainMenu mainMenu;

    public int crashCounter = 0;

    public TType gameMode = TType.MainMenu;

    private void Update()
    {
        CoreUpdate();
    }

    public void StartGame()
    {
        if (gameMode == TType.Gameplay) { return; }

        gameMode = TType.Gameplay;

        mainMenu.GetWindow(WindowControll.TTypeWindow.MainMenu).gameObject.SetActive(false);

        if(CoreAR.Instance.init)
        {
            if (ParadigmControl.Instance) { ParadigmControl.Instance.CellToPlay(); }
            CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.Gameplay);
            PlayerControl.Instance.Inititalization();
        }
        else
        {
            CoreAR.Instance.Initialization();
        }
    }

    public void BackGame()
    {
        if (gameMode == TType.BackToZone) { return; }

        gameMode = TType.BackToZone;

        CoreAppControl.Instance.DialogApp.GetWindow(WindowControll.TTypeWindow.Gameplay).GetComponent<GameplayUI>().BackToZoneMode(true);
    }

    public void StopGame()
    {
        if (gameMode == TType.MainMenu) { return; }

        gameMode = TType.MainMenu;

        ParadigmControl.Instance.StopGame();

        mainMenu.GetWindow(WindowControll.TTypeWindow.MainMenu).gameObject.SetActive(true);

        CoreAppControl.Instance.DialogApp.GetWindow(WindowControll.TTypeWindow.Gameplay).GetComponent<GameplayUI>().BackToZoneMode(false);
        PlayerControl.Instance.ResetInitialization();
    }

    public void AddCrash()
    {
        crashCounter++;
    }

    private void CoreUpdate()
    {
        if(gameMode == TType.Gameplay)
        {
            CoreAR.Instance.CoreUpdate();
        }
    }
}
