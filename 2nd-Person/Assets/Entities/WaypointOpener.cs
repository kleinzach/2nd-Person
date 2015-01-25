using UnityEngine;
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

	public void OnDrawGizmosSelected(){
		drawLinks();
	}
	
	public void drawLinks(){
		Vector3 v = new Vector3 (0.05f, 0.05f, 0.05f);

		Gizmos.color = Color.green;
		if (blockedWaypoint != null)
			Gizmos.DrawLine (transform.position + v, blockedWaypoint.transform.position + v);
		Gizmos.color = Color.red;
		if (target != null)
			Gizmos.DrawLine (transform.position + v, target.transform.position + v);
	}
}
