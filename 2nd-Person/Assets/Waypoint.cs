using UnityEngine;
using System.Collections;

public class Waypoint : Usable {

	public Waypoint next;

	public float speed;

	public bool open;

	public Usable triggeredObject;

	// Use this for initialization
	void Start () {
	
	}
	
	public override void use(){
		open = true;
	}

	public void trigger(){
		if(triggeredObject != null){
			triggeredObject.use();
		}
	}
}
