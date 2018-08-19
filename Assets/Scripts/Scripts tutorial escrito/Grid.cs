using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class Grid : MonoBehaviour {
	
	public float cell_size = 2f;
	
	private float x, z;
	
	void Start() {
		x = 0f;
		z = 0f;
	}
	
	void Update () {
		x = Mathf.Round(transform.position.x / cell_size) * cell_size;
		z = Mathf.Round(transform.position.z / cell_size) * cell_size;
		transform.position = new Vector3(x, 0, z);
	}
	
}
