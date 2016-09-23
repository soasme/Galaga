using UnityEngine;
using System.Collections;

public class GalagaMovement : MonoBehaviour {

	public float speed = 1f;

	void Update () {
		// get origin position
		var position = gameObject.transform.position;

		// add delta, and set range
		gameObject.transform.position = new Vector2 (
			Mathf.Clamp(position.x + Input.GetAxis ("Horizontal") * speed, -6f, 6f)
			, position.y
		);
	}
}
