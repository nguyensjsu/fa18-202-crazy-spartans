using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryEnemyShipByBolt : MonoBehaviour {
    public int lifeValue;
    public GameObject boltImpact;
    public GameObject explosion;

    private int score;
    private GameController gameController;

    // Use this for initialization
    void Start () {
        score = 300;

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "3DBolt")
        {
            Instantiate(boltImpact, transform.position, transform.rotation);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            lifeValue = lifeValue - 1;

            if (lifeValue == 0) {
                gameController.addScore(score);
                Destroy(gameObject);
            }
        }

        if (other.tag == "Player")
        {
            gameController.GameOver();
            Destroy(other.gameObject);
        }
    }
}
