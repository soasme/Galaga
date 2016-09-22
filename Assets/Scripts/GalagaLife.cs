using UnityEngine;
using System.Collections;

public class GalagaLife : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.tag == "Bullet" || collider.tag == "Enemy") {
			Destroy (gameObject);
		}
	}
}
