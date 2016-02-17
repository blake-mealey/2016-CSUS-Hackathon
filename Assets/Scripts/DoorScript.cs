using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour, InteractInterface {

	public string message = "Press 'E' to go through the door.";
    public string message2 = "I got through.";
	public bool locked = false;
	public Vector3 toPosition;

	private bool movePlayer = false;
	private float ctime = 0;
	private float moveTime = 0;
	private Transform player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(movePlayer == true){
			ctime+=Time.deltaTime;
			if(ctime>=moveTime){
				player.transform.position = toPosition;
				movePlayer = false;
				UIController.instance.setText(2, message2);
			}
		}
	}
	//enters door influence
	void OnTriggerEnter2D(Collider2D collider){
		UIController.instance.setText(2, message);
		collider.transform.GetComponent<PlayerInteractScript>().addAction((InteractInterface)this);
		player = collider.transform;
        ctime = 0;
	}
	//leaves door influence
	void OnTriggerExit2D(Collider2D collider){
		collider.transform.GetComponent<PlayerInteractScript>().removeAction();
    }
	public void doAction(){
		UIController.instance.cameraFade(1f,0.5f);
		movePlayer = true;
		moveTime = 1.1f;
	}
}
