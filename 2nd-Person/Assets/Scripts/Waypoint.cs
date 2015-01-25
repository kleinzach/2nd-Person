using UnityEngine;
using System.Collections;

public class Waypoint : Usable {

	public Waypoint next;
	public Vector3 pos;

	public float speed;

	public bool open;

	public Usable[] targets = new Usable[0];

	public override void use(){
		open = true;
	}

	public void trigger(){
		foreach(Usable target in targets){
			if (target != null)
				target.use ();
		}
	}

	public void Start(){
		pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}

	public void drawGizmo(Color c){
		Gizmos.color = c;
		Gizmos.DrawSphere(transform.position, 0.45f);
	}

	public void drawLinks(){
		Vector3 v = new Vector3 (0.05f, 0.05f, 0.05f);
		Gizmos.color = Color.magenta;
		if (next != null)
			Gizmos.DrawLine (transform.position - v, next.transform.position - v);
		Gizmos.color = Color.yellow;
		foreach(Usable u in targets){
			if (u != null)
				Gizmos.DrawLine (transform.position + v, u.transform.position + v);
		}
	}


}
