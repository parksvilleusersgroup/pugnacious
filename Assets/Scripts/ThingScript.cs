using UnityEngine;
using System.Collections;


public class ThingScript : MonoBehaviour {

	public const float speed = 10.0f;
	public const float jumpHeight = 3.0f;
	public const float jumpTime = 0.2f;
	public Transform thing;

	private float baseY;

	public float startY;
	public float endY;
	private float startTime;
	private float jumpDist;
	private bool isJumping;

	// Use this for initialization
	void Start () {
		baseY = thing.position.y + 0.2f;
		Debug.Log ("baseY is " + baseY);
	}
	
	// Update is called once per frame
	void Update () {
		float x = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		float y = yDelta ();
		//Debug.Log ("yDelta = " + y);
		thing.Translate (x, y, 0f);
	}

	float yDelta(){
		float yDelta = Input.GetAxis ("Vertical");
		//Debug.Log ("current y is " + thing.transform.position.y);
		if (thing.transform.position.y < baseY && yDelta > 0f && !isJumping) {
			return startJump ();
		} else if (isJumping) {
			return continueJump();
		}
		return 0f;
	}

	float startJump(){
		Debug.Log ("start jump");
	    startTime = Time.time;
		startY = thing.position.y;
		endY = startY + jumpHeight;
		//Debug.Log ("startY = " + startY + ", endY = " + endY);
		isJumping = true;
		return 0f;
	}

	float continueJump(){
		float timeSinceJump = (Time.time - startTime);
		float jumpTimeFraction = timeSinceJump / jumpTime;
		//Debug.Log ("Continuing jump at time fraction: " + jumpTimeFraction);
		if (jumpTimeFraction > 1.0f) {
			isJumping = false;
			return 0;
		}
		float currY = thing.transform.position.y;
		float targetDeltaY = distance(startY, endY) * jumpTimeFraction;
		float deltaY = startY + targetDeltaY - currY;
		//Debug.Log ("currY = " + currY + ", targetDeltaY = " + targetDeltaY +
		//           ", deltaY = " + deltaY + ", startY = " + startY + ", endY = " +
		//           endY);
		return deltaY;
	}

	float distance(float a, float b){
		return Vector3.Distance (new Vector3 (a, 0f, 0f), new Vector3 (b, 0f, 0f));
	}


}
