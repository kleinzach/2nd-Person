using UnityEngine;
using System.Collections;

public class Destructable : Usable {

	public Waypoint blockedWaypoint;

	public override void use ()
	{
		if(blockedWaypoint != null){
			blockedWaypoint.open = true;
		}
		Destroy(this.gameObject);
	}
}
