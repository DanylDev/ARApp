using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignPoint : MonoBehaviour
{
    public List<Transform> listTwoBeetwen = new List<Transform>();

    public Transform _one;
    public Transform _two;
    public Transform _wall;

    public LineRenderer LRenderer;

    public void Initialization(Transform one, Transform two, Transform wall)
    {
        _one = one;
        _two = two;
        _wall = wall;

        if (_one && _two)
        {
            LRenderer.SetPosition(0, _one.position);
            LRenderer.SetPosition(1, _two.position);

            if (_wall)
            {
                Vector3 newPos = _two.position + (_one.position - _two.position) / 2;
                newPos.y = _one.position.y + (_wall.localScale.y / 2);

                _wall.position = newPos;
            }

            LRenderer.enabled = true;
        }
        else
        {
            LRenderer.enabled = false;
        }
    }

    private void SSSUpdate()
    {
        if (_one && _two)
        {
            LRenderer.SetPosition(0, _one.position);
            LRenderer.SetPosition(1, _two.position);

            if(_wall)
            {
                Vector3 newPos = _two.position + (_one.position - _two.position) / 2;
                newPos.y = _one.position.y + (_wall.localScale.y / 2);

                _wall.position = newPos;
            }

            LRenderer.enabled = true;
        }
        else
        {
            LRenderer.enabled = false;
        }
    }
}
