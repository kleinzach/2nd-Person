using UnityEngine;
using System.Collections;

public class LevelTransition : Usable {
	
	public override void use ()
	{
		Application.LoadLevel(Application.loadedLevel+1);
	}
}
