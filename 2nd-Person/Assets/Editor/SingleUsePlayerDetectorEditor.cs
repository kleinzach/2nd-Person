using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SingleUsePlayerDetector))]
public class SingleUsePlayerDetectorEditor : Editor {
	
	public override void OnInspectorGUI(){
		SingleUsePlayerDetector p = (SingleUsePlayerDetector)target;
		CustomEditorUtil.text(p.name);
		EditorGUI.indentLevel++;
		p.target = CustomEditorUtil.array("Targets", p.target);
		if (GUILayout.Button ("Trigger Collision"))
			p.activate();
		if (GUI.changed)
			EditorUtility.SetDirty (target);
	}
	
	
}