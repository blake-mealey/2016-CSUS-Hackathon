using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	public static UIController instance;
	public Text messageText;
	public GameObject contextBubble;
	public GameObject allBubbles;
	public Image fadeImage;

	private float ctime = 0f;
	private float fadeTime = 1f;
	private float fadePauseTime = 0.2f;
	private bool fadeout = false;
	private bool fadePause = false;
	private bool fadein = false;
	private bool sceneTransition = false;

	private bool hideBoxes = false;
	public float hideSpeed = 0.1f;
	private Vector3 startPos;
	private Vector3 endPos;
	// Use this for initialization
	void Start () {
		instance = this;
		startPos = allBubbles.GetComponent<RectTransform>().position;
		endPos = startPos - new Vector3(0,startPos.y+60,0);
		hideBoxes = false;
		fadePause = true;
		fadein = true;
		//setText("BEEP BEEP BEEP!!! It's 8 am, time to get up! Press 'E' to turn off your annoying alarm!");
		//cameraFade(1f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
		if(fadeout){
			fadeImage.color = new Color(0,0,0,(ctime/fadeTime));
			ctime+=Time.deltaTime;
			if(ctime>fadeTime){
				fadeout = false;
				fadein = true;
				ctime = 0;
				fadeImage.color = new Color(0,0,0,1f);
				if(sceneTransition){
					SceneManager.LoadScene("battleScene");
				}
			}
		}else if(fadePause){
			
			ctime+=Time.deltaTime;
			if(ctime>fadePauseTime){
				fadePause = false;
				ctime = fadeTime;
			}
		}else if(fadein){
			fadeImage.color = new Color(0,0,0,(ctime/fadeTime));

			ctime-=Time.deltaTime;
			if(ctime<0){
				fadein = false;
				ctime = 0;
				fadeImage.color = new Color(0,0,0,0);
			}
		}

		if(hideBoxes == true){
			allBubbles.GetComponent<RectTransform>().position = Vector3.Lerp(allBubbles.transform.position,endPos,hideSpeed);
		}else{
			allBubbles.GetComponent<RectTransform>().position = Vector3.Lerp(allBubbles.transform.position,startPos,hideSpeed);
		}
	}

	public void setText (string message){
		showBubbles();
		messageText.text = message;
		contextBubble.SetActive(true);
	}
	public void cameraFade(float timeToFade, float nfadePauseTime){
		fadeout = true;
		fadein = true;
		sceneTransition = false;
		fadeTime = timeToFade;
		if(nfadePauseTime!=0){
			fadePauseTime = nfadePauseTime;
			fadePause = true;
		}
	}
	public void cameraFadeToBattle(float timeToFade){
		fadeout = true;
		sceneTransition = true;
		fadeTime = timeToFade;
	}
	public void hideBubbles(){
		hideBoxes = true;
	}
	public void showBubbles(){
		hideBoxes = false;
	}
}
