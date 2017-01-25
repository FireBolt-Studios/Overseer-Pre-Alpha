using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIBuildButton : MonoBehaviour {

	public GameObject module;
	public BuildManager buildManager;

	public void SendToPlace ()
	{
		buildManager.PlaceModule(module);
	}


}
