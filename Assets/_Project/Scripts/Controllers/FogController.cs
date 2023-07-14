using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoSurrender.Control
{
    public class FogController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("Target"))
            {
                
            }
        }
    }

}
