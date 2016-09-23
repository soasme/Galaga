using UnityEngine;
using System.Collections;

public class EnemyArmySpawner : MonoBehaviour {

	public int enemyRows = 3;
	public int enemyColumns = 10;
	public int direction = 1;
	public float speed = 1;
	public GameObject enemyPref;
	public GameObject[] enemies;
	private GameObject attackForce;

	int GetEnemyCount() {
		int total = 0;
		foreach (GameObject enemy in enemies) {
			if (enemy != null) {
				total += 1;
			}
		}
		return total;
	}

	void Start () {
		enemies = new GameObject[enemyRows * enemyColumns];

		Spawn ();
	}

	bool NeedSpawn() {
		return GetEnemyCount() == 0;
	}

	void Spawn() {
		Vector2 center = gameObject.transform.position;
		for (int i = 0; i < enemyRows; i++) {
			for (int j = 0; j < enemyColumns; j++) {
				if (!enemies [i * enemyColumns + j]) {
					Vector2 pos = new Vector2 (j - enemyColumns / 2 + 0.5f, i);
					enemies [i * enemyColumns + j] = (GameObject)Instantiate (enemyPref, pos, Quaternion.identity);
					enemies [i * enemyColumns + j].transform.SetParent (this.transform);
				}
			}
		}
	}

	void Move() {
		var pos = transform.position;
		pos.x = pos.x + direction * Time.deltaTime * speed;
		pos.x = Mathf.Clamp (pos.x, -1, 1);

		transform.position = pos;

		if (pos.x == -1 || pos.x == 1) {
			direction = -1 * direction;
		}
	}

	bool isAttacking(){
		return (bool)attackForce;
	}

	IEnumerator ChooseAttackForce(){
		yield return new WaitForSeconds (1);

		if (!attackForce && GameObject.FindGameObjectWithTag("Galaga")) {
			var enemyCount = GetEnemyCount ();
			if (enemyCount == 0) {
				yield return new WaitForSeconds (1);
			}
			int attackerIndex = Random.Range (0, enemyCount);
			foreach (GameObject enemy in enemies) {
				if (enemy) {
					enemyCount -= 1;
				}
				if (enemyCount == attackerIndex) {
					attackForce = enemy;
				}
			}
		}
	}

	void Attack() {
		attackForce.transform.parent = null;

		Enemy enemy = (Enemy)attackForce.GetComponent (typeof(Enemy));
		enemy.Move ();
	}

	void Update () {
		if (NeedSpawn ()) {
			Spawn ();
		} else {
			Move ();
		}

		if (isAttacking ()) {
			Attack ();
		} else {
			StartCoroutine (ChooseAttackForce());
		}
	}
}
