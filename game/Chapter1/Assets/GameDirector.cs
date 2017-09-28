using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

	public GameObject seikai;
	public GameObject huseikai;
	public int clickMove = -8;

	void Return () {
		SceneManager.LoadScene ("GameScene");
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, Mathf.Infinity);

			if (hit.collider.tag == "Home") {
				SceneManager.LoadScene ("StartScene");
			} else if (hit.collider && clickMove <= 8 && hit.collider.gameObject.transform.position.y == 1.5f) {
				GameObject item = hit.collider.gameObject;
				item.transform.position = new Vector3 (clickMove, -3, 0);
				clickMove += 4;
			} 
		}
			
		if (clickMove > 8) {
			if (GameObject.FindWithTag ("body").transform.position.x == -8 &&
			    GameObject.FindWithTag ("cell").transform.position.x == -4 &&
			    GameObject.FindWithTag ("nucleus").transform.position.x == 0 &&
			    GameObject.FindWithTag ("chromosome").transform.position.x == 4 &&
			    GameObject.FindWithTag ("nucleotide").transform.position.x == 8) {

				seikai.SetActive (true);
				Invoke("Return", 3.5f);

			} else {
				huseikai.SetActive (true);
				Invoke ("Return", 3.5f);
			}
		}
	}
}
