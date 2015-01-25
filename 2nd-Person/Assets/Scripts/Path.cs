using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	public static bool hide;
	public Color color = Color.cyan;

	[Range(0.1f, 2)]
	public float wSize = 0.5f;

	public List<Waypoint> waypoints(){
		List<Waypoint> ws = new List<Waypoint> ();
		foreach(Component c in GetComponentsInChildren(typeof(Waypoint))){
			ws.Add((Waypoint)c);
		}
		return ws;
	}


	public void OnDrawGizmosSelected(){
		foreach(Waypoint w in waypoints()){
			w.drawLinks();
		}
	}

	public void OnDrawGizmos(){
		foreach(Waypoint w in waypoints()){
			w.drawGizmo(color);
		}
	}
}
