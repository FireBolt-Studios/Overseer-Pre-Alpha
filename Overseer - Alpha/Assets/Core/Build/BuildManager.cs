using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildManager : MonoBehaviour {

	public BuildConnector currentSelector;

	public void PlaceModule (GameObject module)
	{
		GameObject newModule = Instantiate(module,transform.position,Quaternion.identity) as GameObject;
		newModule.GetComponent<BuildModule>().buildManager = this;
		newModule.GetComponent<BuildModule>().placeMode = true;
		newModule.GetComponent<BuildModule>().module = module;
	}

}
