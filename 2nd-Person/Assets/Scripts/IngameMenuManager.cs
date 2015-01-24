using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameMenuManager : MonoBehaviour {

	public Canvas menu;

	// Use this for initialization
	void Start () {
		menu.gameObject.SetActive(false);
	}
	
	public void toggleMenu(){
		bool newState = !menu.gameObject.activeSelf;
		menu.gameObject.SetActive(newState);
		if(newState){
			Time.timeScale = 0f;
		}
		else{
			Time.timeScale = 1f;
		}
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			toggleMenu();
		}
	}
}
