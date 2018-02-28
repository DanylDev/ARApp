using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class DesignConstrctor : MonoBehaviour
{
    public enum TDesign
    {
        Stop,
        Run
    }

    public bool fixInit = false;
    public bool endSpawn = false;
    public TDesign typeDesign = TDesign.Stop;

    public Transform currentPoint;
    public Transform currentWall;
    public Transform currentGround;

    public Vector3 debugLook;

    public Vector3 midleWorldPoint;

    public List<DesignPoint> listPoints = new List<DesignPoint>();
    public LineRenderer LRendererCurrent;

    public GameObject prefabPoint;

    public void Initialization()
    {
        if (fixInit) { return; }

        typeDesign = TDesign.Run;

        currentPoint.gameObject.SetActive(true);
        currentWall.gameObject.SetActive(false);
        currentGround.gameObject.SetActive(false);
    }

    public void CoreUpdate()
    {
        if(fixInit)
        {
            currentPoint.gameObject.SetActive(false);
            currentWall.gameObject.SetActive(false);
            currentGround.gameObject.SetActive(false);
            return;
        }

        if(typeDesign == TDesign.Run)
        {
            DesignControl();
        }
    }

    private void DesignControl()
    {
        if (listPoints.Count == 0)
        {
            LRendererCurrent.enabled = false;
            currentWall.gameObject.SetActive(false);
            currentGround.gameObject.SetActive(false);
            return;
        }
        else
        {
            LRendererCurrent.enabled = true;
            currentWall.gameObject.SetActive(true);
            currentGround.gameObject.SetActive(true);
        }

        Vector3[] currentPosition = new Vector3[2];

        currentPosition[0] = listPoints[listPoints.Count - 1].transform.position;
        currentPosition[1] = currentPoint.transform.position;

        var Dist = Vector3.Distance(listPoints[listPoints.Count - 1].transform.position, currentPoint.transform.position);

        if (Dist >= 0.1f)
        {
            currentWall.gameObject.SetActive(true);

            Vector3 newPos = listPoints[listPoints.Count - 1].transform.position + (currentPoint.transform.position - listPoints[listPoints.Count - 1].transform.position) / 2;
            newPos.y = currentPoint.position.y + (currentWall.localScale.y / 2);

            currentWall.position = newPos;

            Vector3 lookPos = (currentPoint.transform.position - currentWall.position).normalized;

            debugLook = Camera.main.transform.InverseTransformDirection(lookPos);

            if (Camera.main.transform.InverseTransformDirection(lookPos).x < 0)
            {
                lookPos = (currentWall.position - currentPoint.transform.position).normalized;
            }

            lookPos.y = 0;

            currentWall.rotation = Quaternion.LookRotation(lookPos, Vector3.up);

            var getOffset = currentWall.GetComponent<MeshRenderer>().material.GetTextureScale("_MainTex");
            getOffset.x = 2 * (Dist + 1);
            getOffset.y = 4;
            currentWall.GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", getOffset);

            currentWall.localScale = new Vector3(currentWall.localScale.x, currentWall.localScale.y, Dist);

            currentGround.gameObject.SetActive(true);

            newPos.y = currentPoint.position.y;
            currentGround.position = newPos + currentGround.right * (Dist / 2);
            currentGround.rotation = Quaternion.LookRotation(lookPos, Vector3.up);
            currentGround.localScale = new Vector3(Dist, currentGround.localScale.y, Dist);

            var getOffsetGround = currentGround.GetComponent<MeshRenderer>().material.GetTextureScale("_MainTex");
            getOffsetGround.x = 1.5f * (Dist + 1);
            getOffsetGround.y = 1.5f * (Dist + 1);
            currentGround.GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", getOffsetGround);
        }
        else
        {
            currentWall.gameObject.SetActive(false);
            currentGround.gameObject.SetActive(false);
        }



        LRendererCurrent.SetPositions(currentPosition);
    }

    public void PointControl(Vector3 worldPointPosition)
    {
        if (listPoints.Count >= 3)
        {
            if (Vector3.Distance(worldPointPosition, listPoints[0].transform.position) <= 0.3f)
            {
                currentPoint.position = listPoints[0].transform.position;
                endSpawn = true;
            }
            else
            {
                currentPoint.position = worldPointPosition;
                endSpawn = false;
            }
        }
        else
        {
            currentPoint.position = worldPointPosition;
        }
    }

    public void FixPoint()
    {
        if (fixInit) { return; }

        Vector3 fixPos = currentWall.localPosition;

        //GameObject newPoint = Instantiate(prefabPoint, currentPoint.position, currentPoint.rotation);
        GameObject newPoint = CoreAR.Instance.InstantiateObj(prefabPoint);

        if(endSpawn)
        {
            newPoint.transform.SetParent(listPoints[0].transform);
            newPoint.transform.localPosition = Vector3.zero;
        }

        GameObject newWall = Instantiate(currentWall.gameObject);
        newWall.GetComponent<MeshRenderer>().material = new Material(currentWall.GetComponent<MeshRenderer>().material);
        newWall.transform.localPosition = fixPos;

        var data = newPoint.GetComponent<DesignPoint>();

        listPoints.Add(data);

        if(listPoints.Count == 1)
        {
            data.Initialization(listPoints[listPoints.Count - 2].transform, currentPoint, newWall.transform);
        }
        else if (listPoints.Count >= 2)
        {
            listPoints[0].Initialization(listPoints[1].transform, listPoints[0].transform, newWall.transform);
            data.Initialization(listPoints[listPoints.Count - 2].transform, listPoints[listPoints.Count - 1].transform, newWall.transform);
        }

        if (endSpawn)
        {
            for (int i = 0; i < listPoints.Count; i++)
            {
                midleWorldPoint += listPoints[i].transform.position;
            }

            midleWorldPoint /= listPoints.Count;

            currentPoint.gameObject.SetActive(false);
            currentWall.gameObject.SetActive(false);
            currentGround.gameObject.SetActive(false);

            fixInit = true;
            typeDesign = TDesign.Stop;
            CoreAppControl.Instance.DialogApp.CellWindow(WindowControll.TTypeWindow.PreStart);
        }
    }
}
