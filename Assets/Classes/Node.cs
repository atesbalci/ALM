using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour {
	public Node next;

	void OnDrawGizmos() {
		if (next) {
			Gizmos.color = Color.white;
			Gizmos.DrawLine(transform.position, next.transform.position);
		}
		Gizmos.color = Color.cyan;
		Gizmos.DrawSphere(transform.position, 0.1f);
	}

	void OnDrawGizmosSelected() {
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(transform.position, 0.1f);
	}
}
