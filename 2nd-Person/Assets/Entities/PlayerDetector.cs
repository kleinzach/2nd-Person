using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class PlayerDetector : MonoBehaviour {
	
	public Usable[] targets = new Usable[0];
	
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			activate ();
		}
	}

	public void activate(){
		foreach(Usable target in targets)
			if(target != null){
				target.use();
			}
	}

	public void OnDrawGizmosSelected(){
		drawLinks();
	}

	public void drawLinks(){
		Vector3 v = new Vector3 (0.05f, 0.05f, 0.05f);
		Gizmos.color = Color.yellow;
		foreach(Usable u in targets){
			if (u != null)
				Gizmos.DrawLine (transform.position + v, u.transform.position + v);
		}
	}
}
