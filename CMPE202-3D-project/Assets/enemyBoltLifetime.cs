using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBoltLifetime : MonoBehaviour {

    private float timeStart;

	// Use this for initialization
	void Start () {
        timeStart = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > timeStart + 10) {
            Destroy(this.gameObject);
        }	
	}
}
