using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSystem : MonoBehaviour
{
    public List<GameObject> spawners = new List<GameObject>();
    public GameObject enemy;
    
    private float nextActionTime = 1f;
    float period = 1f;

    public float spawnRate;

    public List<GameObject> enemies;

    public Score scoreManager;

    public IEnumerator Spawn()
    {
        float f = 1 / spawnRate;
        yield return new WaitForSeconds(f);
        GameObject spawner = spawners[Random.Range(0, spawners.Count)];
        GameObject newEnemy = GameObject.Instantiate(enemy, spawner.transform.position, Quaternion.Euler(0, 0, 90));
        EnemyBehavior enemyBehaviour = newEnemy.GetComponent<EnemyBehavior>();
        enemyBehaviour.score = scoreManager;

        // Scale enemy to fit the lane it's on.
        newEnemy.transform.localScale = new Vector3(spawner.transform.parent.localScale.y,
                                                    spawner.transform.parent.localScale.y,
                                                    1);

        // Scale enemy speed based on ship size.
        enemyBehaviour.speed = 2 * newEnemy.transform.localScale.x;
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
