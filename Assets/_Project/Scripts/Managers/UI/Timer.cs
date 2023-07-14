using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float TimeLeft;
    public bool IsTimerOn = false;

    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }


    private void Update()
    {
        _text = GetComponent<Text>();
        if(IsTimerOn)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                UpdateTimer(TimeLeft);
            }
            else
            {
                TimeLeft = 0;
                IsTimerOn = false;
            }
        }
    }
    void UpdateTimer(float currentTime)
    {
        currentTime +=1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        _text.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void SetTimerOn(bool isTimerOn)
    {
        IsTimerOn = isTimerOn;
    }

}
