using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public  float timer = 180;
    private float timerSaved;

    public int player1Points, player2Points;
    private int bluePlantPoints, whitePlantPoints, redPlantPoints;

    public TextMeshProUGUI timerText, blueText, whiteText, redText, player1Text, player2Text;

    private void Start()
    {
        timerSaved = timer-30;
        player1Points = 0;
        player2Points = 0;
        UpdateP1P();
        UpdateP2P();
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
    private void UpdateP1P(
        )
    {
        player1Text.text = player1Points.ToString();
    }
    private void UpdateP2P()
    {
        player2Text.text = player2Points.ToString();
    }

    public void AddBluePP1()
    {
        player1Points += bluePlantPoints;
        UpdateP1P();
    }

    public void AddBluePP2()
    {
        player2Points += bluePlantPoints;
        UpdateP2P();
    }

    public void AddWhitePP1() 
    {
        player1Points+= whitePlantPoints;
        UpdateP1P();
    }

    public void AddWhitePP2()
    {
      player2Points+= whitePlantPoints;
        UpdateP2P();
    }

    public void AddRedPP1()
    {
        player1Points+= redPlantPoints;
        UpdateP1P();
    }

    public void AddRedPP2()
    {
        player2Points+= redPlantPoints;
        UpdateP2P();
    }


}
