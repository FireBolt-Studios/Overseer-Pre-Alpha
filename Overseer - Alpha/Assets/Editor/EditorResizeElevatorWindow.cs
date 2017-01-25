using Overseer;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorResizeElevatorWindow : EditorWindow {

	public int height;
	public GameObject elevator;

	[MenuItem("Overseer/Resize Elevator")]
	static void Init ()
	{
		EditorResizeElevatorWindow window = (EditorResizeElevatorWindow)EditorWindow.GetWindow(typeof(EditorResizeElevatorWindow));
		window.Show();
	}

	void OnGUI ()
	{
		minSize = new Vector2(150,65);
		maxSize = new Vector2(150,65);

		height = EditorGUI.IntField(new Rect(5,5,67.5f,15),height);
		elevator = (GameObject)EditorGUI.ObjectField(new Rect(5,25,140,15),elevator,typeof(GameObject),true);
		if (GUI.Button(new Rect(5,45,140,15), "Resize"))
		{
			if (height > 0)
			{
				if (elevator != null)
				{
					BuildUtility.ResizeElevator(elevator,height);
				}
			}
		}
	}
}
