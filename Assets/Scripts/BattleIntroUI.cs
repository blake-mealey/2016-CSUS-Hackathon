using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleIntroUI : MonoBehaviour {

	public GameObject youObj;
	public GameObject versusObj;
	public GameObject enemyObj;
	public Text enemyText;

	private int task = 0;
	private float ctime = 0;
	public float waitTime = 0.5f;
	public float pauseTime = 0.5f;
	public float waitToRemoveTime = 1f;
	public float removeTime = 1f;
	public float scaleTime = 1f;

	void Start(){
		enemyText.text = PlayerPrefs.GetString("EnemyName");
	}

	// Update is called once per frame
	void Update () {
	
		ctime+=Time.deltaTime;
		float scale = 0;
		switch(task){
		case 0://Starting hesitation before stuff appears
			if(ctime>=waitTime){
				task++;
				ctime = 0;
			}
			break;
		case 1://Scales the you text
			scale = Mathf.Min(1,ctime/scaleTime);
			youObj.transform.localScale = new Vector3(scale,scale,1);
			if(ctime>=scaleTime){
				task++;
				ctime = 0;
			}
			break;
		case 2://Waits a short period of time
			if(ctime>=pauseTime){
				task++;
				ctime = 0;
			}
			break;
		case 3://scales the vs text
			scale = Mathf.Min(1,ctime/scaleTime);
			versusObj.transform.localScale = new Vector3(scale,scale,1);
			if(ctime>=scaleTime){
				task++;
				ctime = 0;
			}
			break;
		case 4://waits for a bit of time
			if(ctime>=pauseTime){
				task++;
				ctime = 0;
			}
			break;
		case 5://scales the enemy text
			scale = Mathf.Min(1,ctime/scaleTime);
			enemyObj.transform.localScale = new Vector3(scale,scale,1);
			if(ctime>=scaleTime){
				task++;
				ctime = 0;
			}
			break;
		case 6://Waits to remove all of the text
			if(ctime>=waitToRemoveTime){
				task++;
				ctime = 0;
			}
			break;
		case 7://removes all of the Text
			scale = Mathf.Max(0,1f-(ctime/removeTime));
			youObj.transform.localScale = new Vector3(scale,scale,1);
			versusObj.transform.localScale = new Vector3(scale,scale,1);
			enemyObj.transform.localScale = new Vector3(scale,scale,1);
			if(ctime>=removeTime){
				task++;
				ctime = 0;
			}
			break;
		}

	}
}
