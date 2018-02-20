using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public class TriggerView2D : CoreVisible
    {
        protected virtual void OnTriggerEnter2D(Collider2D collision)
        {
            OnEnter(collision.transform);
        }

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            OnEnter(collision.collider.transform);
        }

        protected virtual void OnCollisionExit2D(Collision2D collision)
        {
            OnExit(collision.collider.transform);
        }

        protected virtual void OnTriggerExit2D(Collider2D collision)
        {
            OnExit(collision.transform);
        }
    }
}