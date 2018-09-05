using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Transform laserHit;
    Score score;
	// Use this for initialization
	void Start () {
        score = GameObject.FindObjectOfType(typeof(Score)) as Score;
        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
	}
    
    // Update is called once per frame
    public void shoot () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawLine(transform.position, hit.point);
        
        if (hit)
        {
            laserHit.position = hit.point;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, laserHit.position);
            Destroy(hit.transform.gameObject);
            score.newScore++;
            score.scoreCount = score.scoreCount + 1 + score.newScore;
        }  
        else
        {
            laserHit.position = hit.point;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, transform.up);

            Debug.Log("You missed!");
        }
            
        
	}
}
