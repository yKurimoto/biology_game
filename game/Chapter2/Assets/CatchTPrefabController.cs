using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTPrefabController : MonoBehaviour {

	GameObject director;

	private void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "FallA") {
			Destroy (gameObject);
			this.director.GetComponent<GameDirector> ().GenerateItem ();
			this.director.GetComponent<GameDirector> ().UpPointer ();
		} else {
			this.director.GetComponent<GameDirector> ().DownPointer ();
		}
		Destroy (other.gameObject);
	}

	// Use this for initialization
	void Start () {
		this.director = GameObject.Find ("GameDirector");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
