using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour {
    [Header("Player Attribute")]
    public Transform Player;
    public float PlayerYDeathPos;
    [Header("Death Menu ")]
    public GameObject deathMenu;
    public GameObject allGameObj;
    public GameObject NewHighScoreLabel;
    public Text FinalScoreText;
    public Text HighScoreText;

    [HideInInspector]
    public bool gameOver;
    private static Death death;

    public static Death DeathPlayer
    {
        get
        {
            if (death == null)
            {
                death = FindObjectOfType<Death>();
            }
            return death;
        }
    }
    private void Start()
    {
        deathMenu.SetActive(false);
        allGameObj.SetActive(true);
    }

    private void Update()
    {
        if (gameOver)
            return;

        if (Player.transform.position.y <= PlayerYDeathPos)
        {
            playerDeath();
        }
    }

    void playerDeath()
    {
        gameOver = true;
        StartCoroutine(DisplayDeathMenu());
        Debug.Log("Death");
    }

    IEnumerator DisplayDeathMenu()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        FinalScoreText.text = ScoreManajer.ScoreInstance.Score.ToString();
        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        deathMenu.SetActive(true);
        allGameObj.SetActive(false);
    }
}
