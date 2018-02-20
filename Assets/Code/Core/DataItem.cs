using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paradigm
{
    [System.Serializable]
    public class DataItem
    {
        [Header("System")]
        public int id;
        public int requiredId = 999;
        public int cost;
        public bool buy;

        public bool Buy(List<DataItem> listData)
        {
            if (buy) { return false; }
            if (Globals.Instance.coreProfile.money < cost) { return false; }
            if (requiredId != 999 && !listData[requiredId].buy) { return false; }

            Globals.Instance.coreProfile.money -= cost;
            buy = true;

            Globals.Instance.Save();

            return true;
        }

        public bool Price(List<DataItem> listData)
        {
            if (Globals.Instance.coreProfile.money < cost)
            {
                return false;
            }
            else
            {
                if (requiredId != 999 && !listData[requiredId].buy)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}