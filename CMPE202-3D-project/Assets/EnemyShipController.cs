using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : MonoBehaviour {

    private float nextFire;
    public float fireRate;
    public GameObject shot;
    public Transform shotSqawn;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSqawn.position, shotSqawn.rotation);
        }
	}
}
