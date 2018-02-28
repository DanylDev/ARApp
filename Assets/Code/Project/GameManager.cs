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

    public void PreGame()
    {
        mainMenu.SwithcWindow(999);

        if (!PlayerControl.Instance.currentGround)
        {
            if (PlayerControl.Instance.designerContructor.typeDesign == DesignConstrctor.TDesign.Stop)
            {
                PlayerControl.Instance.Inititalization();
            }
            else
            {
                CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.PreStart);
            }
        }
        else
        {
            //StartGame();
            PlayerControl.Instance.currentGround.GetComponent<ParadigmControl>().CellToPlay();
            CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.PreStart);
        }
    }

    public void StartGame()
    {
        if (gameMode == TType.Gameplay) { return; }

        gameMode = TType.Gameplay;

        mainMenu.SwithcWindow(999);
        crashCounter = 0;

        if (PlayerControl.Instance.currentGround) { PlayerControl.Instance.currentGround.GetComponent<ParadigmControl>().city.SetActive(true); }

        ParadigmControl.Instance.CellToPlay();
        CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.Gameplay);
        PlayerControl.Instance.Inititalization();
    }

    public void BackGame()
    {
        if (gameMode == TType.BackToZone) { return; }

        Globals.Instance.coreProfile.timeSecond = Globals.Instance.coreWorldTime.listDataTime[0].result.Seconds;
        Globals.Instance.coreProfile.crashCounter = crashCounter;
        Globals.Instance.coreLeaderboard.AddResult();

        gameMode = TType.BackToZone;

        PlayerControl.Instance.currentGround.GetComponent<ParadigmControl>().StopGame();
        PlayerControl.Instance.currentGround.GetComponent<ParadigmControl>().city.SetActive(false);
        CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.Leadboard);

        CoreAppControl.Instance.DialogApp.GetWindow(WindowControll.TTypeWindow.Gameplay).GetComponent<GameplayUI>().BackToZoneMode(true);
    }

    public void StopGame()
    {
        if (gameMode == TType.MainMenu) { return; }

        gameMode = TType.MainMenu;

        ParadigmControl.Instance.StopGame();

        mainMenu.GetWindow(WindowControll.TTypeWindow.MainMenu).gameObject.SetActive(true);

        Destroy(CoreAppControl.Instance.DialogApp.GetWindow(WindowControll.TTypeWindow.Leadboard).gameObject);
        PlayerControl.Instance.ResetInitialization();
    }

    public void AddCrash()
    {
        if (gameMode != TType.Gameplay) { return; }

        crashCounter++;
        Globals.Instance.coreWorldTime.AwaeSecond(Globals.Instance.coreWorldTime.listDataTime.Count - 1, 10 * crashCounter);

    }

    private void CoreUpdate()
    {
        if(gameMode == TType.Gameplay)
        {
            CoreAR.Instance.CoreUpdate();
        }
    }
}
