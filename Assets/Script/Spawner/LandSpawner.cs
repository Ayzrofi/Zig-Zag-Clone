using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSpawner : MonoBehaviour {
    [Header("The First Land")]
    public Vector3 ExtraHigh = new Vector3(0, 1, 0);
    public int StartLand;
    public GameObject currentLand;
    [Header("Land prefabs")]
    public GameObject[] lands;
    [Header("Pick Up Chance")]
    public int PickUpChance;
    // instance the Land Spawner
    private static LandSpawner SpawnerInstance;
    public static LandSpawner landInstance
    {
        get
        {
            if(SpawnerInstance == null)
            {
                SpawnerInstance = FindObjectOfType<LandSpawner>();
            }
            return SpawnerInstance;
        }
    }

    private Stack<GameObject> topLand = new Stack<GameObject>();
    public Stack<GameObject> TopLand
    {
        get
        {
            return topLand;
        }
        set
        {
            topLand = value;
        }
    }

    private Stack<GameObject> leftLand = new Stack<GameObject>();
    public Stack<GameObject> LeftLand
    {
        get
        {
            return leftLand;
        }

        set
        {
            leftLand = value;
        }
    }

  

    private void Start()
    {
        CreateLand(10);
        for (int i = 0; i < StartLand; i++)
        {
            SpawnLand();
        }
    }

    public void CreateLand(int Count)
    {
        for (int i = 0; i < Count; i++)
        {
            topLand.Push(Instantiate(lands[1]));
            leftLand.Push(Instantiate(lands[0]));

            topLand.Peek().name = "Top Land";
            leftLand.Peek().name = "Left Land";

            topLand.Peek().transform.SetParent(transform);
            leftLand.Peek().transform.SetParent(transform);

            topLand.Peek().SetActive(false);
            leftLand.Peek().SetActive(false);
        }
    }

    public void SpawnLand()
    {
        if (topLand.Count == 0 || leftLand.Count == 0)
        {
            CreateLand(10);
        }
        int MakeItRandom = Random.Range(0, 2);
        if (MakeItRandom == 0)
        {
            var temp = leftLand.Pop();
            temp.SetActive(true);
            temp.transform.position = currentLand.transform.GetChild(0).transform.GetChild(MakeItRandom).position + ExtraHigh;
            currentLand = temp;
        }else 
        if (MakeItRandom == 1)
        {
            var temp = topLand.Pop();
            temp.SetActive(true);
            temp.transform.position = currentLand.transform.GetChild(0).transform.GetChild(MakeItRandom).position + ExtraHigh;
            currentLand = temp;
        }

        int SpawnPickUp = Random.Range(0, PickUpChance);
        if(SpawnPickUp == 0)
        {
            currentLand.transform.GetChild(1).transform.GetChild(0).gameObject.SetActive(true);
        }
        //currentLand = (GameObject)Instantiate(lands[MakeItRandom],currentLand.transform.GetChild(0).transform.GetChild(MakeItRandom).position,Quaternion.identity);
        //currentLand.transform.SetParent(transform);
    }

}
