using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {
	public const float RANGE = 3;
	public const float DAMAGE = 1;

	private const int RANGE_DETAIL = 48;

	public Transform sphere;
	public LineRenderer rangeDisplay;

	private LineRenderer line;
	private Enemy currentTarget;

	void Start() {
		line = GetComponent<LineRenderer>();
		line.SetPosition(0, sphere.position);
		line.SetPosition(1, sphere.position);
		rangeDisplay.SetVertexCount(RANGE_DETAIL);
		Vector3[] rangeVecs = new Vector3[RANGE_DETAIL];
		for(int i = 0; i < rangeVecs.Length - 1; i++) {
			rangeVecs[i] = new Vector3(Mathf.Sin(i * 2 * Mathf.PI / rangeVecs.Length) * RANGE,
				0, Mathf.Cos(i * 2 * Mathf.PI / rangeVecs.Length) * RANGE);
		}
		rangeVecs[rangeVecs.Length - 1] = new Vector3(Mathf.Sin(2 * Mathf.PI) * RANGE,
				0, Mathf.Cos(2 * Mathf.PI) * RANGE);
		rangeDisplay.SetPositions(rangeVecs);
	}

	void Update() {
		Vector3 linePos = sphere.position;
		if(currentTarget) {
			if(Vector3.Distance(transform.position, 
				currentTarget.transform.position) > RANGE) {
				currentTarget = null;
			}
		}
		if (!currentTarget) {
			Transform enemies = GameManager.instance.enemies;
			int closest = -1;
			float closestDistance = float.MaxValue;
			for(int i = 0; i < enemies.childCount; i++) {
				float dist = Vector3.Distance(enemies.GetChild(i).position,
					transform.position);
				if (closestDistance > dist && dist <= RANGE) {
					closest = i;
					closestDistance = dist;
				}
			}
			if(closest > -1) {
				currentTarget = enemies.GetChild(closest).GetComponent<Enemy>();
			}
		}
		if (currentTarget) {
			currentTarget.health -= Time.deltaTime * DAMAGE;
			linePos = currentTarget.transform.position;
		}
		line.SetPosition(1, linePos);
	}
}
