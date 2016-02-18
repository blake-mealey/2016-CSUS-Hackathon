using UnityEngine;
using System.Collections;

public class FireSpeed : MonoBehaviour {

	public float minSpeed = 0.3f;
	public float maxSpeed = 0.7f;
	public float minScale = 1f;
	public float maxScale = 6f;
	// Use this for initialization
	void Start () {
		GetComponent<Animator>().speed = Random.Range(minSpeed,maxSpeed);
		float scale = Random.Range(minScale,maxScale);
		transform.localScale = new Vector3(scale,scale,1);
	}

}
