using Overseer;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorResizeHubWindow : EditorWindow {

	public int x;
	public int z;

	public GameObject hub;

	[MenuItem("Overseer/Resize Hub")]
	static void Init ()
	{
		EditorResizeHubWindow window = (EditorResizeHubWindow)EditorWindow.GetWindow(typeof(EditorResizeHubWindow));
		window.Show();
	}

	void OnGUI ()
	{
		minSize = new Vector2(150,65);
		maxSize = new Vector2(150,65);

		x = EditorGUI.IntField(new Rect(5,5,67.5f,15),x);
		z = EditorGUI.IntField(new Rect(77.5f,5,67.5f,15),z);
		hub = (GameObject)EditorGUI.ObjectField(new Rect(5,25,140,15),hub,typeof(GameObject),true);
		if (GUI.Button(new Rect(5,45,140,15), "Resize"))
		{
			if (x > 0 && z > 0)
			{
				if (hub != null)
				{
					BuildUtility.ResizeHub(hub,x,z);
				}
			}
		}
	}
}
