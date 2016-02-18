using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndBattleUI : MonoBehaviour {

	public bool winGame = false;
	public bool active = false;

	private bool fade = false;
	private bool fadePause = false;
	public float fadeTime = 1f;
	public float fadePauseTime = 1f;
	public float scaleTime = 0.4f;
	private float ctime = 0;

	public GameObject winScene;
	public GameObject fadeScreen;

	public static EndBattleUI instance;

	void Start (){
		instance = this;
	}

	// Update is called once per frame
	void Update () {

		if(active==true){
			transform.GetComponent<Canvas>().sortingOrder = 5;
			ctime+=Time.deltaTime;

			if(fadePause==true){

				if(ctime>=fadePauseTime){
					fade = true;
					fadePause = false;
					ctime = 0;
				}

			}else if(fade==true){

				fadeScreen.GetComponent<Image>().color = new Color(0,0,0,ctime/fadeTime);

				if(ctime>=fadeTime){
					ctime = 0;
					if(winGame){
						SceneManager.LoadScene("main");
					}else{
						PlayerPrefs.SetString("EnemyName","None");
						SceneManager.LoadScene("GameoverScene");
					}
				}

			}else if(winGame==true){

				float scale = ctime/scaleTime;
				winScene.transform.localScale = new Vector3(scale,scale,1f);

				if(ctime>=scaleTime){
					fadePause = true;
					ctime = 0;
				}
			}
		}
	}

	public void setEndGame(bool winstatus){
		winGame = winstatus;
		active = true;
		if(winstatus==false)
			fade = true;
	}
	public void fleeBattle(){
		fade = true;
		active = true;
		winGame = true;
		PlayerPrefs.SetString("EnemyName","None");
	}
}
