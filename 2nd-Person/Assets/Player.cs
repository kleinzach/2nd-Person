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

	void Start(){
		distToGround = collider.bounds.extents.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		float jump = Input.GetAxis("Jump");

		bool onGround = IsGrounded();

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
		this.rigidbody.velocity = velocity;
	}

	bool IsGrounded() {
		return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
	}
}
