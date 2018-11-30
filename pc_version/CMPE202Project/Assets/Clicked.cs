using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clicked : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void MenuSelect(){
         // this object was clicked - do something
      SceneManager.LoadScene("Main", LoadSceneMode.Single);
 	}   
}
