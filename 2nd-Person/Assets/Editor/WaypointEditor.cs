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

		w.targets = CustomEditorUtil.array("Targets", w.targets);
		//for(int i = 0; i < w.targets.Length; i++)
		//	w.targets[i] = (Usable)EditorGUILayout.ObjectField("Targets #" + i, w.targets[i], typeof(Usable), true, null);
		w.open = EditorGUILayout.Toggle("Available", w.open);
		EditorGUILayout.BeginHorizontal();
		if (GUILayout.Button ("Use"))
			w.use();
		if (GUILayout.Button ("Trigger"))
			w.trigger();
		EditorGUILayout.EndHorizontal ();
		if (GUI.changed)
			EditorUtility.SetDirty (target);
	}
	/*
	public void OnSceneGUI()	{
		Waypoint w = ((Waypoint)target);
		drawPoint(w.transform.position, 0.5f, Color.cyan);
		if (w.next != null)
			drawArrow(w.transform.position, w.next.transform.position, 3, Color.magenta);
		foreach (Usable u in w.targets)
		if (u != null){
			drawPoint(u.transform.position, 0.5f, Color.cyan);
			drawArrow(w.transform.position, u.transform.position, 3, Color.white);
		}
		w.transform.position = Handles.PositionHandle(w.transform.position, Quaternion.identity);
	}

	private void drawArrow(Vector3 position, Vector3 dest, float size, Color c){
		//if (Event.current.type == EventType.Layout)
		Handles.color = c;
		Handles.DrawLine (position, dest);
		//GUIUtility.GetControlID()
		Vector3 d = (dest - position).normalized * size;
		Handles.ArrowCap (1, dest - d, Quaternion.FromToRotation (d, Vector3.back), size);
	}
	
	private void drawPoint(Vector3 point, float size, Color c){
		//if (Event.current.type == EventType.Layout)
		Handles.color = c;
		Handles.DrawSolidDisc (point, Camera.current.transform.position - point, size);
		//GUIUtility.GetControlID()
	}
	*/

}