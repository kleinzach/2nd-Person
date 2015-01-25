using UnityEngine;
using System.Collections;

public class Enemy : PathFollower {

	Animator anim;

	Player p;

	Hero h;

	public float killDistance;
	public float attackDistance;

	// Use this for initialization
	void Start () {
		p = GameObject.FindObjectOfType<Player>();
		h = GameObject.FindObjectOfType<Hero>();
		anim = this.GetComponent<Animator>();
	}

	void FixedUpdate () {
		Vector3 pos = this.transform.position;
		if((p.transform.position - pos).magnitude < attackDistance){
			anim.SetTrigger("Attack");
		}
		if((p.transform.position - pos).magnitude < killDistance){
			p.reset();
		}
		if((h.transform.position - pos).magnitude < attackDistance){
			h.attack();
			Destroy(this.gameObject);
		}
	}
}
