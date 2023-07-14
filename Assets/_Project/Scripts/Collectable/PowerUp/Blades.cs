using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;



namespace NoSurrender.Collectable
{
    public class Blades : MonoBehaviour
    {
        [SerializeField] private StatsSO statData;
        private GameObject _player;
        public StatsSO StatData{get{return statData;}}
        
        private void Start()
        {
            
            
        }


        public void PowerUp()
        {
            StartCoroutine(PowerUpEnabled());
        }
        public IEnumerator PowerUpEnabled()
        {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            this.gameObject.transform.GetChild(0).gameObject.transform.DORotate(new Vector3 (0f,5000f,0f), statData.PillBuffDuration, RotateMode.LocalAxisAdd);
            
            yield return new WaitForSecondsRealtime(StatData.PillBuffDuration);

            this.transform.GetChild(0).gameObject.SetActive(false);
            
        
        }

        

        
    }

}
