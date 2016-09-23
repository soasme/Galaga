using UnityEngine;
using System.Collections;

public class GalagaBulletEmitter : MonoBehaviour {

	// emit bullet from this object
	public GameObject bulletEmitter;

	// bullet prefab referrence
	public GameObject bulletPref;

	// player can not emit bullet when emitterColling is true
	public bool emitterCooling = false;

	// bullet fire speed
	public float bulletSpeedScale;

	// once loadedBullet is set, it can be fired
	private GameObject loadedBullet;

	IEnumerator Fire() {
		emitterCooling = true;

		// fire: add force to bullet
		Rigidbody2D rigidbody = loadedBullet.GetComponent<Rigidbody2D> ();
		rigidbody.AddForce (Vector2.up * bulletSpeedScale);

		// destroy loaded bullet after 10s if it's fired.
		Destroy (loadedBullet, 10.0f);

		// set loadedBullet to null to make sure only one loaded bullet will be created.
		loadedBullet.transform.parent = null;
		loadedBullet = null;

		// cooling time: 1.5s
		yield return new WaitForSeconds (1.5f);

		emitterCooling = false;
	}

	bool NeedReload() {
		// If emitter is cooling down, there is no need to reload
		// If there is a loaded bullet, there is no need to reload
		return !emitterCooling && !loadedBullet;
	}

	void Reload(){
		// Load bullet at emitter position
		loadedBullet = (GameObject) Instantiate (bulletPref, bulletEmitter.transform.position, Quaternion.identity);

		loadedBullet.tag = "GalagaBullet";
		loadedBullet.transform.parent = gameObject.transform;
	}

	bool CanFire(){
		// Player hit fire signal, and emitter is cooling down
		return Input.GetKeyDown ("space") && !emitterCooling;
	}

	void Update () {
		if (NeedReload()) {
			Reload ();
		}

		if (CanFire()) {
			StartCoroutine (Fire ());
		}
	}
}
