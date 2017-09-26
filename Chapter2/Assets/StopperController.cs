using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopperController : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D other) {
		Destroy (other.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
