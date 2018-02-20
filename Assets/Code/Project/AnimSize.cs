using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimSize : MonoBehaviour
{
    private Transform localTransform;
    private Vector3 defaultSize;
    private Vector3 defaultPos;

    private void Awake()
    {
        localTransform = transform;
        defaultSize = transform.localScale;
        defaultPos = transform.localPosition;

        localTransform.localScale = new Vector3(localTransform.localScale.x, 0.1f, localTransform.localScale.z);
        localTransform.localPosition = new Vector3(localTransform.localPosition.x, 0.05f, localTransform.localPosition.z);
    }

    private void Start()
    {
        StartCoroutine(Anim());
    }

    private IEnumerator Anim()
    {
        while (Mathf.Abs(localTransform.localScale.y - defaultSize.y) >= 0.1f)
        {
            yield return new WaitForEndOfFrame();

            localTransform.localPosition = Vector3.Lerp(localTransform.localPosition, defaultPos, 0.01f);
            localTransform.localScale = Vector3.Lerp(localTransform.localScale, defaultSize, 0.01f);
        }
    }


}
