using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Attack[] playerAttacks;
	public Attack[] enemyAttacks;
	public float[] attackProbabilities;
	public string[] complaints;
	public float startingHealth;
	public float currentHealth;

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
}
