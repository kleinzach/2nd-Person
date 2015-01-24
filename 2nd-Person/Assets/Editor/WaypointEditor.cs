using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		Waypoint w = (Waypoint)target;
		CustomEditorUtil.text(w.name);
		EditorGUI.indentLevel++;
		w.speed = EditorGUILayout.FloatField("Speed", w.speed);
		w.position = (Vector2)EditorGUILayout.Vector2Field("Position", w.position);
		w.next = (Waypoint)EditorGUILayout.ObjectField("Next Waypoint", w.next, typeof(Waypoint), true, null);
		w.open = EditorGUILayout.Toggle("Available", w.open);
		EditorGUILayout.BeginHorizontal ();
		if (GUILayout.Button ("Use"))
			w.use();
		if (GUILayout.Button ("Trigger"))
			w.trigger();
		EditorGUILayout.EndHorizontal ();
		if (GUI.changed)
			EditorUtility.SetDirty (target);
	}
}