using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class ItemGenerator : MonoBehaviour {

	public GameObject bodyPrefab;
	public GameObject cellPrefab;
	public GameObject choromosomePrefab;
	public GameObject nucleotidePrefab;
	public GameObject nucleusPrefab;

	int[] ary = new int[] { 1, 2, 3, 4, 5 };
	float xrange = -6.0f;

	// Use this for initialization
	void Start () {

//		int number = Random.Range (0, Items.Length);
//		Instantiate(Items[number],transform.position,transform.rotation);

		var random_order = ary.OrderBy(i => Guid.NewGuid()).ToArray();//配列をランダムに並べ替え
		for (int x = 0; x <= 4; x++) {
			GameObject item;
			if (random_order [x] == 1) {
				item = Instantiate(bodyPrefab) as GameObject;
			} else if (random_order [x] == 2) {
				item = Instantiate(cellPrefab) as GameObject;
			} else if (random_order [x] == 3) {
				item = Instantiate(choromosomePrefab) as GameObject;
			} else if (random_order [x] == 4) {
				item = Instantiate(nucleotidePrefab) as GameObject;
			} else {
				item = Instantiate(nucleusPrefab) as GameObject;
			}

			item.transform.position = new Vector3 (xrange, 1.5f, 0.0f);
			xrange += 3.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}
}
