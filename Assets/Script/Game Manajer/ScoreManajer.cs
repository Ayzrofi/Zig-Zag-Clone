using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManajer : MonoBehaviour {
   
    public int Score;
    public Text ScoreText;
    private static ScoreManajer scoreInstance;
    public static ScoreManajer ScoreInstance
    {
        get
        {
            if (scoreInstance == null)
                scoreInstance = FindObjectOfType<ScoreManajer>();
            return scoreInstance;
        }
    }

    private void Start()
    {
        Score = 0;
        ScoreText.text = "Score : " + Score.ToString();
        //if (scoreInstance == null)
        //{
        //    scoreInstance = this;
        //    DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
    public void AddScore(int ammountScore)
    {
        Score += ammountScore;
        ScoreText.text = "Score : " + Score.ToString();
        if(Score > PlayerPrefs.GetInt("HighScore"))
        {
            Death.DeathPlayer.NewHighScoreLabel.SetActive(true);
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
