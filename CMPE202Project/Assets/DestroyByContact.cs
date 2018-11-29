using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    private GameController gameController;
    public int healthBar;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player" && other.tag != "Bolt") {
            return;
        }

        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(other.gameObject);
        healthBar--;
        print(healthBar);
        if (healthBar == 0) {
            gameController.addScore(score);
            Destroy(gameObject);
            if (gameController.getScore() >= 1400)
            {
                gameController.GameFinish();
            }
        } 
  
    }
    // Use this for initialization
    void Start () {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
