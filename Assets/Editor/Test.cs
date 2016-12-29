using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class Test {

	[Test]
	public void EditorTest()
	{
		var gameObject = new GameObject();
		
		var newGameObjectName = "My game object";
		gameObject.name = newGameObjectName;
		
		Assert.AreEqual(newGameObjectName, gameObject.name);
	}
}
