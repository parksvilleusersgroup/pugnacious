using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public GameObject player;

	private Vector3 cameraPos;
	private float cameraSize;

	// Use this for initialization
	void Start () {
		cameraSize = ((Camera)transform.gameObject.GetComponent("Camera")).orthographicSize / 2;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("current camera x is " + transform.position.x +
		//	       ", current player x is " + player.transform.position.x +
		//           ", owner is " + transform.gameObject.ToString());
		//float y = transform.position.y;
		//float z = transform.position.z;
		float x = player.transform.position.x;
		if (transform.position.x - cameraSize > x - 2.0f) {
			Debug.Log ("camera size = " + cameraSize);
			//transform.position.Set(x - 1.0f, y, z);
			transform.position = transform.position + Vector3.left;
		}else if (transform.position.x + cameraSize < x + 2.0f) {
			Debug.Log ("camera x < player x");
			//transform.position.Set(x + 1.0f, y, z);
			transform.position = transform.position + Vector3.right;
		}
	}
}
