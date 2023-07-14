using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NoSurrender.Control;

namespace NoSurrender.Managers
{
    public class UIManager : MonoBehaviour
    {
        ObjectPooler EnemyPool;
        PlayerController Player;

        GameObject StartGameUI;
        GameObject GameOver;
        GameObject InGameUI;
        GameObject PauseMenu;
        GameObject WinnerUI;
        private void Awake()
        {
            EnemyPool = GameObject.FindObjectOfType<ObjectPooler>();
            Player = GameObject.FindObjectOfType<PlayerController>();
            StartGameUI = transform.GetChild(0).GetChild(0).gameObject;
            InGameUI = transform.GetChild(0).GetChild(1).gameObject;
            PauseMenu = transform.GetChild(0).GetChild(2).gameObject;
            GameOver = transform.GetChild(0).GetChild(3).gameObject;
            WinnerUI = transform.GetChild(0).GetChild(4).gameObject;
        }

        private void Update()
        {
            GameOverUI();
            WinnerScreen();

            if(Input.GetButtonDown("Fire1"))
            {
                
                StartGameUI.SetActive(false);
                InGameUI.SetActive(true);
                
            }
        }
        
        public void GameOverUI()
        {
            if(Player == null)
            {
                InGameUI.SetActive(false);
                GameOver.SetActive(true);
            }
        }

        public void WinnerScreen()
        {
            if(EnemyPool.AreEnemiesDead())
            {
                InGameUI.SetActive(false);
                WinnerUI.SetActive(true);
            }
        }

        public void ResumeGameUI()
        {
            PauseMenu.SetActive(false);
            InGameUI.SetActive(true);
        }
        public void PauseGameUI()
        {
            InGameUI.SetActive(false);
            PauseMenu.SetActive(true);
        }
        
    }

}
