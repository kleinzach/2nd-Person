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
		w.transform.position = (Vector2)EditorGUILayout.Vector2Field("Position", w.transform.position);
		w.next = (Waypoint)EditorGUILayout.ObjectField("Next Waypoint", w.next, typeof(Waypoint), true, null);
		w.target = (Usable)EditorGUILayout.ObjectField("Trigger Target", w.target, typeof(Usable), true, null);
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

	public void OnSceneGUI()	{
		Waypoint www = ((Waypoint)target);
		Transform t = www.transform.parent;
		if (t != null){
			Path p = t.gameObject.GetComponent<Path>();
			if (p != null)
				foreach (Waypoint w in p.waypoints())
					if (www != w)
						w.transform.position = Handles.PositionHandle(w.transform.position, Quaternion.identity);
		}
	}


}