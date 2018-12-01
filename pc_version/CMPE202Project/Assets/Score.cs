using UnityEngine;
using UnityEngine.UI;

public class Score {

    private int score;
    public Text scoreText;
    
    public void setScoreText(Text scorein)
    {
        scoreText = scorein;
        score = 0;
    }

    public void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void addScore(int value) {
        score += value;
        UpdateScore();
    }

    public int getScore() {
        return score;
    }

}
