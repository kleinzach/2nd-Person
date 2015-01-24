using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour {

	public float speed;
	public float jumpForce = 10;
	public float gravity = -9.81f;

	public float jumpTime;
	private float jumping;

	private float distToGround = 0;

	private Vector3 velocity = new Vector3();

	private bool climbing = false;
	private bool canClimb = false;

	void Start(){
		distToGround = collider.bounds.extents.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		float jump = Input.GetAxis("Jump");

		Collider other = Ground();
		bool onGround = other != null;

		velocity.x = h * speed;

		this.rigidbody.AddForce(h * speed,0,0);
		jumping -= Time.fixedDeltaTime;
		if(onGround && jump > .5f){
			jumping = jumpTime;
		}
		if(jump > .5f && jumping > 0){
			Debug.Log("Jump");
			velocity.y += jumpForce;
		}
		else if(jump <= .5f){
			jumping = 0;
		}
		if(!onGround && jumping <= 0){

			velocity.y -= gravity;
		}

		if(other != null){
			Debug.Log ("Bounce");
			if(other.gameObject.layer == LayerMask.NameToLayer("Mushroom")){
				velocity.y = other.gameObject.GetComponent<Bouncy>().bounceForce;
			}
		}

		this.rigidbody.velocity = velocity;
	}

	Collider Ground() {
		RaycastHit hit;
		Physics.Raycast(transform.position, -Vector3.up, out hit, distToGround + 0.1f);
		return hit.collider;
	}

	void OnTriggerEnter(){
		canClimb = true;
	}

	void OnTriggerExit(){
		canClimb = false;
	}

}
