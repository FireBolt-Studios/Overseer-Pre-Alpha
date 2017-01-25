using Overseer;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildModule : MonoBehaviour {

	public GameObject module;
	public BuildManager buildManager;

	public bool placeMode;

	public Material main;
	public Material place;

	public BuildConnector[] Connectors;

	void OnMouseDown ()
	{
		if (placeMode)
		{
			GameObject newModule = Instantiate(module,transform.position,transform.rotation) as GameObject;
			newModule.GetComponent<BuildModule>().buildManager = buildManager;
		}
	}

	void Start ()
	{
		BuildConnector[] connectors = GetComponentsInChildren<BuildConnector>();
		foreach (BuildConnector connector in connectors)
		{
			print(connector);
			connector.buildManager = buildManager;
		}
	}

	void Update ()
	{
		if (placeMode)
		{
			transform.GetChild(0).GetComponent<MeshRenderer>().material = place;
			transform.GetChild(1).GetComponent<MeshRenderer>().material = place;
			transform.GetChild(2).GetComponent<MeshRenderer>().material = place;
			transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
			transform.GetChild(2).GetComponent<BoxCollider>().enabled = false;

			if (buildManager.currentSelector != null)
			{
				Transform cRef = buildManager.currentSelector.transform.GetChild(0);
				transform.position = cRef.position;
				transform.rotation = cRef.rotation;
			}
		}
	}

}
