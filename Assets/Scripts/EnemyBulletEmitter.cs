using UnityEngine;
using System.Collections;

public class EnemyBulletEmitter : BulletEmitter {

	bool IsBelongsToArmy() {
		return gameObject.transform.parent != null;
	}

	void Update () {
		if (IsBelongsToArmy()) {
			return;
		}

		if (CanFire()) {
			Reload ();
			StartCoroutine (Fire ());
		}
	}

}
