using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContinuityManager : MonoBehaviour {

	public static ContinuityManager instance;
	private int currentPoint = 0;
	private float startingHealth = 100;

	private bool setHealth = false;
	private bool setPosition = false;

	// Use this for initialization
	void Start () {

		if(instance!=null)
			Destroy(this.gameObject);

		PlayerPrefs.SetString("EnemyName","None");
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelWasLoaded(int level){
		Debug.Log("Level loaded: " + level);
		if(level == 0){//main scene was loaded
			Debug.Log("Main scene was loaded");

			currentPoint++;
			switch(PlayerPrefs.GetString("EnemyName")){
			case "Clock":
				currentPoint = 1;
				break;
			case "Parents":
				currentPoint = 2;
				break;
			case "Barista":
				currentPoint = 3;
				break;
			default:
				currentPoint = 0;
				break;
			}
			startingHealth += PlayerPrefs.GetInt("result") == 1 ? 0: -20;
			setPosition = true;
		}else{
			setHealth = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(setHealth == true){
			setHealth = false;
			BattleManager.instance.currentHealth = startingHealth;
		}
			
		if(setPosition == true){
			GameObject player = Linker.instance.player;
			player.transform.position = Linker.instance.toObjects[currentPoint].transform.position;
			setPosition = false;
		}
	}
}
