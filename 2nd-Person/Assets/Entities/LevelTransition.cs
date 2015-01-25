using UnityEngine;
using System.Collections;

public class LevelTransition : Usable {

	public string level = "";

	public override void use ()
	{
		if(level.Length == 0)
			Application.LoadLevel(Application.loadedLevel+1);
		else {

			Application.LoadLevel(level);
		}
	}
}
