using UnityEngine;
using System.Collections;

public class Switcher : Usable {

	public Waypoint startWaypoint;
	public Waypoint newTarget;

	public override void use ()
	{
		startWaypoint.next = newTarget;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
