using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EnemyCanvas : MonoBehaviour {
	public Image healthBar;

	private Enemy enemy;

	void Start() {
		enemy = transform.parent.GetComponent<Enemy>();
	}

	void Update() {
		healthBar.fillAmount = enemy.health * 0.5f;
		healthBar.color = Color.Lerp(Color.red, Color.green, enemy.health);
	}
}
