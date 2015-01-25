using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Usable))]
public class UsableEditor : Editor {

	public override void OnInspectorGUI(){
		Usable u = (Usable)target;
		CustomEditorUtil.text(u.name);
		if (GUILayout.Button ("Use"))
			u.use();
	}


}
