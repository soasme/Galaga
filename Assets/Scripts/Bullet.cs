using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (this.tag == "GalagaBullet" && collider.tag == "Enemy" ||
			this.tag == "EnemyBullet" && collider.tag == "Galaga"
		) {
			Destroy (gameObject);
		}
	}
}
