using UnityEngine;
using System.Collections;
using UnityEditor;

public class CustomEditorUtil{
	
	public const float padding = 8;
	public const float row = 20;
	public const float height = 16;
	public const float buttonSize = 20;
	public const float texSize = 100;
	private static Texture2D line{
		get{if (linex == null) linex = new Texture2D(1, 1, TextureFormat.ARGB32, true); return linex; }
	}
	private static Texture2D linex;
	private static GUIStyle lineStyle = new GUIStyle();

	static CustomEditorUtil(){
		lineStyle.normal.background = line;
	}

	public static bool plus(){
		return GUILayout.Button("", (GUIStyle)"OL Plus", GUILayout.Width(20));
	}

	public static bool minus(){
		return GUILayout.Button("", (GUIStyle)"OL Minus", GUILayout.Width(20));
	}

	public static bool ex(){
		return GUILayout.Button("", (GUIStyle)"WinBtnCloseWin", GUILayout.Width(20), GUILayout.Height(20));
	}
	
	public static bool folder(bool folded){
		if (!folded){
			if (plus())
				return folded = true;
		}
		else{
			if (minus())
				return folded = false;
		}
		return folded;
	}

	public static void text(string text){
		GUILayout.Label (text);
	}


	public static T[] array<T> (string label, T[] src) where T: Object{
		T[] t = src;

		GUILayout.BeginHorizontal();
		GUILayout.Space(14);
		text(label);
		if (plus()) {
			t = new T[src.Length + 1];
			for(int i = 0; i < src.Length; i++)
				t[i] = src[i];
		}
		if (minus () && t.Length > 0) {
			t = new T[src.Length - 1];
			for(int i = 0; i < t.Length; i++)
				t[i] = src[i];
		}
		GUILayout.EndHorizontal();

		
		GUILayout.BeginHorizontal();
		GUILayout.Space(20);
		GUILayout.BeginVertical();
		for(int i = 0; i < t.Length; i++){
			GUILayout.BeginHorizontal();
			t[i] = (T)EditorGUILayout.ObjectField(t[i], typeof(T), true, null);
			if(ex ()){
				T[] tt = new T[src.Length - 1];
				int c = 0;
				for(int j = 0; j < i; j++)
					tt[c++] = t[j];
				for(int j = i + 1; j < t.Length; j++)
					tt[c++] = t[j];
				t = tt;
			}
			GUILayout.EndHorizontal();
		}

		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		return t;
	}



	public static void foldLines(float x, float y, float[] i){
		if (i.Length == 0)
			return;
		float last = i[i.Length-1];
		EditorUtil.drawVLine(x - 5, y + 16, y + last + 8);
		foreach(float h in i)
			EditorUtil.drawHLine(x - 4, x, y + h + 8);
	}
	
	public static void textField(Rect rect, SerializedProperty text, bool editable, string hint){
		if (editable)
			EditorGUI.PropertyField (rect, text, new GUIContent ("", hint));
		else
			EditorGUI.LabelField (rect, new GUIContent (text.stringValue, hint));
	}

	public static void textField(Rect rect, SerializedProperty text, bool editable){
		textField (rect, text, editable, "");
	}

	public static void drawVLine(float x, float y1, float y2, Color color, float thickness){
		line.SetPixel(0, 0, color);
		line.Apply();
		GUI.Box(new Rect(x, y1, thickness, y2 - y1 + 1), GUIContent.none, lineStyle);
	}
	
	public static void drawHLine(float x1, float x2, float y, Color color, float thickness){
		line.SetPixel(0, 0, color);
		line.Apply();
		GUI.Box(new Rect(x1, y, x2 - x1 + 1, thickness), GUIContent.none, lineStyle);
	}

	public static void drawVLine(float x, float y1, float y2, Color color){
		drawVLine (x, y1, y2, color, 1);
	}

	public static void drawHLine(float x1, float x2, float y, Color color){
		drawHLine (x1, x2, y, color, 1);
	}
	
	public static void drawVLine(float x, float y1, float y2){
		drawVLine (x, y1, y2, Color.grey);
	}
	
	public static void drawHLine(float x1, float x2, float y){
		drawHLine (x1, x2, y, Color.grey);
	}
}
