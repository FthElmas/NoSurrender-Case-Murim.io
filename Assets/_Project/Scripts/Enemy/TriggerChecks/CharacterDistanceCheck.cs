using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace NoSurrender.Enemy
{
    public class CharacterDistanceCheck : MonoBehaviour
    {
        public List<Transform> characters = new List<Transform>();
        private EnemyAI _enemy;
        Transform currentTarget;
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
                NearestCharacterCheck();
                
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

        
        public void NearestCharacterCheck()
        {
            Transform nearestTransform = default;
            float shortestDistance = Mathf.Infinity;

            foreach(var character in characters)
            {
                if(character == null) continue;
                float currentDistance = Vector3.Distance(transform.position, character.position);
                
                if(shortestDistance > currentDistance)
                {
                    shortestDistance = currentDistance;
                    nearestTransform = character;
                    
                }
            }
            if(currentTarget != nearestTransform)
            {
                currentTarget = nearestTransform;
                
            }
                
            

        }

        private void RemoveFromList(Transform transform)
        {
            if(characters.Contains(transform))
                {
                    characters.Remove(transform);
                }
        }

        
        

        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("Target"))
            {
                characters.Add(collider.transform);
                _enemy.SetCharacterRangeStatus(true);
            }
        }
        private void OnTriggerExit(Collider collider)
        {
            if(collider.gameObject.CompareTag("Target"))
            {
                if(characters.Contains(collider.transform))
                {
                    characters.Remove(collider.transform);
                }
                _enemy.SetCharacterRangeStatus(false);
            }
        }
    }

}
