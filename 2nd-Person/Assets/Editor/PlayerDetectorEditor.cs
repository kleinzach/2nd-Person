using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PlayerDetector))]
public class PlayerDetectorEditor : Editor {

	public override void OnInspectorGUI(){
		PlayerDetector p = (PlayerDetector)target;
		CustomEditorUtil.text(p.name);
		EditorGUI.indentLevel++;
		p.targets = CustomEditorUtil.array("Targets", p.targets);
		if (GUILayout.Button ("Trigger Collision"))
			p.activate();
		if (GUI.changed)
			EditorUtility.SetDirty (target);
	}


}