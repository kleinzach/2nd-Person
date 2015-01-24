using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(Path))]
public class PathEditor : Editor {
	public override void OnInspectorGUI()	{
		Path p = (Path)target;
		CustomEditorUtil.text(p.name);
		EditorGUI.indentLevel++;
		EditorGUILayout.BeginHorizontal ();
		
		
		EditorGUILayout.EndHorizontal ();
		if (GUI.changed)
			EditorUtility.SetDirty (target);
		foreach (Waypoint w in p.waypoints()) {
			Vector3 v = Handles.PositionHandle(w.transform.position, Quaternion.identity);
		}
	}

	public void OnSczeneGUI()	{

	}
}