using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using NoSurrender.Enemy;


namespace NoSurrender.Collectable
{
    public class PowerUpPill : MonoBehaviour, ICollectable
    {

        

        public void OnTriggerEnter(Collider collider)
        {
            
            if(collider.gameObject.CompareTag("Target"))
            {
                
                collider.gameObject.GetComponent<Blades>().PowerUp();
                Destroy(this.gameObject);
            }
            
            
        }

        private void OnDestroy()
        {
            PillDistanceCheck.RemoveTransform?.Invoke(transform);
        }

    }
}
