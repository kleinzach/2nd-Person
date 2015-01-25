using UnityEngine;
using System.Collections;

public class Enemy : PathFollower {

	Player p;

	Hero h;

	public float killDistance;

	// Use this for initialization
	void Start () {
		p = GameObject.FindObjectOfType<Player>();
	}

	void FixedUpdate () {
		Vector3 pos = this.transform.position;
		if((p.transform.position - pos).magnitude < killDistance){
			p.reset();
		}
		if((h.transform.position - pos).magnitude < killDistance){
			h.attack();
			Destroy(this.gameObject);
		}
	}
}
