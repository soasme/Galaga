using UnityEngine;
using System.Collections;

public class EnemyBulletEmitter : MonoBehaviour {

	// emit bullet from this object
	public GameObject bulletEmitter;

	// bullet prefab referrence
	public GameObject bulletPref;

	private GameObject bullet;

	// bullet fire speed
	public float bulletSpeedScale;

	public void Shoot() {
		bullet = (GameObject) Instantiate (bulletPref, bulletEmitter.transform.position, Quaternion.identity);
		bullet.tag = "EnemyBullet";
		Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D> ();
		rigidbody.AddForce (Vector2.down * bulletSpeedScale);
		Destroy (bullet, 2.0f);
	}

	public IEnumerator Fire() {
		if (bullet) {
			yield break;
		}

		Shoot ();
		yield return new WaitForSeconds (0.2f);
		Shoot ();
		yield return new WaitForSeconds (0.2f);
		Shoot ();
		yield break;
	}

}
