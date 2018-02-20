using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    public class SingleSpawn : MonoBehaviour
    {
        protected virtual GameObject Spawn(GameObject prefab, Transform parent = null)
        {
            if (!prefab) { return null; }

            GameObject get = GetSpawn(prefab);

            Transform getLocal = get.transform;

            getLocal.SetParent(parent);
            getLocal.localPosition = Vector3.zero;
            getLocal.localRotation = Quaternion.identity;


            return get;
        }

        protected virtual void Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {

        }

        protected virtual void Spawn(GameObject prefab, Vector3 position, Vector3 rotation)
        {

        }

        private GameObject GetSpawn(GameObject prefab)
        {
            return Instantiate(prefab);
        }
    }
}