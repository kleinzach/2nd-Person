using UnityEngine;
using System.Collections;

public class Waypoint : Usable {

	public Waypoint next;

	public float speed;

	public bool open;

	// Use this for initialization
	void Start () {
	
	}
	
	public override void use(){
		open = true;
	}
}
