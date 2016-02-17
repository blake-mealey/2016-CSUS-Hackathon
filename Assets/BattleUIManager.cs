using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

	public GameObject options;
	public GameObject attacks;
	public GameObject items;

	// Use this for initialization
	void Start () {
		options.SetActive(true);
		attacks.SetActive(false);
		items.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void openMenu(int menu){

		options.SetActive(false);
		attacks.SetActive(false);
		items.SetActive(false);

		switch(menu){
		case 0:
			options.SetActive(true);
			break;
		case 1:
			attacks.SetActive(true);
			break;
		case 2:
			items.SetActive(true);
			break;
		}

	}

}
