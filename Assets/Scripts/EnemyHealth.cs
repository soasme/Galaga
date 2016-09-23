using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public GameObject explosionPref;
	private Vector2 attackPosition;

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
}
