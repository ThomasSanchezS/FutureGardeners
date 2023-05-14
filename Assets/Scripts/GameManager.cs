using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  float timer = 120;
    private float timerSaved;

    public int player1Points, player2Points;
    private int bluePlantPoints, whitePlantPoints, redPlantPoints;

    public TextMeshProUGUI timerText;

    private void Start()
    {
        timerSaved = timer;
        player1Points = 0;
        player2Points = 0;
    }

    void Update()
    {
        timer-= Time.deltaTime;

        timerText.text = ((int)timer).ToString() + " Sec"; 
    }

    private void ChangePlantPoints()
    {
        bluePlantPoints= 
    }
}
