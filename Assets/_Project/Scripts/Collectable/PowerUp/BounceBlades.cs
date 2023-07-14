using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NoSurrender.Collectable
{
    public class BounceBlades : MonoBehaviour
    {
        [SerializeField] private StatsSO statData;
        public StatsSO StatData{get{return statData;}}
        Rigidbody rb;
        
        private void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            
            // Calculate the direction of the collision
            Vector3 collisionDirection = transform.position - collision.contacts[0].point;
            collisionDirection.y = 0f;
            collisionDirection.Normalize();

            // Apply bounce force to both objects
            rb.AddForce(collisionDirection * StatData.Speed, ForceMode.Impulse);
            collision.rigidbody.AddForce(-collisionDirection * StatData.Speed, ForceMode.Impulse);
        
        }
    }

}
