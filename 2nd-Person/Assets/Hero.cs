using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hero : PathFollower {

	public Text textbox;

	public string[] blockedText;
	public string[] unblockedText;

	private bool blocked;

	public float textDuration;
	private float textTime;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		textTime -= Time.deltaTime;
		if(nextWaypoint == null){
			return;
		}
		if(!nextWaypoint.open && !blocked){
			blocked = true;
			textbox.text = randomString(blockedText);
			textTime = textDuration;
		}
		if(blocked && nextWaypoint.open){
			blocked = false;
			textbox.text = randomString(unblockedText);
			textTime = textDuration;		
		}
		if(textTime <= 0){
			textbox.gameObject.SetActive(false);
		}
	}

	string randomString(string[] strings){
		return strings[(int)(Random.value * strings.Length)];
	}
}
