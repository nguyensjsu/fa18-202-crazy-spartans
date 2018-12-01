using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryShipPlayer : MonoBehaviour {

    public GameObject explosion;
    private GameController gameController;

    // Use this for initialization
    void Start () {

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
        if (other.tag == "Player")
        {
            gameController.GameOver();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
