using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {

	public float bounceForce;

	private Animator anim;



	void Start(){
		anim = GetComponent<Animator>();
	}

	public void bounce(){
		anim.SetTrigger("spring");
		Debug.Log ("spring");
		this.particleSystem.Emit(100);
		this.audio.Play();
	}

}
