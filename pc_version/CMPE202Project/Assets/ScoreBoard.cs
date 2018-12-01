using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard
{
    public static GameObject scoreboard;

    private int score;
    public Score scoreClass;

    private int bullet;
    public Bullet bulletClass;

    public void setScoreBoard(GameObject boardin, Text scorein, Text bulletin)
    {
        scoreboard = boardin;
        scoreClass = new Score();
        bulletClass = new Bullet();
        scoreClass.setScoreText(scorein);
        bulletClass.setBulletText(bulletin);
    }

    public void UpdateBoard(){
        scoreClass.UpdateScore();
        bulletClass.UpdateBullet();
    }

    public void addScore(int value) {
        scoreClass.addScore(value);
    }

    public int getScore() {
        return scoreClass.getScore();
    }

    public void addBullet(int value) {
        bulletClass.addBullet(value);
    }

    public int getBullet() {
        return bulletClass.getBullet();
    }

}

