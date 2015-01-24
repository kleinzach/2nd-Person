﻿using UnityEngine;
using System.Collections;

public class WaypointOpener : Usable {

	public Waypoint blockedWaypoint;
	public GameObject target;

	public override void use (){
		if(blockedWaypoint != null){
			blockedWaypoint.open = true;
		}
		GameObject.Destroy(target);
	}
}
