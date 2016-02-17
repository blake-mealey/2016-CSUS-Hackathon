using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour {

	public GameObject[] healthStates;
	public float[] healthSwitchValues;

	// Use this for initialization
	void Start () {
		for(int j = 1;j<healthStates.Length;j++){
			healthStates[j].SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
