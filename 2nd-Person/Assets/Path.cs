using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Path : MonoBehaviour {

	public List<Waypoint> waypoints = new List<Waypoint>();
	private List<int> ids = new List<int>();


	void Start () {
	
	}

	void Update () {
	
	}

	public Waypoint getWaypoint(int id){
		return waypoints [id];
	}

	public void newWaypoint(){
		if (ids.Count != 0){
			waypoints[ids[0]] = new Waypoint(this, ids[0]);
			ids.RemoveAt(0);
		}
		else
			waypoints.Add(new Waypoint(this, waypoints.Count));
	}

	public void removeWaypoint(Waypoint w){
		waypoints.Remove(w);
		ids.Add (w.id);
	}
}
