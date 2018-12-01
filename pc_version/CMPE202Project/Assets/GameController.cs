using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameController : MonoBehaviour {
    //public GameObject hazard;
    //public GameObject enemy;
    public Vector3 spawnValue;
    private int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text gameOverText;
    private bool gameOver;

    public Text restartText;
    private bool restart;

    public Text startText;
    private static bool start;

    private int hazardType;

    public GameObject hazard1, hazard2, hazard3, hazard4;

    public GameObject scoreboard;

    public Text scoreText;
    public Text bulletText;

    public ScoreBoard sb;

    // Use this for initialization
    void Start () {
        hazardType = 1;
        hazardCount = 20;
        spawnWait = 0.3f;
        gameOverText.text = "";
        gameOver = false;
        restartText.text = "";
        restart = false;
        startText.text = "";
        new HazardOneFactory().setHazard(hazard1);
        new HazardTwoFactory().setHazard(hazard2);
        new HazardThreeFactory().setHazard(hazard3);
        new HazardFourFactory().setHazard(hazard4);
        sb = new ScoreBoard();
        sb.setScoreBoard(scoreboard,scoreText,bulletText);
        if (!start) {
            startText.text = "Press R to Start";
        }  
        if (start) {
            sb.UpdateBoard();
            StartCoroutine(SpawnWaves());
        }
	}

    public void addScore(int value) {
        sb.addScore(value);
    }

    public void addBullet(int value) {
        sb.addBullet(value);
    }

    public bool getStart() {
        return start;
    }

    public int getScore() {
        return sb.getScore();
    }

    public int getBullet() {
        return sb.getBullet();
    }

    IEnumerator SpawnWaves() {


        yield return new WaitForSeconds(startWait);
        while (true) {
            HazardFactory factory;
            if (sb.scoreClass.getScore() >= 150 && sb.scoreClass.getScore() < 300)
            {
                hazardType = 2;
                spawnWait = 0.5f;
                //hazardCount = 10;
            }
            if (sb.scoreClass.getScore() >= 300 && sb.scoreClass.getScore() < 560) {
                hazardType = 3;
                hazardCount = 10;
                spawnWait = 0.8f;
            } 
            if (sb.scoreClass.getScore() >= 560 && sb.scoreClass.getScore() < 1400) {
                hazardType = 4;
                hazardCount = 1;
                waveWait = 9999990f;
            }

            switch (hazardType)
            {
                default: factory = new HazardOneFactory(); break;
                case 1: factory = new HazardOneFactory(); break;
                case 2: factory = new HazardTwoFactory(); break;
                case 3: factory = new HazardThreeFactory(); break;
                case 4: factory = new HazardFourFactory(); break;
            }
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 hazardSpawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x),
                                               spawnValue.y,
                                               spawnValue.z);
                Quaternion hazardSpawnRotation = Quaternion.identity;
                if (hazardType == 4) {
                    hazardSpawnPosition = new Vector3(0,
                                               spawnValue.y,
                                               15);
                }
                //Vector3 enemySpawnPosition = new Vector3(Random.Range(-spawnValue.x, spawnValue.x),
                //                               spawnValue.y,
                //                               spawnValue.z);
                Instantiate(factory.createHazard(), hazardSpawnPosition, hazardSpawnRotation);
                //Instantiate(enemy, enemySpawnPosition, hazardSpawnRotation);
                yield return new WaitForSeconds(spawnWait);
                if (gameOver) {
                    restart = true;
                    restartText.text = "Press 'R' to Restart";
                }
            }


            yield return new WaitForSeconds(waveWait);
        }

    }

    public void GameOver() {
        gameOver = true;
        gameOverText.text = "Game Over";
    }

    public void GameFinish() {
        gameOver = true;
        gameOverText.text = "All Clear";
        restart = true;
        restartText.text = "Press 'R' to Restart";
    }

	// Update is called once per frame
	void Update () {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
        if (!start) {
            if (Input.GetKeyDown(KeyCode.R)) {
                start = true;
                Application.LoadLevel(Application.loadedLevel);
            }
        }
	}
}
