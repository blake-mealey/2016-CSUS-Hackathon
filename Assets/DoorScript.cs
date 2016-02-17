using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	public string message = "Press 'E' to go through the door.";
	public bool locked = false;
	public Vector3 toPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//enters door influence
	void OnTriggerEnter2D(Collider2D collider){
		UIController.instance.setText(2, message);
	}
	//leaves door influence
	void OnTriggerExit2D(Collider2D collider){

	}
}
