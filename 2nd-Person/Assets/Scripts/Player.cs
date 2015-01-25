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
	public float maxFallSpeed;

	private float h;
	private float v;
	private float jump;

	private bool climbing = false;
	public bool canClimb = false;
	public float climbSnap = 0;

	void Start(){
		distToGround = collider.bounds.extents.y;
	}

	// Update is called once per frame
	void FixedUpdate () {
		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		jump = Input.GetAxis("Jump");

		Collider other = Ground();
		bool onGround = other != null;

		velocity.x = h * speed;

		jumping -= Time.fixedDeltaTime;
		if(onGround && jump > .5f && other.gameObject.layer != LayerMask.NameToLayer("Mushroom")){
			jumping = jumpTime;
		}
		if(jump > .5f && jumping > 0){
			velocity.y += jumpForce;
		}
		else if(jump <= .5f){
			jumping = 0;
		}
		if(!onGround && jumping <= 0 && !climbing){

			velocity.y -= gravity;
		}

		handleClimb();

		velocity.y = Mathf.Max(velocity.y,-maxFallSpeed);
		
		if(other != null){
			if(other.gameObject.layer == LayerMask.NameToLayer("Mushroom")){
				Bouncy b = other.gameObject.GetComponent<Bouncy>();
				velocity.y = b.bounceForce;
				b.bounce();
			}
		}
		this.rigidbody.velocity = velocity;
	}

	Collider Ground() {
		RaycastHit hit;
		Physics.Raycast(transform.position, -Vector3.up, out hit, distToGround + 0.1f);
		return hit.collider;
	}

	void handleClimb(){
		if(canClimb && Mathf.Abs(v) >.5f){
			Debug.Log ("climb");
			velocity.y = 0;
			climbing = true;
			this.transform.position = new Vector3(climbSnap,this.transform.position.y,this.transform.position.z);
			velocity.x = 0;
		}
		if(climbing){
			velocity.y = v*speed;
			velocity.x = 0;
		}
		if(!canClimb){
			climbing = false;
		}
		if(climbing && jump > .5f){
			climbing = false;
			jumping = jumpTime;
			velocity.y += jumpForce;
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.gameObject.layer == LayerMask.NameToLayer("Rope")){
			canClimb = true;
			climbSnap = col.transform.position.x;
		}
	}

	void OnTriggerExit(Collider col){
		if(col.gameObject.layer == LayerMask.NameToLayer("Rope")){
			canClimb = false;
			climbSnap = col.transform.position.x;
		}
	}

	public void reset(){
		Application.LoadLevel(Application.loadedLevel);
	}

}
