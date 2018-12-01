using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DestroyByContact : MonoBehaviour, Subject {
    public GameObject explosion;
    private int score;
    private LinkedList<Observer> observers = new LinkedList<Observer>();
    private StrategyCollide strategyCollide;

    public void addObserver(GameController gameControllerFound) {
        observers.AddLast(gameControllerFound);
    }


    public void removeObserver(GameController gameControllerDelete) {
        observers.Remove(gameControllerDelete);

    }

    public void notifyObservers(int scoreChange) 
    {
        foreach(Observer observer in observers) {
            observer.updateScoreFromOutside(scoreChange);
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
            strategyCollide = new StrategyCollide3DBolt();
        }

        if (other.tag == "Player") {
            strategyCollide = new StrategyCollide3DPlayer();
        }

        strategyCollide.destoryPattern(this, other.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public int getScore() {
        return score;
    }

    public LinkedList<Observer> getObservers() {
        return this.observers;
    }
}
