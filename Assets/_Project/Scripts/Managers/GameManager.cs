using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using NoSurrender.Control;

namespace NoSurrender.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private StatsSO statData;
        public StatsSO StatData{get{return statData;}}


       
        Timer _timer;
        
        

        private void Awake()
        {
            _timer = GameObject.FindAnyObjectByType<Timer>();
        }
        private void Start()
        {
            Time.timeScale = 0;
            
        } 


        private void Update()
        {
            _timer = GameObject.FindAnyObjectByType<Timer>();
            StartGame();
        }

        public void StartGame()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Time.timeScale = 1;
                
                
                _timer.SetTimerOn(true);
            }
        }

        public void PauseGame()
        {
            Time.timeScale = 0;
        }
        public void ResumeGame()
        {
            Time.timeScale = 1;
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(0);
            StatData.Points = 0;
        }
        

        public void QuitGame()
        {
            Application.Quit();
        }

        
    }

}
