using UnityEngine;
using System.Collections;

public class GalagaMovement : MonoBehaviour {

	public float speed = 1f;

	void Update () {
		var position = gameObject.transform.position;
		var x = position.x + Input.GetAxis ("Horizontal") * speed;
		gameObject.transform.position = new Vector2 (x, position.y);
	}
}
