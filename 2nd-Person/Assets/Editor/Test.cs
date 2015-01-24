using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.Reflection;


[CustomEditor(typeof(Transform))]
public class TestEditor : Editor {

	public void OnSceneGUI(){
		Tools.current = Path.weird ? Tool.None : Tool.Move;
		Transform trans = ((Transform)target);
		if (!trans.gameObject.name.Contains("Path"))
			trans.position = Handles.PositionHandle(trans.position, Quaternion.identity);
	}
	
	
}