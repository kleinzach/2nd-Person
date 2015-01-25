using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class SingleUsePlayerDetector : MonoBehaviour {

	public Usable[] target;

	public Animator anim;

	public bool used = false;

	void Start(){
		anim = GetComponent<Animator>();
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			activate();
		}
	}
	
	public void activate(){
		if(used){
			return;
		}
		this.collider.isTrigger = true;
		used = true;
		foreach(Usable u in target){
			if(u != null){
				u.use();
			}
		}

		anim.SetTrigger("Use");
	}
	
	public void OnDrawGizmosSelected(){
		drawLinks();
	}
	
	public void drawLinks(){
		Vector3 v = new Vector3 (0.05f, 0.05f, 0.05f);
		Gizmos.color = Color.yellow;
		foreach(Usable u in target){
			if (u != null)
				Gizmos.DrawLine (transform.position + v, u.transform.position + v);
		}
	}
}
