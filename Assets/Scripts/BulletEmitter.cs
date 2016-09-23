using UnityEngine;
using System.Collections;

public class BulletEmitter : MonoBehaviour {

	// emit bullet from this object
	public GameObject bulletEmitter;

	// bullet prefab referrence
	public GameObject bulletPref;

	// player can not emit bullet when emitterColling is true
	public bool cooling = false;

	// bullet fire speed
	public float bulletSpeedScale;

	// Vector2.up or Vector.down
	public Vector2 bulletDirection;

	// once loadedBullet is set, it can be fired
	public GameObject loadedBullet;

	// cooling time
	public float coolingSeconds;

	// bullet tag
	public string bulletTag;


	public IEnumerator Fire() {
		// enable cooling flag on fire
		cooling = true;

		// fire: add force to bullet
		Rigidbody2D rigidbody = loadedBullet.GetComponent<Rigidbody2D> ();
		rigidbody.AddForce (bulletDirection * bulletSpeedScale);

		loadedBullet.tag = bulletTag;

		// destroy loaded bullet after 10s if it's fired.
		Destroy (loadedBullet, 10.0f);

		// set loadedBullet to null to make sure only one loaded bullet will be created.
		loadedBullet.transform.parent = null;
		loadedBullet = null;

		// disable cooling flag after fire
		yield return new WaitForSeconds (coolingSeconds);
		cooling = false;
	}

	public bool NeedReload() {
		// If emitter is cooling down, there is no need to reload
		// If there is a loaded bullet, there is no need to reload
		return !cooling && !loadedBullet;
	}

	public void Reload(){
		// Load bullet at emitter position
		loadedBullet = (GameObject) Instantiate (bulletPref, bulletEmitter.transform.position, Quaternion.identity);

		// follow with parent before firing
		loadedBullet.transform.parent = gameObject.transform;
	}

	public bool CanFire(){
		// emitter is cooled down
		return !cooling;
	}


}
