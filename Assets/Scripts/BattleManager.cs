using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour {

	public static BattleManager instance;

	Enemy enemy;
	public GameObject enemyLoc;
	private GameObject enemyObj;
	public float playerHealth;
	public float currentHealth;
	public HealthBarController playerHealthbar;
	public HealthBarController enemyHealthbar;
	private Attack[] playerAttacks;
	public GameObject[] attackButtons;
	public GameObject[] items;
	public List<string> complaints;

	public bool textShowing = false;
	private float ctime = 0;
	public float hideTime = 3f;
	private int turn = 0;
	// Use this for initialization
	void Start () {
		instance = this;

		currentHealth = PlayerPrefs.GetFloat("health");
		enemyObj = (GameObject)Instantiate(Resources.Load(PlayerPrefs.GetString("EnemyName")));
		enemyObj.transform.position = enemyLoc.transform.position;
		enemy = enemyObj.GetComponent<Enemy>();
		enemyHealthbar.setStartingHealth(enemy.startingHealth);
		playerHealthbar.setStartingHealth(playerHealth);
		playerHealthbar.updateHealth(currentHealth);

		//Player attacks
		playerAttacks = enemy.playerAttacks;
		for(int j = 0;j<playerAttacks.Length;j++){
			attackButtons[j].GetComponentInChildren<Text>().text = playerAttacks[j].attackName;
			Attack temp = playerAttacks[j];
			attackButtons[j].GetComponent<Button>().onClick.AddListener(() => { attack(temp); });
		}
		//Setup complaint list
		complaints = new List<string>(enemy.complaints);
	}
	//Use for player attacks when they press an attack button.
	public void attack(Attack attack){
		if(turn==0){
			BattleUIManager.instance.displayPlayerAttack(attack);
			bool state = enemy.applyDamage(attack.damage);
			enemyHealthbar.updateHealth(Mathf.Max(0,enemy.currentHealth));
			if(state == true){//You win
				PlayerPrefs.SetInt("result", 1);
				EndBattleUI.instance.setEndGame(true);
			}else{
				textShowing = true;
			}
		}else{
			BattleUIManager.instance.displayEnemyAttack(attack);
			currentHealth=Mathf.Max(0,currentHealth-attack.damage);
			playerHealthbar.updateHealth(currentHealth);
			if(currentHealth==0){//You lose
				EndBattleUI.instance.setEndGame(false);
			}else{
				textShowing = true;
			}
		}
	}
	public void complain(){
		int num = Random.Range(0,complaints.Count);
		string temp = complaints[num];
		complaints.RemoveAt(num);
		BattleUIManager.instance.displayComplaint(temp);
		if(complaints.Count==0){
			BattleUIManager.instance.doneComplaining();
		}
		textShowing = true;
	}
	public void flee(){
		float chance = Random.Range(0f, 1f);
		if(chance<enemy.fleeChance){
			PlayerPrefs.SetInt("result", 0);
			BattleUIManager.instance.displayComplaint("You fled the battle!");
			EndBattleUI.instance.fleeBattle();
		}else{
			BattleUIManager.instance.displayComplaint("You attempted to flee, but failed! " + enemy.fleeMessage);
			textShowing = true;
		}
	}
	// Update is called once per frame
	void Update () {

		if(textShowing){
			ctime+=Time.deltaTime;
			if(ctime>=hideTime){
				textShowing = false;
				ctime = 0;
				BattleUIManager.instance.hideText();
			}
		}
	}
	public void changeTurn(){
		turn = (turn+1)%2;

		if(turn==1){
			attack(enemy.getNextEnemyAttack());
		}else{
			BattleUIManager.instance.startPlayerTurn();
		}
	}
}
