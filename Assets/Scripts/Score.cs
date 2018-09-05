using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public Text score;
    public int scoreCount;
    public int newScore;
    public Text multiplier;
    public Text lifeCount;
    public int scoreMultiplier = 0;
    public int life;
    public int startingHealth = 50;                            // The amount of health the player starts the game with.
    
    public Slider healthSlider;                                 // Reference to the UI's health bar.

    // Use this for initialization
    void Start()
    {
        scoreCount = 0;
        newScore = 0;
        life = startingHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = life;
        score.text = "Score: " + scoreCount;
        multiplier.text = "X " + scoreMultiplier;
        lifeCount.text = "life " + scoreMultiplier;
        if (life <= 0) {
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Additive);
        }
    }
}