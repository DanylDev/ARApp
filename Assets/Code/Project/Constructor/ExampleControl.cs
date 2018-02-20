using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class ExampleControl : MonoBehaviour
{
    #region Data

    public DesignConstrctor designConstrctor;

    private Ray ray;
    private RaycastHit hit;

    #endregion

    #region Unity

    private void Start()
    {
        Initialization();
    }

    private void Update()
    {
        CoreUpdate();
    }

    #endregion

    #region Core

    public void Initialization()
    {

    }

    public void CoreUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            designConstrctor.PointControl(hit.point);

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                designConstrctor.FixPoint();
            }
        }
    }

    #endregion
}
