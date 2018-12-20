using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundLandingTiles : MonoBehaviour {
    [Header("Audio Source")]
    public AudioSource source;
    [Header("Land Audio Clip")]
    public AudioClip clip;
    [Header("Player Death Clip")]
    public AudioClip deathPlayerClip;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Land")
        { 
            source.PlayOneShot(clip);
        }
        else if(collision.collider.tag == "Player")
        {
            source.PlayOneShot(deathPlayerClip);
        }
    }
}
