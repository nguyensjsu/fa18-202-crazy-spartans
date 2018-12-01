using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyByContact : MonoBehaviour, Subject {
    public GameObject explosion;
    private int score;
    private LinkedList<GameController> gameControllerList = new LinkedList<GameController>();

    public void addObserver(GameController gameControllerFound) {
        gameControllerList.AddLast(gameControllerFound);
    }


    public void removeObserver(GameController gameControllerDelete) {
        gameControllerList.Remove(gameControllerDelete);

    }

    public void notifyObservers(int scoreChange) 
    {
        foreach(GameController gameController in gameControllerList) {
            gameController.updateScoreFromOutside(scoreChange);
        }
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
            foreach (GameController gameController in gameControllerList)
            {
                gameController.GameOver();
            }
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
