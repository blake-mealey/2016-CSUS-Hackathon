using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ContinuityManager : MonoBehaviour {

	public static ContinuityManager instance;
	private int currentPoint = 0;
	private float startingHealth = 100;

	private bool setHealth = false;
	private bool setPosition = false;
	private bool ready = false;
	// Use this for initialization
	void Start () {

		if(ContinuityManager.instance!=null){
			Destroy(this.gameObject);
			return;
		}

		PlayerPrefs.SetFloat("health", 100f);
		ready = true;
		PlayerPrefs.SetString("EnemyName","None");
		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelWasLoaded(int level){
		if(ready==false)
			return;
		//Debug.Log("Level loaded: " + level);
		if(level == 0){//main scene was loaded
			//Debug.Log("Main scene was loaded");

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
			float dif = PlayerPrefs.GetInt("result") == 1 ? 0: 20;
			PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("health")-dif);
			setPosition = true;
		}else{
			setHealth = true;
		}
	}

	// Update is called once per frame
	void Update () {
			
		if(setPosition == true){
			GameObject player = Linker.instance.player;
			player.transform.position = Linker.instance.toObjects[currentPoint].transform.position;
			for(int j = (currentPoint-1);j>=0;j--){
				if(j==1){
					Linker.instance.anims[j].SetBool("Dead", true);
					Linker.instance.anims[j].transform.parent.GetChild(1).GetComponent<Animator>().SetBool("Dead", true);
					Linker.instance.anims[j].transform.parent.GetComponent<Enemy>().setDead();
				}else{
					Linker.instance.anims[j].SetBool("Dead",true);
					Linker.instance.anims[j].transform.GetComponent<Enemy>().setDead();
				}
			}
			setPosition = false;
		}
	}
}
