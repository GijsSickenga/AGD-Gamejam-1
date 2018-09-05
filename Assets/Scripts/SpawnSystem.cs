using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject enemy;
    private Vector3 spawnPoint;

    float spawnTime = 5f;

    float spawnTimePassed = Time.time ;

    public float spawnRate;

    public List <GameObject> enemies;


    // Use this for initialization
    void Start () {
        Spawn();
    }
	

    public IEnumerator Spawn()
    {
        float f = 1 / spawnRate;
        yield return new WaitForSeconds(f);
        spawnPoint = spawners[Random.Range(0, 4)].transform.position;
        GameObject.Instantiate(enemy, spawnPoint, Quaternion.Euler(0, 0, 90));
        StartCoroutine(Spawn());
    }
	// Update is called once per frame
	void Update () {

        if (spawnTime < spawnTimePassed)
        {
            StartCoroutine(Spawn());
            spawnTime += 5;
        }

        else

        {
            spawnTime--;
        }
        
    }
}
