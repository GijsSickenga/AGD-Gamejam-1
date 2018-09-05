using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour {

    public LineRenderer lineRenderer;
    public Transform laserHit;
    EnemyBehavior enemy;
    Score score;
	// Use this for initialization
	void Start () {
        Debug.Log("Hier dan ook right???");
        score = GameObject.FindObjectOfType(typeof(Score)) as Score;
        enemy = GameObject.FindObjectOfType(typeof(EnemyBehavior)) as EnemyBehavior;
        lineRenderer = GetComponent<LineRenderer>();
        //lineRenderer.enabled = false;
        lineRenderer.useWorldSpace = true;
	}
    
    // Update is called once per frame
    public void shoot () {
       
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        if (hit)
        {
            laserHit.position = hit.point;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, laserHit.position);

            enemy = hit.transform.gameObject.GetComponent<EnemyBehavior>();
            enemy.Explode();

            score.life++;
            score.scoreMultiplier++;
            score.scoreCount = score.scoreCount + 3 * score.scoreMultiplier;

            Destroy(hit.transform.gameObject);
        }  
        else
        {
            score.scoreMultiplier = 0;
            score.life -= 10;
            Vector2 up = new Vector2(- 7.5f, transform.position.y);
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, up);
        }
	}

    
}
