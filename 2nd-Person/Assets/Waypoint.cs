using UnityEngine;
using System.Collections;

[System.Serializable]
public class Waypoint : Usable {
	[SerializeField]
	private int id;
	[SerializeField]
	private bool folded;

	public Vector2 position;
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
