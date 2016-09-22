using UnityEngine;
using System.Collections;

public class GalagaBulletEmitter : MonoBehaviour {

	// emit bullet from this object
	public GameObject bulletEmitter;

	// bullet prefab referrence
	public GameObject bulletPref;

	// bullet fire speed
	public float bulletSpeedScale;

	void Fire() {
		GameObject bullet = (GameObject) Instantiate (bulletPref, bulletEmitter.transform.position, Quaternion.identity);
		Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D> ();
		rigidbody.AddForce (Vector2.up * bulletSpeedScale);
		Destroy (bullet, 10.0f);
	}

	void Update () {
		if (Input.GetKeyDown ("space")) {
			Fire ();
		}
	}
}
