using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {
    public Animator animator;
    public AudioSource audio, audioBGM;
    public AudioClip clip;
    public Text HighScoreText;
    private void Start()
    {
        HighScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void PlayGame()
    {
        StartCoroutine(PlayGameTransisi());
    }
    IEnumerator PlayGameTransisi()
    {
        audioBGM.Stop();
        animator.SetTrigger("Play");
        audio.PlayOneShot(clip);
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        StartCoroutine(TransisiExitGame());
    }
    IEnumerator TransisiExitGame()
    {
        audioBGM.Stop();
        animator.SetTrigger("Play");
        audio.PlayOneShot(clip);
        yield return new WaitForSecondsRealtime(2.5f);
        Application.Quit();
    }

}
