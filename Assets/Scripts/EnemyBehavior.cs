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
            Explode();
            Destroy(gameObject);
        }
        
    }
    public ParticleSystem DestructionEffect; //assign prefab in editor or elsewhere
                                             //in code
    public void Explode()
    {
        //Instantiate our one-off particle system
        ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                         as ParticleSystem;
        explosionEffect.transform.position = transform.position;
        //play it
        explosionEffect.loop = false;
        explosionEffect.Play();

        //destroy the particle system when its duration is up, right
        //it would play a second time.
        Destroy(explosionEffect.gameObject, explosionEffect.duration);

        Destroy(gameObject);

    }
}