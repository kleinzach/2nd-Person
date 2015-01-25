using UnityEngine;
using System.Collections;


[RequireComponent(typeof(MeshFilter))]
public class Vine : MonoBehaviour {

	public int index = 0;
	public float segmentHeight = 0.1f;

	private int vines = 8;

	private Mesh m;

	private int oldIndex = 0;
	private float oldSeg = 0;
	private float oldWidth = 1;
	private float oldHeight = 1;
	// Use this for initialization
	void Start () {
		m = new Mesh ();
		GetComponent<MeshFilter>().mesh = null;
		GetComponent<MeshFilter>().mesh = m;

		int i = (index % vines);
		float k = Mathf.Clamp(segmentHeight / transform.localScale.y, 0.001f, 1);
		float dx = 1f / vines / 2;
		m.vertices = new Vector3[]{
			new Vector3(-0.5f, -0.5f), new Vector3(0.5f, -0.5f), 
			new Vector3(-0.5f, k - 0.5f), new Vector3(0.5f, k - 0.5f), 
			new Vector3(-0.5f, k - 0.5f), new Vector3(0.5f, k - 0.5f), 
			new Vector3(-0.5f, 0.5f), new Vector3(0.5f, 0.5f)
		};
		m.uv = new Vector2[]{
			new Vector2((vines + i) * dx, 0), new Vector2((vines + i + 1) * dx, 0), 
			new Vector2((vines + i) * dx, 1), new Vector2((vines + i + 1) * dx, 1), 
			new Vector2(i * dx, 0), new Vector2((i + 1) * dx, 0), 
			new Vector2(i * dx, 1/k-1), new Vector2((i + 1) * dx, 1/k-1)
		};
		m.triangles = new int[]{0, 2, 1, 1, 2, 3, 4, 6, 5, 5, 6, 7};
		m.name = "Ladder Mesh Instance";
		m.RecalculateNormals ();
		m.RecalculateBounds ();
	}

	public void updateMesh(){
		int i = (index % vines);
		float k = Mathf.Clamp(segmentHeight / transform.localScale.y, 0.001f, 1);
		float dx = 1f / vines / 2;
		m.vertices = new Vector3[]{
			new Vector3(-0.5f, -0.5f), new Vector3(0.5f, -0.5f), 
			new Vector3(-0.5f, k - 0.5f), new Vector3(0.5f, k - 0.5f), 
			new Vector3(-0.5f, k - 0.5f), new Vector3(0.5f, k - 0.5f), 
			new Vector3(-0.5f, 0.5f), new Vector3(0.5f, 0.5f)
		};
		m.uv = new Vector2[]{
			new Vector2((vines + i) * dx, 0), new Vector2((vines + i + 1) * dx, 0), 
			new Vector2((vines + i) * dx, 1), new Vector2((vines + i + 1) * dx, 1), 
			new Vector2(i * dx, 0), new Vector2((i + 1) * dx, 0), 
			new Vector2(i * dx, 1/k-1), new Vector2((i + 1) * dx, 1/k-1)
		};
	}

	// Update is called once per frame
	void Update () {
		if (transform.localScale.x != oldWidth || transform.localScale.y != oldHeight || index != oldIndex || segmentHeight != oldSeg){
			oldWidth = transform.localScale.x;
			oldHeight = transform.localScale.y;
			oldIndex = index;
			oldSeg = segmentHeight;
			updateMesh();
		}
	}
}
