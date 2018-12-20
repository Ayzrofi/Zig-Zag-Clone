using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour {
    public Animator anim;
    public AudioSource Sound;
    public AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(CoinIsPickUp());
        }
    }

    IEnumerator CoinIsPickUp()
    {
        Sound.PlayOneShot(clip);
        anim.SetTrigger("IsPickUp");
        ScoreManajer.ScoreInstance.AddScore(3);
        yield return new WaitForSeconds(1.5f);
        gameObject.SetActive(false);
    }
}
