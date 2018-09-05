<<<<<<< HEAD
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float speed;
    Renderer m_Renderer;

    private SpawnSystem spawner;   

    // Use this for initialization
    void Start () {
        spawner = GameObject.Find("Spawner").GetComponent<SpawnSystem>();
        spawner.enemies.Add(gameObject);

    }

    

    // Update is called once per frame
    void Update () {

        transform.position += new Vector3 (speed, 0, 0) * Time.deltaTime;
        Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        if (transform.position.x < a.x)
        {

            spawner.enemies.Remove(gameObject);

            Destroy(gameObject);
                        
        }

    }
}
=======
﻿using System.Collections;
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

        transform.position += new Vector3 (0, -speed, 0) * Time.deltaTime;
        Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        if (transform.position.y < a.y)
        {

            
            score.newScore = 0;
            Destroy(gameObject);
                        
        }

    }
}
>>>>>>> d48723ec00c96e29146b651380136a26dc8c1f97
