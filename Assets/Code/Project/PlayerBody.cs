using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class PlayerBody : MonoBehaviour
{

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            GameManager.Instance.AddCrash();
        }
    }
}
