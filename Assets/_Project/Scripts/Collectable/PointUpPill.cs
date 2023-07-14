using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using NoSurrender.Enemy;
using NoSurrender.Control;

namespace NoSurrender.Collectable
{
    public class PointUpPill : MonoBehaviour, ICollectable
    {
        Vector3 addScale = new Vector3(0.1f, 0.1f, 0.1f);
        [SerializeField] private StatsSO statData;
        public StatsSO StatData{get{return statData;}}

       

        
        public void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.CompareTag("Target"))
            {
                if(collider.gameObject.GetComponentInParent<PlayerController>())
                {
                    StatData.Points += 100;
                }
                collider.transform.DOScale(collider.transform.localScale+addScale, 1f);
                Destroy(this.gameObject);
            }
            
            
        }

        private void OnDestroy()
        {
            PillDistanceCheck.RemoveTransform?.Invoke(transform);
        }

        
    }

}
