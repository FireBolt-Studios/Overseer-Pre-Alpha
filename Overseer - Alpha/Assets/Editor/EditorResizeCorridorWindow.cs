using Overseer;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorResizeCorridorWindow : EditorWindow {

	public float length;
	public GameObject corridor;

	[MenuItem("Overseer/Resize Corridor")]
	static void Init ()
	{
		EditorResizeCorridorWindow window = (EditorResizeCorridorWindow)EditorWindow.GetWindow(typeof(EditorResizeCorridorWindow));
		window.Show();
	}

	void OnGUI ()
	{
		minSize = new Vector2(150,65);
		maxSize = new Vector2(150,65);

		length = EditorGUI.FloatField(new Rect(5,5,67.5f,15),length);
		corridor = (GameObject)EditorGUI.ObjectField(new Rect(5,25,140,15),corridor,typeof(GameObject),true);
		if (GUI.Button(new Rect(5,45,140,15), "Resize"))
		{
			if (length > 0)
			{
				if (corridor != null)
				{
					BuildUtility.ResizeCorridor(corridor,length);
				}
			}
		}
	}
}
