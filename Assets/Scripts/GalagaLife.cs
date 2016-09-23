using UnityEngine;
using System.Collections;

public class GalagaLife : MonoBehaviour {

	public GameObject explosionPref;

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "EnemyBullet" || collider.tag == "Enemy") {
			PlayExplosion ();
			Destroy (gameObject);
		}
	}

	void PlayExplosion(){
		var explosion = (GameObject)Instantiate (explosionPref);
		explosion.transform.position = gameObject.transform.position;
	}
}
