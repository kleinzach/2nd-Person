using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
public class Player : MonoBehaviour {

	public float speed;
	public float jumpForce = 10;
	public float gravity = -9.81f;

	private float distToGround = 0;

	private Vector3 velocity = new Vector3();
	public float maxFallSpeed;

	private float h;
	private float v;
	private float jump;

	private bool climbing = false;
	public bool canClimb = false;
	public float climbSnap = 0;

	public bool springing;

	private Animator anim;

	public Transform scalar;

	private bool dead = false;
	private float deathTimer = 5;

	void Start(){
		distToGround = collider.bounds.extents.y;
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if(dead){
			deathTimer -= Time.fixedDeltaTime;
			velocity.x = 0;
			velocity.y -= gravity*Time.fixedTime;
			this.rigidbody.velocity = velocity;
			if(deathTimer <= 0f){
				reset();
			}
			return;
		}

		h = Input.GetAxis("Horizontal");
		v = Input.GetAxis("Vertical");

		jump = Input.GetAxis("Jump");

		Collider other = Ground();
		bool onGround = other != null;

		velocity.x = h * speed;

		anim.SetBool("Run",(Mathf.Abs(h) > .125));

		if(onGround && jump > .5f && other.gameObject.tag != "Spring"){
			velocity.y = jumpForce;
			springing = false;
		}
		if(jump < .5f && velocity.y > 0 && !springing){
			velocity.y = 0;
		}
		if(!onGround && !climbing){
			velocity.y -= gravity * Time.fixedDeltaTime;
		}

		handleClimb();

		velocity.y = Mathf.Max(velocity.y,-maxFallSpeed);

		anim.SetBool("Jump",!onGround);
		anim.SetBool("Climb",climbing);
		
		if(other != null){
			if(other.gameObject.layer == LayerMask.NameToLayer("Mushroom")){
				Bouncy b = other.gameObject.GetComponent<Bouncy>();
				velocity.y = b.bounceForce;
				b.bounce();
				springing = true;
			}
		}

		anim.SetBool("Hanging",climbing && Mathf.Abs(velocity.y)<.25f);

		if(Mathf.Abs(h) > .1)
			scalar.transform.localScale = new Vector3(h > 0?-1:1,1,1);
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
			velocity.y = jumpForce;
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

	public void die(){
		if(!dead){
			anim.SetTrigger("Die");
			dead = true;
			deathTimer = 2;
			velocity.x = 0;
		}	
	}

	public void handleState(Collider other){
		if(other != null){
			anim.SetBool("Run",Mathf.Abs(velocity.x)>.1f );
		}
		if(other.gameObject == null){
			anim.SetBool("Jump",true);
		}
	}

}
