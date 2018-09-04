using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponMovement : MonoBehaviour {

    Vector3 newPosition;
    // Use this for initialization
    void Start () {
        Vector3 newPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            newPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
        }
	}
}
