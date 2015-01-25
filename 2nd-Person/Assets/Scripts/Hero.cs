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

	public float textWaitTime = 20;
	private float textWaiting = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		textTime -= Time.deltaTime;
		textWaiting -= Time.deltaTime;

		if(nextWaypoint == null){
			return;
		}
		if(!nextWaypoint.open && !blocked && textWaiting <= 0){
			blocked = true;
			textbox.transform.parent.gameObject.SetActive(true);
			textbox.text = randomString(blockedText);
			textTime = textDuration;
			textWaiting = textWaitTime;
		}
		if(blocked && nextWaypoint.open){
			blocked = false;
			textbox.transform.parent.gameObject.SetActive(true);
			textbox.text = randomString(unblockedText);
			textTime = textDuration;
			textWaiting = textWaitTime;
		}
		if(textTime <= 0){
			textbox.transform.parent.gameObject.SetActive(false);
		}
	}

	string randomString(string[] strings){
		return strings[(int)(Random.value * strings.Length)];
	}

	public void attack(){

	}
}
