using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using Paradigm;

public class CoreAR : PlaneManager
{
    public static CoreAR Instance;

    [Header("CoreAR")]
    public bool visualGrid = false;
    public bool init { get; private set; }

    public GameObject cursorAuto;
    public GameObject cursorTap;

    public delegate void OnInitialization();
    public event OnInitialization onInitialization;

    #region Unity

    private void Awake()
    {
        Instance = this;
        init = true;
    }

    private void Update()
    {
        DebugControl();
    }

    #endregion

    #region Core

    public void Initialization()
    {
        init = true;

        //CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.ARLoading, true);
        ///CoreAppControl.Instance.DialogApp.GetWindow(WindowControll.TTypeWindow.ARLoading).transform.SetParent(transform);
    }

    public void CoreUpdate()
    {
        MainControl();
    }

    private void MainControl()
    {
        if (visualGrid) { VisualGrid(); }

        if (!init)
        {
            //if (showSearching == false)
            //{
            onInitialization();
            init = true;
            //CoreAppControl.Instance.DialogApp.GetWindow(WindowControll.TTypeWindow.ARLoading).ShowState(false);
            //}
        }
    }

    private void DebugControl()
    {
        cursorAuto.PositionAt(Vector3.Lerp(cursorAuto.transform.position, hitUpdatePosition, 0.1f));
        cursorTap.PositionAt(hitTapPosition);
    }

    private void VisualGrid()
    {
    }

    #region Public Cell

    public GameObject InstantiateObj(GameObject prefab)
    {
        GameObject newPrefab = Instantiate(prefab);
        newPrefab.transform.SetParent(transform);
        newPrefab.PositionAt(hitUpdatePosition);
        RotateTowardCamera(newPrefab);

        return newPrefab;
    }

    public GameObject InstantiateObj(GameObject prefab, Vector3 position)
    {
        GameObject newPrefab = Instantiate(prefab);
        newPrefab.transform.SetParent(transform);
        newPrefab.PositionAt(position);
        RotateTowardCamera(newPrefab);

        return newPrefab;
    }

    #endregion

    #endregion
}