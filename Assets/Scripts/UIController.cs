using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public static UIController instance;
	public Text messageText;
	public GameObject speechBubble;
	public GameObject thoughtBubble;
	public GameObject contextBubble;
	public Image fadeImage;

	private float ctime = 0f;
	private float fadeTime = 1f;
	private float fadePauseTime = 0;
	private bool fadeout = false;
	private bool fadePause = false;
	private bool fadein = false;
	// Use this for initialization
	void Start () {
		instance = this;
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

	}

	public void setText (int mode, string message){
		messageText.text = message;
		switch(mode){
		case 0:
			speechBubble.SetActive(true);
			thoughtBubble.SetActive(false);
			contextBubble.SetActive(false);
			break;
		case 1:
			speechBubble.SetActive(false);
			thoughtBubble.SetActive(true);
			contextBubble.SetActive(false);
			break;
		case 2:
			speechBubble.SetActive(false);
			thoughtBubble.SetActive(false);
			contextBubble.SetActive(true);
			break;
		}
	}
	public void cameraFade(float timeToFade, float nfadePauseTime){
		fadeout = true;
		fadein = true;
		fadeTime = timeToFade;
		if(nfadePauseTime!=0){
			fadePauseTime = nfadePauseTime;
			fadePause = true;
		}
	}
}
