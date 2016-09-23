using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.tag == "GalagaBullet" && collider.tag == "Enemy" ||
			this.tag == "EnemyBullet" && collider.tag == "Galaga"
		) {
			Destroy (gameObject);
		}
	}
}
