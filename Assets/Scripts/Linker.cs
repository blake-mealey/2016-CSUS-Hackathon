using UnityEngine;
using System.Collections;

public class Linker : MonoBehaviour {

	public GameObject player;
	public GameObject clock;
	public GameObject parents;
	public GameObject barista;
	public GameObject[] toObjects;
	public Animator[] anims;

	public static Linker instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}
}
