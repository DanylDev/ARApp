using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLight : MonoBehaviour
{
    [System.Serializable]
    public class DataTrafficLight
    {
        public enum TTypeLight
        {
            Red,
            Yellow,
            Green
        }

        public TTypeLight typeLight = TTypeLight.Green;
        public float timer;
        public Material matLight;
        public MeshRenderer targetMesh;
    }

    public DataTrafficLight.TTypeLight typeLight;
    public float curTimer = 0;

    public List<DataTrafficLight> listTraffictLight = new List<DataTrafficLight>();
    private bool inversiaLight = false;

    private void Start()
    {
    }

    private void Update()
    {
        TrafficLightControl();
    }

    private void TrafficLightControl()
    {
        curTimer += Time.deltaTime;

        for (int i = 0; i < listTraffictLight.Count; i++)
        {
            if(typeLight == listTraffictLight[i].typeLight)
            {
                listTraffictLight[i].targetMesh.enabled = true;

                if(curTimer >= listTraffictLight[i].timer)
                {
                    int getIndex = 0;

                    if(!inversiaLight)
                    {
                        getIndex = GetIndex(typeLight) + 1;
                    }
                    else
                    {
                        getIndex = GetIndex(typeLight) - 1;
                    }

                    if(getIndex > 2 || getIndex < 0)
                    {
                        getIndex = 1;
                        inversiaLight = !inversiaLight;
                    }

                    typeLight = GetType(getIndex);

                    curTimer = 0;
                }
            }
            else
            {
                listTraffictLight[i].targetMesh.enabled = false;
            }
        }
    }

    private DataTrafficLight.TTypeLight GetType(int index)
    {
        if(index == 0)
        {
            return DataTrafficLight.TTypeLight.Red;
        }
        else if(index == 1)
        {
            return DataTrafficLight.TTypeLight.Yellow;
        }
        else
        {
            return DataTrafficLight.TTypeLight.Green;
        }
    }

    private int GetIndex(DataTrafficLight.TTypeLight type)
    {
        if(type == DataTrafficLight.TTypeLight.Red)
        {
            return 0;
        }
        else if(type == DataTrafficLight.TTypeLight.Yellow)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }
}
