using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltContact : MonoBehaviour
{

    public GameObject explosion;
    public GameObject playerExplosion;
    public int score;
    private GameController gameController;

    void OnTriggerEnter(Collider other)
    {

        if (other.tag != "Player")
        {
            return;
        }


        Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
        gameController.GameOver();

        Instantiate(explosion, transform.position, transform.rotation);

        gameController.addScore(score);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
    // Use this for initialization
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
