using UnityEngine;
using System.Collections;

public class Waypoint : Usable{

	public Waypoint next;

	public float speed;

	public bool open;

	public Usable target;

	public void use(){
		open = true;
	}

	public void trigger(){
		if (target != null)
			target.use ();
	}
}
