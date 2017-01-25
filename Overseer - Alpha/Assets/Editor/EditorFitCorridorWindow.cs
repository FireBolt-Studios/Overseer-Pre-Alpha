using Overseer;
using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EditorFitCorridorWindow : EditorWindow {

	[MenuItem("Overseer/Fit Corridors")]
	static void Init ()
	{
		EditorFitCorridorWindow window = (EditorFitCorridorWindow)EditorWindow.GetWindow(typeof(EditorFitCorridorWindow));
		window.Show();
	}

	void OnGUI ()
	{
		
		minSize = new Vector2(150,65);
		maxSize = new Vector2(150,65);

		if (GUI.Button(new Rect(5,45,140,15), "Fit All Corridors"))
		{
			GameObject[] corridors = GameObject.FindGameObjectsWithTag("Corridor");
			foreach (GameObject corridor in corridors)
			{
				BuildUtility.FitCorridor(corridor);
			}
		}
	}
}

