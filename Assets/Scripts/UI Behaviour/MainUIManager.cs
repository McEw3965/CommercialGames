using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MainUIManager : MonoBehaviour
{
    public GameObject ratingHeader;
    public TextMeshProUGUI ratingValue; //for the current game
    public float rating = 0;

    //this is for information when the game over menu comes up:
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI highestScore;



    private void Start()
    {
        highestScore.text = "HighScore: " + PlayerPrefs.GetFloat("HighScore", 0).ToString();
    }


    void Update()
    {
        ratingValue.text = rating.ToString();
    }

    public void AdjustScore(float score)
    {
        rating += score;
        ratingValue.color = Color.green;
        ratingHeader.SetActive(true);
    }

    public void overallScore()
    {
        currentScore.text = "Score: " + rating.ToString();
        if (rating > PlayerPrefs.GetFloat("HighScore", 0)) //if the rating is better than the highest score, we need a new high score
        {
            PlayerPrefs.SetFloat("HighScore", rating);
            highestScore.text = "HighScore: " + rating.ToString();

        }
      
    }

    public void resetHighscore()
    {
        PlayerPrefs.DeleteKey("HighScore"); //this will reset score to 0
        highestScore.text = "HighScore: 0";
    }
}
