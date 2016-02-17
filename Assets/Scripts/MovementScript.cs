using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	private bool up;
	private bool down;
	private bool left;
	private bool right;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		up = Input.GetKey(KeyCode.UpArrow);
		down = Input.GetKey(KeyCode.DownArrow);
		left = Input.GetKey(KeyCode.LeftArrow);
		right = Input.GetKey(KeyCode.RightArrow);

	}

	void FixedUpdate(){

		Rigidbody2D myRigidbody = GetComponent<Rigidbody2D>();

		myRigidbody.velocity = new Vector2((right ? 1 : 0) - (left ? 1 : 0), (up ? 1 : 0) - (down ? 1 : 0));

	}
}
