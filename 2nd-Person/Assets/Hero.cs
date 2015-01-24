using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : PathFollower {

	public Text textbox;

	public string[] blockedText;
	public string[] unblockedText;

	private bool blocked;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(!nextWaypoint.open && !blocked){
			blocked = true;
			textbox.text = randomString(blockedText);
		}
		if(blocked && nextWaypoint.open){
			blocked = false;
			textbox.text = randomString(unblockedText);
		}
	}

	string randomString(string[] strings){
		return strings[(int)(Random.value * strings.Length)];
	}
}
