using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject explosionPref;
	private Vector2 attackPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "GalagaBullet" || collider.tag == "Galaga") {
			PlayExplosion ();
			Destroy (gameObject);
		}
	}

	void PlayExplosion(){
		var explosion = (GameObject)Instantiate (explosionPref);
		explosion.transform.position = gameObject.transform.position;
	}

	public void MoveToPlayer(){
		var galaga = GameObject.FindGameObjectWithTag ("Galaga");
		if (galaga) {
			Vector2 pos = transform.position;
			var speed = 1.0f;
			pos.y = pos.y - Time.deltaTime * speed;
			pos.x = Mathf.Sin (pos.y) * 3;
			transform.position = pos;
		}
	}
}
