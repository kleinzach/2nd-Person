using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour {

	public float bounceForce;

	private Animator anim;



	void Start(){
		anim = GetComponent<Animator>();
		renderer.sortingLayerName = "Scene";
	}

	public void bounce(){
		anim.SetTrigger("spring");
		this.particleSystem.Emit(1000);
		this.audio.Play();
	}

}
