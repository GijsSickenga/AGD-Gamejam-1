using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{

    public GameObject[] spawners;
    public GameObject enemy;
    private Vector3 spawnPoint;
    
    private float nextActionTime = 1f;
    float period = 1f;


    public float spawnRate;

    public List<GameObject> enemies;

    public Score scoreManager;


    // Use this for initialization


    void Start () {
    }


    public IEnumerator Spawn()
    {
        float f = 1 / spawnRate;
        yield return new WaitForSeconds(f);
        spawnPoint = spawners[Random.Range(0, 4)].transform.position;
        GameObject newEnemy = GameObject.Instantiate(enemy, spawnPoint, Quaternion.Euler(0, 0, 90));
        newEnemy.GetComponent<EnemyBehavior>().score = scoreManager;
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            StartCoroutine(Spawn());
            if(period > 0.3)
            period *= 0.99f;
        }

        Debug.Log(period);
    }
    

}
