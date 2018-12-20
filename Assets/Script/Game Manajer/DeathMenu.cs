using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathMenu : MonoBehaviour
{
    public AudioSource audio,audioBGM;
    public AudioClip clip;
    public Animator anim;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            StartCoroutine(TransisiToMenu());
        }
    }
    public void ToMenu()
    {
        StartCoroutine(TransisiToMenu());
    }
    IEnumerator TransisiToMenu()
    {
        audioBGM.Stop();
        anim.SetTrigger("Play");
        audio.PlayOneShot(clip);
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene("Menu");
    }
    public void PlayAgain()
    {
        StartCoroutine(PlayAgainTransition());
    }
    IEnumerator PlayAgainTransition()
    {
        audioBGM.Stop();
        anim.SetTrigger("Play");
        audio.PlayOneShot(clip);
        yield return new WaitForSecondsRealtime(2.5f);
        Application.LoadLevel(Application.loadedLevel);
    }
    public void ExitGame()
    {
        StartCoroutine(TransisiExitGame());
    }
    IEnumerator TransisiExitGame()
    {
        audioBGM.Stop();
        anim.SetTrigger("Play");
        audio.PlayOneShot(clip);
        yield return new WaitForSecondsRealtime(2.5f);
        Application.Quit();
    }
}
