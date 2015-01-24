using UnityEngine;
using UnityEditor;
/*

[CustomPropertyDrawer (typeof (Waypoint))]
public class WaypointDrawer : PropertyDrawer {
	
	public override float GetPropertyHeight (SerializedProperty prop, GUIContent label) {
		return calculateHeight (prop);
	}

	public static void construct(SerializedProperty prop){
	}
	
	public static float calculateHeight(SerializedProperty prop){
		if (prop == null)
			return EditorUtil.row;
		if (prop.FindPropertyRelative("folded").boolValue)
			return EditorUtil.row;
		return 5 * EditorUtil.row;
	}
	
	public override void OnGUI (Rect pos, SerializedProperty prop, GUIContent label) {
		SerializedProperty id = prop.FindPropertyRelative ("id");
		SerializedProperty speed = prop.FindPropertyRelative ("speed");
		SerializedProperty open = prop.FindPropertyRelative ("open");
		//SerializedProperty triggeredObject = prop.FindPropertyRelative ("triggeredObject");
		SerializedProperty folded = prop.FindPropertyRelative ("folded");

		bool fold = folded.boolValue;

		EditorUtil.folder (pos.x + EditorGUI.indentLevel * 12, pos.y, folded);
		GUI.Label (new Rect (pos.x + EditorUtil.buttonSize, pos.y, pos.width - 2 * EditorUtil.buttonSize, EditorUtil.height), "Waypoint #" + id);
	
		EditorGUI.indentLevel++;
		//if (!folded.boolValue){
			EditorGUI.PropertyField (new Rect (pos.x, pos.y + EditorUtil.row, pos.width, EditorUtil.height), speed, new GUIContent("Speed"));
			EditorGUI.PropertyField (new Rect (pos.x, pos.y + EditorUtil.row, pos.width, EditorUtil.height), open, new GUIContent("Whether this waypoint is accessible"));
//			EditorGUI.ObjectField (new Rect (pos.x, pos.y + EditorUtil.row, pos.width, EditorUtil.height), triggeredObject, new GUIContent("Object triggered when wapoint is reached"), Trigger.GetType());
		//}
		EditorGUI.indentLevel--;

		prop.serializedObject.ApplyModifiedProperties ();
	}
	
	
}*/