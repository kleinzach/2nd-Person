using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

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
		Gizmos.color = Color.cyan;
		foreach(Waypoint w in waypoints()){
			Gizmos.DrawSphere(w.position, wSize);
		}
	}
}
