using UnityEngine;
using System.Collections;

public class Waypoint : Usable{
	public Path path;
	public int id;

	public bool folded;

	public Vector2 position;
	public Waypoint next;

	public float speed;

	public bool open;

	public Waypoint(Path path, int id){
		this.path = path;
		this.id = id;
	}

	//public Usable triggeredObject;

	public void use(){
		open = true;
	}

	public void trigger(){
//		if(triggeredObject != null){
//			triggeredObject.use();
	//	}
	}
}
