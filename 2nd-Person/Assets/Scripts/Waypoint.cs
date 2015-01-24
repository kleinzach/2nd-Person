using UnityEngine;
using System.Collections;

public class Waypoint : Usable{

	public Waypoint next;

	public float speed;

	public bool open;

	public Usable target;

	public override void use(){
		open = true;
	}

	public void trigger(){
		if (target != null)
			target.use ();
	}

	public void OnDrawGizmosSelected(){
		Gizmos.color = Color.cyan;
		Transform t = transform.parent;
		if (t != null){
			Path p = t.gameObject.GetComponent<Path>();
			if (p != null)
				foreach (Waypoint w in p.waypoints())
					if (w != this)
						Gizmos.DrawSphere(w.transform.position, 0.5f);
		}
	}
}
