using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour {

	public Usable target;

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			if(target != null){
				target.use();
				Destroy(this.gameObject);
			}
		}
	}
}
