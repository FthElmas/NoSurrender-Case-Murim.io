using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace NoSurrender.Enemy
{
    public class PillDistanceCheck : MonoBehaviour
    {
        
        private EnemyAI _enemy;
        Transform currentTarget;
        public List<Transform> pills = new List<Transform>();
        private float checkTimer;
        public static Action<Transform> RemoveTransform;


        private void Awake()
        {
            

            _enemy = GetComponentInParent<EnemyAI>();
        }

        private void OnEnable()
        {
            RemoveTransform += RemoveFromList;
        }
        private void OnDisable()
        {
            RemoveTransform -= RemoveFromList;
        }

        private void Update()
        {
            if(Time.time > checkTimer + 0.5f)
            {
                checkTimer = Time.time;
                NearestPillCheck();
                
            }
        }

        public Transform GetCurrentTarget()
        {
            return currentTarget;
        }

        public void SetCurrentTarget(Transform transform)
        {
            currentTarget = transform;
        }

        private void NearestPillCheck()
        {
            Transform nearestTransform = default;
            float shortestDistance = Mathf.Infinity;

            foreach(var pill in pills)
            {
                if(pill == null) continue;
                float currentDistance = Vector3.Distance(transform.position, pill.position);
                
                if(shortestDistance > currentDistance)
                {
                    shortestDistance = currentDistance;
                    nearestTransform = pill;
                }
            }
            if(currentTarget != nearestTransform)
            {
                currentTarget = nearestTransform;
                
            }
            

        }

        private void RemoveFromList(Transform transform)
        {
            if(pills.Contains(transform))
                {
                    pills.Remove(transform);
                }
        }

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("Pill"))
            {
                pills.Add(collider.transform);
                _enemy.SetPillStatus(true);
            }
        }
        private void OnTriggerExit(Collider collider)
        {
            if(collider.gameObject.CompareTag("Pill"))
            {
                if(pills.Contains(collider.transform))
                {
                    pills.Remove(collider.transform);
                }
                _enemy.SetPillStatus(false);
            }
        }
    }

}
