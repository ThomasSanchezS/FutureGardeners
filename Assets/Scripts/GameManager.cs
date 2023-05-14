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

    public TextMeshProUGUI timerText, blueText, whiteText, redText;

    private void Start()
    {
        timerSaved = timer-30;
        player1Points = 0;
        player2Points = 0;
        FindNewPlantPoints();
        UpdatePlantPoints();
    }

    void Update()
    {
        timer-= Time.deltaTime;

        timerText.text = ((int)timer).ToString() + " Sec";

        ChangePlantPoints();
    }

    private void ChangePlantPoints()
    {
        if (timerSaved>= timer)
        {
            FindNewPlantPoints();
            UpdatePlantPoints();
            timerSaved -= 30;
        }
    }

    private void UpdatePlantPoints()
    {
        blueText.text = bluePlantPoints.ToString();
        whiteText.text = whitePlantPoints.ToString();
        redText.text = redPlantPoints.ToString();
    }


    private void FindNewPlantPoints()
    {
        bluePlantPoints = (int)Random.Range(1, 4);

        whitePlantPoints = bluePlantPoints;

        while (bluePlantPoints == whitePlantPoints)
        {
            whitePlantPoints = (int)Random.Range(1, 4);
        }
        redPlantPoints = bluePlantPoints;

        while(bluePlantPoints == redPlantPoints || redPlantPoints == whitePlantPoints)
        {
            redPlantPoints= (int)Random.Range(1, 4); ;
        }
    }
}
