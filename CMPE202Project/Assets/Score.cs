using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score {

    private int score;
    public Text scoreText;
    List<Observer> list = new List<Observer>();
    private bool firstReach = false;
    private bool secondReach = false;
    private bool thirdReach = false;

    public void attach(Observer observer) {
        list.Add(observer);
    }

    public void notify() {
        foreach (var observer in list) {
            observer.update();
        }
    }

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
        if (score >= 150 && !firstReach && score < 300) {
            notify();
            firstReach = true;
        } else if (score >= 300 && !secondReach && score < 560) {
            notify();
            secondReach = true;
        }else if (score >= 560 && !thirdReach && score < 1400){
            notify();
            thirdReach = true;
        }
        UpdateScore();
    }

    public int getScore() {
        return score;
    }

}
