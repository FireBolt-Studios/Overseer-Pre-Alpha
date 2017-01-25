using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildConnector : MonoBehaviour {

	public Transform connectedTo;
	public BuildManager buildManager;

	void OnMouseOver ()
	{
		buildManager.currentSelector = this;
	}

	void OnMouseExit ()
	{
		buildManager.currentSelector = null;
	}

}
