using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.Reflection;


[CustomEditor(typeof(Transform))]
public class TestEditor : Editor {

	public void OnSceneGUI(){
		Tools.current =  Tool.None;
		Transform trans = ((Transform)target);
		bool path = trans.gameObject.name.Contains ("Path");
		bool way = trans.gameObject.name.Contains ("Waypoint");

		if (!path && !(way && Path.hide))
			trans.position = Handles.PositionHandle(trans.position, trans.rotation);
	}
	
	
}