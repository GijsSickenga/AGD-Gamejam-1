
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponMovement : MonoBehaviour {

    Vector3 newPosition;
    public float shootTime = 0.05f;
    float timeLeft;
    Laser ns;
    // Use this for initialization
    void Start () {
        Vector3 newPosition = transform.position;
        ns = GameObject.FindObjectOfType(typeof(Laser)) as Laser;
        timeLeft = shootTime;
        Debug.Log("Komt hier wel right?");
    }

    bool shoot;
    
    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            shoot = true;
            
            newPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            ns.shoot();
            ns.lineRenderer.enabled = true;

            //
        }
        if(shoot)
        {
            timeLeft -= Time.deltaTime;
           
            if (timeLeft < 0)
            {
                timeLeft = shootTime;
                ns.lineRenderer.enabled = false;
                shoot = false;
            }
        }
        

    }
}
