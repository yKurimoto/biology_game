using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

	public GameObject seikai;
	public int clickMove = -8;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, Mathf.Infinity);

			if (hit.collider && clickMove <= 8) {
				GameObject item = hit.collider.gameObject;
				item.transform.position = new Vector3(clickMove, -3, 0);
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
			} else {
				SceneManager.LoadScene (0);
			}
		}
	}
}
