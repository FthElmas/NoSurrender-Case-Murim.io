using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointUI : MonoBehaviour
{
    [SerializeField] private StatsSO statData;
    public StatsSO StatData{get{return statData;}}
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }
    private void Update()
    {
        _text = GetComponent<Text>();
        _text.text = StatData.Points.ToString();
    }
}
