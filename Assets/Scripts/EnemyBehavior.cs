using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float speed;
    Renderer m_Renderer;
<<<<<<< HEAD
    private SpawnSystem spawner;   

    // Use this for initialization
    void Start () {
        spawner = GameObject.Find("Spawner").GetComponent<SpawnSystem>();
        spawner.enemies.Add(gameObject);
=======
   

    // Use this for initialization
    void Start () {
>>>>>>> 6a8b46f5b4e559ce1e89a74213704cf569c8cff3
        m_Renderer = GetComponent<Renderer>();
    }

    

    // Update is called once per frame
    void Update () {

        transform.position += new Vector3 (0, -speed, 0) * Time.deltaTime;
        Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        if (transform.position.y < a.y)
        {
<<<<<<< HEAD
            spawner.enemies.Remove(gameObject);
=======
>>>>>>> 6a8b46f5b4e559ce1e89a74213704cf569c8cff3
            Destroy(gameObject);
                        
        }

    }
}
