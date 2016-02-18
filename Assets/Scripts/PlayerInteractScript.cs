using UnityEngine;
using System.Collections;

public class PlayerInteractScript : MonoBehaviour {

	public bool canInteract = false;
	private InteractInterface action = null;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(canInteract && Input.GetKeyDown(KeyCode.E) && action!=null){
			action.doAction();
			canInteract = true;
		}

	}
	public void addAction(InteractInterface intInter){
		action = intInter;
		canInteract = true;
	}
	public void removeAction(){
		action = null;
		canInteract = false;
	}
}
