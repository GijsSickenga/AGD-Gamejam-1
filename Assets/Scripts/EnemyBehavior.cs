using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public float speed;
    Renderer m_Renderer;
   

    // Use this for initialization
    void Start () {
        m_Renderer = GetComponent<Renderer>();
    }

    

    // Update is called once per frame
    void Update () {

        transform.position += new Vector3 (0, -speed, 0) * Time.deltaTime;
        Vector3 a = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        
        if (transform.position.y < a.y)
        {
            Destroy(gameObject);
                        
        }

    }
}
