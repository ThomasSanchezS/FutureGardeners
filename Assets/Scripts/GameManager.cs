using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private  float timer = 180;
    private float timerSaved;

    public int player1Points, player2Points;
    private int bluePlantPoints, whitePlantPoints, redPlantPoints;
    

    public TextMeshProUGUI timerText, blueText, whiteText, redText, points1Text, points2Text, changePointText, startText;

    private void Start()
    {
        timerSaved = timer-30;
        player1Points = 0;
        player2Points = 0;
        FindNewPlantPoints();
        UpdatePlantPoints();
        StartAnimation();
    }

    void Update()
    {
        timer-= Time.deltaTime;

        timerText.text = ((int)timer).ToString() + " Sec";
        points1Text.text = "P2: " + player1Points.ToString();
        points2Text.text = "P1: " + player2Points.ToString();
        ChangePlantPoints();
    }

    private void GameOver(){
        if(timer == 0 && player1Points > player2Points)
        SceneManager.LoadScene("Player1Win");

        if(timer == 0 && player1Points > player2Points){
            SceneManager.LoadScene("Player2Win");
        }
    }

    private void ChangePlantPoints()
    {
        if (timerSaved>= timer)
        {
            FindNewPlantPoints();
            UpdatePlantPoints();
            TextAnimation();
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

    private void UpdateP2P()
    {
        points2Text.text = "P2: " + ((int)player2Points).ToString();
    }

    public void AddBluePP1()
    {
        player1Points += bluePlantPoints;
    }

    public void AddBluePP2()
    {
        player2Points += bluePlantPoints;
    }

    public void AddWhitePP1()
    {
        player1Points += whitePlantPoints;
    }

    public void AddWhitePP2()
    {
        player2Points += whitePlantPoints;
    }

    public void AddRedPP1()
    {
        player1Points += redPlantPoints;
    }

    public void AddRedPP2()
    {
        player2Points += redPlantPoints;
    }


    private void TextAnimation(){
        changePointText.gameObject.SetActive(true);
        StartCoroutine(ShowLine());
    }

    private void StartAnimation(){
        startText.gameObject.SetActive(true);
        StartCoroutine(hideStart());
    }

    private IEnumerator ShowLine(){

        changePointText.text = string.Empty;
        foreach(char ch in "CHANGE OF POINTS PER PLANT"){
            changePointText.text += ch;
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(hideLine());
    }

    private IEnumerator showStart(){
        startText.text = string.Empty;
        foreach(char ch in "START!!!"){
            changePointText.text += ch;
            yield return new WaitForSeconds(2f);
        }
        StartCoroutine(hideStart());
    }

    private IEnumerator hideLine(){
        yield return new WaitForSeconds(1f);
        changePointText.gameObject.SetActive(false);
    }

    private IEnumerator hideStart(){
        yield return new WaitForSeconds(3f);
        startText.gameObject.SetActive(false);
        
    }
}
