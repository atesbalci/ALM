using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	private const float SPEED = 10;

	public Node startNode;

	public float health;// { get; set; }

	private Node nextNode;

	void Start() {
		nextNode = startNode;
		health = 10;
	}

	void Update() {
		if(health <= 0) {
			Destroy(gameObject);
			return;
		}
		if (nextNode) {
			transform.position = Vector3.MoveTowards(transform.position,
				nextNode.transform.position, SPEED * Time.deltaTime);
			if (Vector3.Distance(transform.position, nextNode.transform.position) < 0.001f)
				nextNode = nextNode.next;
		}
	}
}
s
