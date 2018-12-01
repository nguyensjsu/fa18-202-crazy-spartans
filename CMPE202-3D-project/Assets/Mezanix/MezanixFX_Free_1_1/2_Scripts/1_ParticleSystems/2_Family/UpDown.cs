using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour 
{
	public float minY = 0f;

	public float maxY = 5f;

	public float velocity = 100f;


	float halrfAmp = 5f;

	float center_y = 2.5f;

    float center_x = 2.5f;

    float center_z = 2.5f;

	float alpha = 0f;

    float center_y_rotation = 0f;

    float center_x_rotation = 0f;

    float center_z_rotation = 0f;

    int count = 0;

    float startTime = 0f;

    // Use this for initialization
    void Start () 
	{
		halrfAmp = 0.5f*(maxY - minY);

        center_y = transform.position.y;

        center_x = transform.position.x;

        center_z = transform.position.y;

        center_y_rotation = transform.rotation.x;

        center_x_rotation = transform.rotation.y;

        center_z_rotation = transform.rotation.z;

        startTime = Time.time;

	}
	
	// Update is called once per frame
	void Update () 
	{
		alpha += Mathf.Deg2Rad*velocity*Time.deltaTime;

		if(alpha >= 2f*Mathf.PI)
			alpha = 0f;

		float y = center_y + halrfAmp*Mathf.Sin(alpha) * 100f;

        float x = center_x + halrfAmp * Mathf.Sin(alpha) * 100f;

        float z = center_z + halrfAmp * Mathf.Sin(alpha) * 100f;
        
        transform.position = new Vector3(x, y, z);
        
        if (Time.time > startTime + 1 ) {

            count = count + 1;

            transform.rotation = Quaternion.Euler(Vector3.down*(-10)*count);

            startTime = Time.time;

        }
    }
}
