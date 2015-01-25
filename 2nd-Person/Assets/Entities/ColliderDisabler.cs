using UnityEngine;
using System.Collections;

public class ColliderDisabler : Usable {

	public Collider target;

	public override void use(){
		target.isTrigger = target.isTrigger;
	}
}
