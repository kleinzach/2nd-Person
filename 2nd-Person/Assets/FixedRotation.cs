using UnityEngine;
using System.Collections;

public class FixedRotation : MonoBehaviour {

	Quaternion rotation;

	// Use this for initialization
	void Start () {
		rotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = rotation;
	}
}
