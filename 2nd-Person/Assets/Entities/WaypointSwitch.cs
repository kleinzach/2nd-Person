using UnityEngine;
using System.Collections;

public class WaypointSwitch : Usable {

	public Waypoint waypoint;
	public Waypoint target;

	public override void use (){
		Waypoint t = waypoint.next;
		waypoint.next = target;
		target = t;
	}

}
