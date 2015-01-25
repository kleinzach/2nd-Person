using UnityEngine;
using System.Collections;

public class ColliderDisabler : Usable {

	public Collider target;

	public override void use(){
		target.isTrigger = !target.isTrigger;
	}

	public void OnDrawGizmosSelected(){
		drawLinks();
	}
	
	public void drawLinks(){
		Vector3 v = new Vector3 (0.05f, 0.05f, 0.05f);
		Gizmos.color = Color.green;
		if (target != null)
			Gizmos.DrawLine (transform.position + v, target.transform.position + v);
	}
}
