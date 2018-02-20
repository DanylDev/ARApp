using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public class CoreTrigger2D : CoreVisible
    {
        #region Unity

        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            OnEnter(col.transform);
        }

        protected virtual void OnTriggerExit2D(Collider2D col)
        {
            OnExit(col.transform);
        }

        #endregion
    }
}