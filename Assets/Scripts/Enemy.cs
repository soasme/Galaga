using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject explosionPref;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Bullet") {
			PlayExplosion ();
			Destroy (gameObject);
		}
	}

	void PlayExplosion(){
		var explosion = (GameObject)Instantiate (explosionPref);
		explosion.transform.position = gameObject.transform.position;
	}
}
