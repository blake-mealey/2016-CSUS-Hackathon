using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour {

	Enemy enemy;
	public GameObject enemyLoc;
	private GameObject enemyObj;
	public float playerHealth;
	private float currentHealth;
	public HealthBarController playerHealthbar;
	public HealthBarController enemyHealthbar;
	private Attack[] playerAttacks;
	public GameObject[] attackButtons;
	public GameObject[] items;
	public List<string> complaints;
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetString("EnemyName", "BaristaEnemy");
		currentHealth = playerHealth;
		enemyObj = (GameObject)Instantiate(Resources.Load(PlayerPrefs.GetString("EnemyName")));
		enemyObj.transform.position = enemyLoc.transform.position;
		enemy = enemyObj.GetComponent<Enemy>();

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
		Debug.Log(attack.attackName);
	}
	public void complain(){
		int num = Random.Range(0,complaints.Count);
		string temp = complaints[num];
		complaints.RemoveAt(num);

	}
	// Update is called once per frame
	void Update () {

	}
}
