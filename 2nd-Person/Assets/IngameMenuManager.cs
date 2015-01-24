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
		menu.gameObject.SetActive(!menu.gameObject.activeSelf);
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Escape)){
			toggleMenu();
		}
	}
}
