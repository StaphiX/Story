using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnityExtentions
{
    public static class MonoBehaviourExtensions
    {
        public static void SetActive(this MonoBehaviour script, bool bActive)
        {
            script.gameObject.SetActive(bActive);
        }
    }
}
