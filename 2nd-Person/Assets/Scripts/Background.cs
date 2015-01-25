using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	public float scrollSpeed;
	public float x;
	private float lastX;
	public string sortinglayer = "Default";

	void Start () {
		x = Random.value;
	}

	void Update () {
		renderer.sortingLayerName = sortinglayer;
		float dx = x - transform.position.x * scrollSpeed;
		if (lastX != dx){
			GetComponent<MeshFilter>().mesh.uv = new Vector2[]{new Vector2(1 + dx, 0), new Vector2(dx, 1), new Vector2(dx, 0), new Vector2(1 + dx, 1)};
			lastX = dx;
		}
	}
}
