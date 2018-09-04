using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour {

    public GameObject[] spawners;
    public GameObject enemy;
    private Vector3 spawnPoint;

    public float spawnRate;
<<<<<<< HEAD
    public List <GameObject> enemies;
=======
>>>>>>> 6a8b46f5b4e559ce1e89a74213704cf569c8cff3

    // Use this for initialization
    void Start () {
        Spawn();
    }
	

    public IEnumerator Spawn()
    {
        float f = 1 / spawnRate;
        yield return new WaitForSeconds(f);
        spawnPoint = spawners[Random.Range(0, 4)].transform.position;
        GameObject.Instantiate(enemy, spawnPoint, Quaternion.identity);
        StartCoroutine(Spawn());
    }
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Spawn());
            
        }
        
        
    }
}
