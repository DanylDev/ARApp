using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paradigm;

public class FinishTrigger : MonoBehaviour
{
    public enum TType
    {
        Finish,
        RefreshGame,
        Next
    }

    public BoxCollider bCollider;
    public MeshRenderer mRenderer;
    public ParadigmControl paradigmControl;

    public TType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            switch (type)
            {
                case TType.Finish:
                    GameManager.Instance.BackGame();
                    paradigmControl.ResetTriggres();
                    return;

                case TType.RefreshGame:
                    GameManager.Instance.StopGame();
                    return;

                case TType.Next:
                    paradigmControl.NextTrigger();
                    return;
            }
        }
    }

    private void Set(bool state)
    {
        bCollider.enabled = state;
        mRenderer.enabled = state;
    }
}
