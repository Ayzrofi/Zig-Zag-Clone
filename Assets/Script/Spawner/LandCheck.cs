using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCheck : MonoBehaviour {
    //Rigidbody rb;
    BoxCollider Col;
    private void Start()
    {
        Col = gameObject.transform.GetChild(0).GetComponent<BoxCollider>();
        //rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(FallingTheLand());
            LandSpawner.landInstance.SpawnLand();
            ScoreManajer.ScoreInstance.AddScore(1);
        }
    }

    IEnumerator FallingTheLand()
    {
        yield return new WaitForSeconds(.01f);
        //rb.isKinematic = false;
        Col.isTrigger = true;
        yield return new WaitForSeconds(1.2f);
        switch (gameObject.name)
        {
            case "Top Land":
                LandSpawner.landInstance.TopLand.Push(gameObject);
                //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
                gameObject.SetActive(false);
                break;
            case "Left Land":
                LandSpawner.landInstance.LeftLand.Push(gameObject);
                //gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
                gameObject.SetActive(false);
                break;
        }
    }

}// end Class










