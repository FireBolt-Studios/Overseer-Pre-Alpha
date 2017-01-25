using Overseer;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Overseer {
	public class BuildUtility {

		public static void FitCorridor (GameObject corridor)
		{
			Transform ref1 = corridor.transform.GetChild(0).GetComponent<BuildConnector>().connectedTo.GetChild(0);
			Transform ref2 = corridor.transform.GetChild(2).GetComponent<BuildConnector>().connectedTo.GetChild(0);

			float length = Vector3.Distance(ref1.position,ref2.position)-1;
			corridor.transform.position = ref1.position;
			Debug.Log(length);
			ResizeCorridor(corridor,length);
		}
			
		public static void ResizeCorridor (GameObject Corridor,float length)
		{
			Transform center = Corridor.transform.GetChild(1);
			center.localScale = new Vector3(1,1,length);

			Transform con = Corridor.transform.GetChild(2);

			con.localPosition = new Vector3(0,0,length+1);

		}

		public static void ResizeElevator (GameObject Elevator,int height)
		{
			int scale = height+(height-1);
			Transform center = Elevator.transform.GetChild(0);
			center.localScale = new Vector3(1,scale,1);

			Transform con1 = Elevator.transform.GetChild(1);
			Transform con2 = Elevator.transform.GetChild(2);

			con1.localPosition = new Vector3(0,-height,0);
			con2.localPosition = new Vector3(0,height,0);

		}

		public static void ResizeHub (GameObject Hub,int sizeX, int sizeZ)
		{
			Transform[] center = GameUtility.FindChildrenWithTag(Hub,"HubCenter");
			Transform[] corners = GameUtility.FindChildrenWithTag(Hub,"HubCorner");
			Transform[] edges = GameUtility.FindChildrenWithTag(Hub,"HubEdge");
			Transform[] connectors = GameUtility.FindChildrenWithTag(Hub,"HubConnector");

			int scaleX = sizeX+(sizeX-1);
			int scaleZ = sizeZ+(sizeZ-1);
			center[0].localScale = new Vector3(scaleX,1,scaleZ);
			foreach (Transform edge in edges)
			{
				if (edge.name.Contains("x+"))
				{
					edge.localPosition = new Vector3(sizeX,0,0);
					edge.localScale = new Vector3(scaleZ,1,1);
				}
				if (edge.name.Contains("x-"))
				{
					edge.localPosition = new Vector3(-sizeX,0,0);
					edge.localScale = new Vector3(scaleZ,1,1);
				}

				if (edge.name.Contains("z+"))
				{
					edge.localPosition = new Vector3(0,0,sizeZ);
					edge.localScale = new Vector3(scaleX,1,1);
				}
				if (edge.name.Contains("z-"))
				{
					edge.localPosition = new Vector3(0,0,-sizeZ);
					edge.localScale = new Vector3(scaleX,1,1);
				}
			}
			foreach (Transform corner in corners)
			{
				if (corner.name.Contains("++"))
				{
					corner.localPosition = new Vector3(sizeX,0,sizeZ);
				}
				if (corner.name.Contains("+-"))
				{
					corner.localPosition = new Vector3(sizeX,0,-sizeZ);
				}
				if (corner.name.Contains("--"))
				{
					corner.localPosition = new Vector3(-sizeX,0,-sizeZ);
				}
				if (corner.name.Contains("-+"))
				{
					corner.localPosition = new Vector3(-sizeX,0,sizeZ);
				}
			}

			sizeX -= 1;
			sizeZ -= 1;

			foreach (Transform connector in connectors)
			{
				if (connector.name.Contains("x+"))
				{
					connector.localPosition = new Vector3(sizeX,0,0);
				}
				if (connector.name.Contains("x-"))
				{
					connector.localPosition = new Vector3(-sizeX,0,0);
				}
				if (connector.name.Contains("z+"))
				{
					connector.localPosition = new Vector3(0,0,sizeZ);
				}
				if (connector.name.Contains("z-"))
				{
					connector.localPosition = new Vector3(0,0,-sizeZ);
				}
			}
		}


	}
}
