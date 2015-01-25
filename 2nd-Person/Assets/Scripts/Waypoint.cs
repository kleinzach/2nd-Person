using UnityEngine;
using System.Collections;

public class Waypoint : Usable {

	public Waypoint next;
	public Vector3 pos;

	public float speed;

	public bool open;

	public Usable[] targets;

	public override void use(){
		open = true;
	}

	public void trigger(){
		foreach(Usable target in targets)
		if (target != null)
			target.use ();
	}

	public void Start(){
		pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
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
