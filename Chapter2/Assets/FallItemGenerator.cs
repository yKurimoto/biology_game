using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallItemGenerator : MonoBehaviour {

	public GameObject fallCPrefab;
	public GameObject fallGPrefab;
	public GameObject fallAPrefab;
	public GameObject fallTPrefab;
	float span = 2.0f;
	float delta = 0;
	GameObject item;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.delta += Time.deltaTime;
		if (this.delta > this.span) {
			this.delta = 0;
			int random = Random.Range (1, 13);
			if (random <= 3) {
				item = Instantiate (fallAPrefab) as GameObject;
			} else if (random > 3 && random <= 6) {
				item = Instantiate (fallCPrefab) as GameObject;

			} else if (random > 6 && random <= 9) {
				item = Instantiate (fallGPrefab) as GameObject;
			} else {
				item = Instantiate (fallTPrefab) as GameObject;
			}
			float x = Random.Range (-4, 4);
			item.transform.position = new Vector3 (x * 2, 7, 0);
		}



//		if (item.transform.position.y < -7) {
//			Destroy (item);
//		}
	}
}
