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
		Debug.DrawLine (transform.position, transform.position + -delta * distance, Color.red);
	}
}
