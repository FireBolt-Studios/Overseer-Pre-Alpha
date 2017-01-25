using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Overseer {
	public static class GameUtility {

//		public static void ToggleConnectorColliders (BuildConnector[] connectors,bool off)
//		{
//			if (off == true)
//			{
//				foreach (BuildConnector con in connectors)
//				{
//					con.GetComponent<BoxCollider>().enabled = false;
//				}
//			}
//			else
//			{
//				foreach (BuildConnector con in connectors)
//				{
//					con.GetComponent<BoxCollider>().enabled = true;
//				}
//			}
//		}

		public static void SetMaterials (GameObject gameObject,Material material)
		{
			MeshRenderer[] mRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
			foreach (MeshRenderer mR in mRenderers)
			{
				mR.material = material;
			}
		}

		public static Transform[] FindChildrenWithTag(GameObject parent, string tag)
		{
			List<Transform> transforms = new List<Transform>();

			foreach (Transform tr in parent.transform)
			{
				if (tr.tag == tag)
				{
					transforms.Add(tr);
				}
			}

			return transforms.ToArray();
		}
	}
}