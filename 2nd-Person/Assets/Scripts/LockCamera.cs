using UnityEngine;
using System.Collections;

public class LockCamera : MonoBehaviour {

	public GameObject target;
	public float distance;
	[Range(-Mathf.PI/4, Mathf.PI/4)]
	public float theta;
	[Range(0, Mathf.PI/4)]
	public float phi;

	void Start () {
		updateCamera ();
	}
	
	// Update is called once per frame
	void Update () {
		updateCamera ();
	}

	public void updateCamera(){
		if (target == null)
				return;
		Vector3 delta = new Vector3 (-Mathf.Sin (theta), Mathf.Sin (phi), -1);
		delta.Normalize ();
		transform.position = delta * distance + target.transform.position;
		transform.rotation = Quaternion.LookRotation (-delta);
		drawCamera(1);
	}

	public void drawCamera(float z){
		Camera camera = gameObject.camera;
		
		Vector3 s1 = camera.ScreenToWorldPoint(new Vector3(0, 0, 1));
		Vector3 s2 = camera.ScreenToWorldPoint(new Vector3(0, camera.pixelHeight, 1));
		Vector3 s3 = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, 0, 1));
		Vector3 s4 = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, 1));

		Vector3 r1 = transform.position - forceToZ(s1 - transform.position, z);
		Vector3 r2 = transform.position - forceToZ(s2 - transform.position, z);
		Vector3 r3 = transform.position - forceToZ(s3 - transform.position, z);
		Vector3 r4 = transform.position - forceToZ(s4 - transform.position, z);

		Color c = Color.red;
	
		Debug.DrawLine (r1, r2, c);
		Debug.DrawLine (r2, r4, c);
		Debug.DrawLine (r4, r3, c);
		Debug.DrawLine (r3, r1, c);
		Debug.DrawLine (r1, r4, c);
		Debug.DrawLine (r3, r2, c);
		Debug.DrawLine (transform.position, r2, c);
		Debug.DrawLine (transform.position, r4, c);
		Debug.DrawLine (transform.position, r3, c);
		Debug.DrawLine (transform.position, r1, c);
	}

	/**
	 * Takes a direction vector and forces it to the z plane. The vector returned is such that (transform.position - the vector) results in a point on the x-y plane with z coordinate equal to z.
	 * v.z should not be 0.
	 **/
	private Vector3 forceToZ(Vector3 v, float z){
		v *= (transform.position.z - z) / Mathf.Abs(v.z);
		return v;
	}
}
