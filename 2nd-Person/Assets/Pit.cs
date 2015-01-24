using UnityEngine;
using System.Collections;

public class Pit : Usable {

	public Collider target;

	public override void use(){
		target.isTrigger = false;
	}
}
