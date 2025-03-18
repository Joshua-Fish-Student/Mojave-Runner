using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public float timer = 0f;
    public float timerRate = 1f;

    public Text scoreDisplay;
    public Text highScoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        if(!(highScore == 0)){
            highScoreDisplay.text = $"HighScore: {highScore}";
        }
        
    }

    void OnDestroy(){
        PlayerPrefs.SetInt("HighScore", highScore);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime * timerRate;

        if (timer >= 1f){
            score++;
            scoreDisplay.text = "Score: " + score.ToString();
            timer = 0f;

            if (score > highScore){
                highScore = score;
                highScoreDisplay.text = "New HighScore!";
            }
        }
    }
}
