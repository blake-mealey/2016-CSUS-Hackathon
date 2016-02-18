using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour, InteractInterface {

	public Attack[] playerAttacks;
	public Attack[] enemyAttacks;
	public float[] attackProbabilities;
	public string[] complaints;
	public float startingHealth;
	public float currentHealth;

	private bool dead = false;
	private float totalProbabilities = 0;

	void Start () {
		for(int j = 0;j<attackProbabilities.Length;j++){
			totalProbabilities+=attackProbabilities[j];
		}
	}

	public Attack getNextEnemyAttack(){

		float temp = Random.Range(0f,totalProbabilities);
		float currentValue = 0;
		for(int j = 0;j<attackProbabilities.Length;j++){
			currentValue+=attackProbabilities[j];
			if(temp<=currentValue)
				return enemyAttacks[j];
		}
		return enemyAttacks[0];
	}
	public bool applyDamage(float d){
		currentHealth-=d;
		if(currentHealth<=0)
			return true;
		else
			return false;
		
	}
	//enters door influence
	void OnTriggerEnter2D(Collider2D collider){
		if(dead==true)
			return;
		UIController.instance.setText("BEEP BEEP BEEP!!! It's 8 am! Press 'E' to turn off your alarm.");
		collider.transform.GetComponent<PlayerInteractScript>().addAction((InteractInterface)this);
	}
	//leaves door influence
	void OnTriggerExit2D(Collider2D collider){
		if(dead==true)
			return;
		collider.transform.GetComponent<PlayerInteractScript>().removeAction();
		UIController.instance.hideBubbles();
	}
	public void doAction(){
		if(dead==true)
			return;
		PlayerPrefs.SetString("EnemyName", transform.name);
		UIController.instance.cameraFadeToBattle(1.5f);
	}
	public void setDead(){
		dead = true;
		UIController.instance.hideBubbles();
	}
}
