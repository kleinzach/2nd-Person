using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class SingleUsePlayerDetector : MonoBehaviour {

	public Usable[] target;

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			activate();
		}
	}
	
	public void activate(){
		foreach(Usable u in target)
			if(u != null){
				u.use();
			}
		Destroy(this.gameObject);
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
