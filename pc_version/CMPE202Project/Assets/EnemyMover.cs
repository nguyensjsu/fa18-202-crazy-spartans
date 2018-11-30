using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour {
    public float speed;
    private float nextFire, nextChange;
    public float fireRate;
    public GameObject shot;
    public Transform shotSqawn;
    Vector3 velocity = Vector3.zero;
    public float minx, minz, maxx, maxz;
    float IntervalTime = 3;

    // Use this for initialization
    void Start () {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Rigidbody>().position.z < 8)
        {
            GetComponent<Rigidbody>().velocity = transform.forward * 0;
            //RandomCoordinate();
            //Vector3 position = GetComponent<Rigidbody>().position;
            //if (position.x <= minx || position.x >= maxx || position.z <= minz || position.z >= maxz) {
            //    RandomCoordinate();
            //}
            //randomMove();
            //StartCoroutine(RandomCoordinate());
            //RandomCoordinate();
            //if (Time.time > nextChange) {
            //    nextChange = Time.time + IntervalTime;

            //}
            //StartCoroutine(RandomCoordinate());
        }
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSqawn.position, shotSqawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }

    void randomMove() {
        if (Random.value < 0.01f)
        {
            GetComponent<Rigidbody>().position = transform.position + Quaternion.Euler(0, Random.value * 360, 0) * Vector3.right * 10;
        }
        Vector3 direct = GetComponent<Rigidbody>().position - transform.position;
        direct.y = 0;
        if (direct.sqrMagnitude > 1) {
            transform.rotation = Quaternion.LookRotation(direct);
            velocity = direct.normalized * speed / 3;
        }
        velocity -= GetComponent<Rigidbody>().velocity;
        velocity.y = 0;

        if (velocity.sqrMagnitude > speed * speed) {
            velocity = velocity.normalized * speed;
        }

        GetComponent<Rigidbody>().AddForce(velocity, ForceMode.VelocityChange);
        velocity = Vector3.zero;


    }

    void RandomCoordinate() {
        //if (Random.value < 0.01f)
        //{
        //    GetComponent<Rigidbody>().position = transform.position + Quaternion.Euler(0, Random.value * 360, 0) * Vector3.right * 10;
        //}
        //Vector3 direct = GetComponent<Rigidbody>().position - transform.position;

        Vector3 newDirection;
        newDirection.x = Random.Range(minx, maxx);
        newDirection.y = GetComponent<Rigidbody>().position.y;
        newDirection.z = Random.Range(minz + 5, maxz);
        //GetComponent<Rigidbody>().rotation = transform.rotation = Quaternion.Euler(0, direction, 0);//旋转指定度数
        //GetComponent<Rigidbody>().velocity = speed * direct.normalized;//向前移动
        transform.position = Vector3.MoveTowards(GetComponent<Rigidbody>().position, newDirection, -speed * Time.deltaTime);
        //Vector3 position = GetComponent<Rigidbody>().position;
        //if (position.x <= minx || position.x >= maxx || position.z <= minz || position.z >= maxz)
        //{
        //    newDirection.x = Random.Range(minx, maxx);
        //    newDirection.y = 0;
        //    newDirection.z = Random.Range(minz, maxz);
        //    //GetComponent<Rigidbody>().rotation = transform.rotation = Quaternion.Euler(0, direction, 0);//旋转指定度数
        //    GetComponent<Rigidbody>().velocity = speed * newDirection.normalized;//向前移动

        //}
        //GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, minx, maxx),
        //0.0f,
        //Mathf.Clamp(GetComponent<Rigidbody>().position.z, minz, maxz));
    }


}
