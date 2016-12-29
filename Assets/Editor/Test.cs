using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

public class Test {

	[Test]
	public void EditorTest()
	{
		var gameObject = new GameObject();
		
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName + "-";
		
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}

	[Test]
	public void TestNodes() {
		Node cur = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().startNode;
		List<GameObject> nodes = new List<GameObject>(GameObject.FindGameObjectsWithTag("Node"));

		while(cur != null) {
			nodes.Remove(cur.gameObject);
			cur = cur.next;
		}

		Assert.AreEqual(nodes.Count, 0);
	}
}
