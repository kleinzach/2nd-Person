using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System;
using System.Reflection;


[CustomEditor(typeof(Path))]
public class PathEditor : Editor {
	public override void OnInspectorGUI()	{
		Path p = (Path)target;
		CustomEditorUtil.text(p.name);
		EditorGUI.indentLevel++;
		EditorGUILayout.BeginHorizontal ();
		p.color = EditorGUILayout.ColorField ("Gizmo Color", p.color);
		if (GUILayout.Button("Hide path handle"))
			Path.hide = !Path.hide;
		EditorGUILayout.EndHorizontal ();
		if (GUI.changed)
			EditorUtility.SetDirty (target);
	}

	public void OnSceneGUI()	{
		Path p = (Path) target;
		foreach (Waypoint w in p.waypoints())
			w.transform.position = Handles.PositionHandle(w.transform.position, Quaternion.identity);
	}


}