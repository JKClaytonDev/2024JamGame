using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class scoreMenu : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "SCORE: " + PlayerPrefs.GetInt("CurrentScore") + "\nHIGHSCORE: " + PlayerPrefs.GetInt("Highscore");
        if (PlayerPrefs.GetInt("CurrentScore") > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("CurrentScore"));
    }
}
