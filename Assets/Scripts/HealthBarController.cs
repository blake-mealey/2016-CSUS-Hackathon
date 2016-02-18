using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

	public GameObject[] healthStates;
	public GameObject filler;
	public float[] healthSwitchValues;

	private float startingHealth;
	private float currentHealth;
	// Use this for initialization
	void Start () {
		for(int j = 1;j<healthStates.Length;j++){
			healthStates[j].SetActive(false);
		}
		filler.transform.localScale = new Vector3(0,1,1);
	}
	public void setStartingHealth(float h){
		startingHealth = h;
		currentHealth = h;
	}
	public void updateHealth(float h){
		currentHealth = h;
		float ratio = currentHealth/startingHealth;
		filler.transform.localScale = new Vector3(1f-ratio,1,1);

		for(int j = 0;j<healthStates.Length;j++){
			healthStates[j].SetActive(false);
		}
		for(int k = 0;k<healthSwitchValues.Length;k++){
			if(ratio>healthSwitchValues[k]){
				healthStates[k].SetActive(true);
				break;
			}
		}
	}
}
