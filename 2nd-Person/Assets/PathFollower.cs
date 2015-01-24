using UnityEngine;
using System.Collections;

public class PathFollower : MonoBehaviour {

	public Path path;
	public Waypoint nextWaypoint;
	
	// Update is called once per frame
	void FixedUpdate () {
		if(nextWaypoint != null && nextWaypoint.open){
			float speed = nextWaypoint.speed;
			Vector2 diff = nextWaypoint.transform.position - this.transform.position;
			this.transform.Translate((diff).normalized * speed);
			if(diff.magnitude < speed){
				arrive();
			}
		}
	}

	void arrive(){
		this.transform.position = nextWaypoint.transform.position;
		nextWaypoint.trigger();
		nextWaypoint = nextWaypoint.next;
	}
}
