using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMove : MonoBehaviour {

    [Header("The Player Speed")]
    public float Speed;
    private Vector3 MoveDir;
    private bool MoveLeft ;
    [Header("Player Animations")]
    public Animator anim;
    [Header("Player Sound")]
    public AudioSource audioSc;
    public AudioClip[] clip;

    private BoxCollider PlayerCol;

    private void Start()
    { 
        MoveDir = Vector3.zero;
        PlayerCol = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Death.DeathPlayer.gameOver)
        {
            StartCoroutine(p_Death());
            return;
        }
            

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("IsRun");
            MoveLeft = !MoveLeft;
            if (MoveLeft)
            {
                int Rand = Random.Range(0, clip.Length);
                audioSc.PlayOneShot(clip[Rand]);
                MoveDir = Vector3.left;
                transform.GetChild(0).Rotate(0, -90, 0);
            }
            else
            {
                int Rand = Random.Range(0, clip.Length);
                audioSc.PlayOneShot(clip[Rand]);
                MoveDir = Vector3.forward;
                transform.GetChild(0).Rotate(0, 90, 0);
            }
            //if (MoveDir == Vector3.left)
            //{
            //    MoveDir = Vector3.forward;
            //    transform.GetChild(0).Rotate(0, 90, 0);

            //}
            //else
            //{
            //    MoveDir = Vector3.left;
            //    transform.GetChild(0).Rotate(0, -90, 0);
            //}
        }
        var MoveSpeed = Speed * Time.deltaTime;
        transform.Translate(MoveDir * MoveSpeed);
    }

     IEnumerator p_Death()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSecondsRealtime(1f);
        PlayerCol.isTrigger = true;
    }
}// end classs
















