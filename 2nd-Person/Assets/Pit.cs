using UnityEngine;
using System.Collections;

public class Pit : Usable {

	public override void use(){
		this.collider.isTrigger = false;
	}
}
