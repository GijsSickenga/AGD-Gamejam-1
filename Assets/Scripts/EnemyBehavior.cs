using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float speed;
    Renderer m_Renderer;
    Score score;
    private SpawnSystem spawner;   

    // Use this for initialization
    void Start () {
        spawner = GameObject.Find("Spawner").GetComponent<SpawnSystem>();
        spawner.enemies.Add(gameObject);
        score = GameObject.FindObjectOfType(typeof(Score)) as Score;

    }

    private void OnDestroy()
    {
        spawner.enemies.Remove(gameObject);
    }

    // Update is called once per frame
    void Update () {

        transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
        Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        if (transform.position.x > a.x ) 
        {
            Destroy(gameObject);
        }
        
    }
}