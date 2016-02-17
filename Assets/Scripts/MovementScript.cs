using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	private bool up;
	private bool down;
	private bool left;
	private bool right;

	Rigidbody2D myRigidbody;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		up = Input.GetKey(KeyCode.UpArrow);
		down = Input.GetKey(KeyCode.DownArrow);
		left = Input.GetKey(KeyCode.LeftArrow);
		right = Input.GetKey(KeyCode.RightArrow);

	}

	void FixedUpdate(){

		myRigidbody.velocity = new Vector2((right ? 1 : 0) - (left ? 1 : 0), (up ? 1 : 0) - (down ? 1 : 0));

	}
}
