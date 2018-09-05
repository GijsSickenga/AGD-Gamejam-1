using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text score;
    public int scoreCount;
    public int newScore;
    // Use this for initialization
    void Start()
    {
        scoreCount = 0;
        newScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:" + " " + scoreCount;
    }
}