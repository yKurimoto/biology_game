using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour {

	public GameObject catchAPrefab;
	public GameObject catchTPrefab;
	public GameObject catchCPrefab;
	public GameObject catchGPrefab;
	public GameObject finish;
	GameObject item;
	GameObject timer;
	GameObject counter;
	float delta = 0;
	int point = 0;

	void Return (){
		SceneManager.LoadScene ("StartScene");
	}


	public void DecreaseTimer () {
		this.timer.GetComponent<Image> ().fillAmount -= 0.017f;
		if (timer.GetComponent<Image> ().fillAmount <= 0) {
			finish.SetActive (true);
			Time.timeScale = 0;
			Invoke ("Return", 2.0f);
		}
	}

	public void UpPointer () {
		this.point += 100;
		this.counter.GetComponent<Text> ().text = this.point.ToString () + "point"; 
	}

	public void DownPointer () {
		this.point /= 2;
		this.counter.GetComponent<Text> ().text = this.point.ToString () + "point"; 
	}

	public void GenerateItem () {
		int random = Random.Range (1, 13);
		if (random <= 3) {
			item = Instantiate (catchGPrefab) as GameObject;
		} else if (random > 3 && random <= 6) {
			item = Instantiate (catchCPrefab) as GameObject;

		} else if (random > 6 && random <= 9) {
			item = Instantiate (catchTPrefab) as GameObject;
		} else {
			item = Instantiate (catchAPrefab) as GameObject;
		}
		item.transform.position = new Vector3 (0, -3, 0);
	}

	// Use this for initialization
	void Start () {
		GenerateItem ();
		this.timer = GameObject.Find ("Timer");
		this.counter = GameObject.Find ("Point");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			item.transform.Translate (-2, 0, 0);
		}

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			item.transform.Translate (2, 0, 0);
		}

		delta += Time.deltaTime;
		if (delta > 1.0f) {
			delta = 0;
			DecreaseTimer ();
		}

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction, Mathf.Infinity);

			if (hit.collider.tag == "Start") {
				Invoke ("Return", 2.0f);
			}
		}
	}
}
