using UnityEngine;
using System.Collections;

public class EnemyArmySpawner : MonoBehaviour {

	public int enemyRows = 3;
	public int enemyColumns = 10;
	public GameObject enemyPref;
	public GameObject[] enemies;

	void Start () {
		enemies = new GameObject[enemyRows * enemyColumns];

		Spawn ();
	}

	bool NeedSpawn() {
		return enemies.Length == 0;
	}

	void Spawn() {
		Vector2 center = gameObject.transform.position;
		for (int i = 0; i < enemyRows; i++) {
			for (int j = 0; j < enemyColumns; j++) {				
				Vector2 pos = new Vector2 (j - enemyColumns / 2, i);
				enemies [i] = (GameObject)Instantiate (enemyPref, pos, Quaternion.identity);
			}
		}
	}

	void Update () {
		if (NeedSpawn ()) {
			Spawn ();
		}
	}
}
