using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleUIManager : MonoBehaviour {

	public static BattleUIManager instance;

	public GameObject options;
	public GameObject attacks;
	public GameObject items;

	public GameObject playerLog;
	public GameObject enemyLog;

	private Text playerText;
	private Text enemyText;

	private bool fadeText = false;
	private float ctime = 0;
	private float textFadeTime = 0.3f;
	// Use this for initialization
	void Start () {
		instance = this;
		options.SetActive(true);
		attacks.SetActive(false);
		items.SetActive(false);
		
		playerText = playerLog.GetComponentInChildren<Text>();
		enemyText = enemyLog.GetComponentInChildren<Text>();

		playerText.color = new Color(0,0,0,0);
		enemyText.color = new Color(0,0,0,0);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(fadeText){
			ctime+=Time.deltaTime;
			playerText.color = new Color(0,0,0,1f-(ctime/textFadeTime));
			enemyText.color = new Color(0,0,0,1f-(ctime/textFadeTime));
			if(ctime>=textFadeTime){
				playerText.color = new Color(0,0,0,0);
				enemyText.color = new Color(0,0,0,0);
				fadeText = false;
				ctime = 0;
				BattleManager.instance.changeTurn();
			}
		}
	}

	public void openMenu(int menu){

		options.SetActive(false);
		attacks.SetActive(false);
		items.SetActive(false);

		switch(menu){
		case 0:
			options.SetActive(true);
			break;
		case 1:
			attacks.SetActive(true);
			break;
		case 2:
			items.SetActive(true);
			break;
		}
	}
	public void hideText(){
		fadeText = true;
	}
	public void showText(){
		playerText.color = new Color(0,0,0,1f);
		enemyText.color = new Color(0,0,0,1f);
	}
	public void displayPlayerAttack(Attack attack){
		showText();
		playerTurnEnd();
		playerText.text = "You used " + attack.attackName + "!";
		playerText.text = playerText.text += "\n" + attack.attackDescription;
		enemyText.text = attack.effectDescription;
	}
	public void displayEnemyAttack(Attack attack){
		showText();
		enemyText.text = PlayerPrefs.GetString("EnemyName") + " used " + attack.attackName + "!";
		enemyText.text = enemyText.text += "\n" + attack.attackDescription;
		playerText.text = attack.effectDescription;
	}
	public void playerTurnEnd(){
		openMenu(0);
		Button[] buttons = options.GetComponentsInChildren<Button>();
		for(int j = 0;j<buttons.Length;j++){
			buttons[j].interactable = false;
		}
	}
	public void startPlayerTurn(){
		Button[] buttons = options.GetComponentsInChildren<Button>();
		for(int j = 0;j<buttons.Length;j++){
			buttons[j].interactable = true;
		}
	}
}
