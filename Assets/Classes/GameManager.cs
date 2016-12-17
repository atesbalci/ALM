using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	private const float SPAWN_INTERVAL = 3;

	public static GameManager instance { get; private set; }

	public Transform enemies;
	public Node startNode;
	public GameObject enemyPrefab;

	private float spawnTimer;

	void Awake() {
		instance = this;
	}

	void Start() {
		spawnTimer = 0;
	}

	void Update() {
		spawnTimer -= Time.deltaTime;
		if(spawnTimer < 0) {
			spawnTimer = SPAWN_INTERVAL;
			Enemy enemy = ((GameObject)Instantiate(enemyPrefab,
				startNode.transform.position, Quaternion.identity))
				.GetComponent<Enemy>();
			enemy.startNode = startNode;
			enemy.name = "Enemy";
			enemy.transform.SetParent(enemies);
		}
	}
}
