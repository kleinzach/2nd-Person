using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {

	public float bounceForce;

	private Animator anim;



	void Start(){
		anim = GetComponent<Animator>();
		if(anim != null){
			anim.StopPlayback();
		}
	}

	public void bounce(){
		anim.Play("spring", -1, 0f);
		Debug.Log ("spring");
	}

}
