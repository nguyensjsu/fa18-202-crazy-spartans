using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour, Subject {
    public GameObject explosion;
    private int score;
    private GameController gameController;

    public void addObserver(GameController gameControllerFound) {
        this.gameController = gameControllerFound;
    }


    public void removeObserver(GameController gameControllerDelete) {

    }

    public void notifyObservers(int scoreChange) 
    {
        this.gameController.updateScoreFromOutside(scoreChange);
    }

    // Use this for initialization
    void Start()
    {
        score = -100;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            addObserver(gameControllerObject.GetComponent<GameController>());
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
            notifyObservers(score);
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
