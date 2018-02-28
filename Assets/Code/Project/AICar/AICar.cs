using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class AICar : MonoBehaviour
{
    public enum TType
    {
        Stop,
        Pause,
        Start
    }

    public TType type = TType.Stop;

    [Header("AI")]
    public Transform targetList;
    public Transform targetIndex;
    public List<Transform> listPoint = new List<Transform>();
    public int curPoint = 0;
    public List<AICar> listCar = new List<AICar>();
    public bool viewCar;

    [Header("Data")]
    public Vector3 movDirection;
    public Vector3 rotDirection;
    public float speed = 1f;
    public float curSpeed;

    public float rotateSpeed = 0.05f;
    public float curRotateSpeed;

    public float fixDir;
    public bool view;

    private Transform localTransform;

    private void Start()
    {
        localTransform = transform;

        foreach(Transform box in targetList.GetComponentsInChildren<Transform>())
        {
            if(box != targetList)
            listPoint.Add(box);
        }

        StartDrive();
    }

    private void Update()
    {
        UpdateDrive();
    }

    private void StartDrive()
    {
        curPoint = targetIndex.GetSiblingIndex();
        type = TType.Start;
    }

    private void UpdateDrive()
    {
        if(type == TType.Start)
        {
            if (Vector3.Distance(localTransform.position, listPoint[curPoint].position) >= 0.2f)
            {
                view = CheckView();

                Movement(listPoint[curPoint]);
                Rotate(listPoint[curPoint + 1]);
            }
            else
            {
                curPoint++;
            }

            if (curPoint >= listPoint.Count - 1)
            {
                curPoint = listPoint[0].GetSiblingIndex();
            }
        }
    }

    private void Movement(Transform targetMov)
    {
        var Dir = localTransform.InverseTransformDirection(GetDir(targetMov));

        movDirection = Vector3.Lerp(movDirection, Dir, 0.02f);

        fixDir = Mathf.Abs(1 - (movDirection - localTransform.forward).magnitude);

        if (view)
        {
            curSpeed = Mathf.Lerp(curSpeed, speed - fixDir, 0.05f);
            curSpeed = Mathf.Clamp(curSpeed, 0, speed);
        }
        else
        {
            curSpeed = Mathf.Lerp(curSpeed, 0f, 0.1f);
        }

        localTransform.Translate(Dir * curSpeed * Time.deltaTime);
    }

    private void Rotate(Transform targetMov)
    {
        var Dir = GetDir(targetMov);

        Quaternion look = Quaternion.LookRotation(Dir, Vector3.up);

        if (view)
        {
            curRotateSpeed = Mathf.Lerp(curRotateSpeed, rotateSpeed, 0.05f);
            curRotateSpeed = Mathf.Clamp(curRotateSpeed, 0, rotateSpeed);
        }
        else
        {
            curRotateSpeed = Mathf.Lerp(curRotateSpeed, 0f, 0.1f);
        }

        localTransform.rotation = Quaternion.Lerp(localTransform.rotation, look, curRotateSpeed);
    }

    private bool CheckView()
    {
        var getLight = listPoint[curPoint].GetComponent<LinkTraffic>();

        if (getLight)
        {
            if(getLight.traffictLight.typeLight == TrafficLight.DataTrafficLight.TTypeLight.Red)
            {
                return false;
            }
        }

        for(int i=0; i<listCar.Count; i++)
        {
            if(Vector3.Distance(localTransform.position, listCar[i].transform.position) < 5f && Vector3.Angle(listCar[i].transform.position - localTransform.position, localTransform.forward) < 60)
            {
                return false;
            }
        }

        return true;
    }

    private Vector3 GetDir(Transform targetMov)
    {
        if (targetMov)
        {
            var Heg = targetMov.position - localTransform.position;
            var Dist = Heg.magnitude;
            var Dir = Heg / Dist;

            return Dir;
        }
        else
        {
            return Vector3.zero;
        }
    }
}
