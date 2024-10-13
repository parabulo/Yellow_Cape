using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair_Logic : MonoBehaviour {

    private Vector3 mousePosition;
    public float moveSpeed = 1.8f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        FollowCursor();
    }

    //Movimento de cursor
    void FollowCursor(){
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
}