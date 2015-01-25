using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class SingleUsePlayerDetector : MonoBehaviour {

	public Usable[] target;

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			foreach(Usable u in target){
				u.use();
			}
			Destroy(this.gameObject);
		}
	}
}
