using UnityEngine;
using System.Collections;

public  class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 jarak;
	// Use this for initialization
	void Start () {
        jarak = transform.position - target.position;
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 posisiTarget = target.position + jarak;
        posisiTarget.y = transform.position.y;
        transform.position = posisiTarget;
        //posisiTarget.y = 0;
        //transform.position =  Vector3.LerpUnclamped(transform.position, posisiTarget, Time.deltaTime);
	
	}
}
