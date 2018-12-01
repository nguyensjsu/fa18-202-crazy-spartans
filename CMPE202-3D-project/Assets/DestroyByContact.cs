using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {
    public GameObject explosion;
    private int score;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        score = -100;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }

        if (gameControllerObject == null) {
            Debug.Log("Cannot find 'GameController' Script");
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "3DBolt")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gameController.addScore(score);
            Destroy(gameObject);
            Destroy(other.gameObject);
        }

        if (other.tag == "Player") {
            gameController.GameOver();
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
