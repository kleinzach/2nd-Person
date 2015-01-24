using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.Reflection;


[CustomEditor(typeof(GameObject))]
public class TestEditor : Editor {
	
	public void OnSceneGUI(){
		Tools.current = Tool.None;
		GameObject obj = ((GameObject)target);
		if (!obj.name.Contains("Path"))
			obj.transform.position = Handles.PositionHandle(obj.transform.position, Quaternion.identity);
	}
	
	
}