using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject hazard;
    public Vector3 spawnValue;
    public int hazardCount;

    public float spawnWait;
    public float startWart;

    private int score;
    public Text scoreText;

    public Text gameOverText;
    private bool gameOver;

    public Text restartText;
    private bool restart;

    public Text winText;
    private bool win;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateScore ();
        gameOverText.text = "";
        gameOver = false;
        restartText.text = "";
        restart = false;
        winText.text = "";
        win = false;
        StartCoroutine(SpawnWaves());
	}

    void UpdateScore() {
        scoreText.text = "Score: " + score;
    }

    public void addScore(int value) {
        score += value;
        UpdateScore();
    }
    IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(startWart);

        while (true) {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosision = new Vector3(Random.Range(-spawnValue.x, spawnValue.x),
                                                 spawnValue.y,
                                                 spawnValue.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosision, spawnRotation);
                yield return new WaitForSeconds(spawnWait);

                if (gameOver)
                {
                    restart = true;
                    restartText.text = "Press 'R' to restart";
                }

                if(score > 500) {
                    winText.text = "Congratulation!";
                    restart = true;
                    restartText.text = "Press 'R' to restart";
                }
            }
        }
    }

    public void GameOver() {
        gameOver = true;
        gameOverText.text = "GameOver";
    }
	
	// Update is called once per frame
	void Update () {
        if (restart) {
            if (Input.GetKeyDown(KeyCode.R)) {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
		
	}
}
