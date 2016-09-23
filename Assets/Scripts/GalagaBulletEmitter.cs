using UnityEngine;
using System.Collections;

public class GalagaBulletEmitter : BulletEmitter {

	public new bool CanFire(){
		// Player hit fire signal, and emitter is cooling down
		return Input.GetKeyDown ("space") && !cooling;
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
