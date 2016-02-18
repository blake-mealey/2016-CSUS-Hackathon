using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour, InteractInterface {

    public string prompt;
    public string[] convos;
    private int currentSentence = 0;
    public bool isBattle = false;

    void OnTriggerEnter2D(Collider2D collider)
    {
        UIController.instance.setText(prompt);
        collider.transform.GetComponent<PlayerInteractScript>().addAction((InteractInterface)this);
    }
    //leaves door influence
    void OnTriggerExit2D(Collider2D collider)
    {
        collider.transform.GetComponent<PlayerInteractScript>().removeAction();
        UIController.instance.hideBubbles();
    }

    public void doAction()
    {
		if (currentSentence == convos.Length && isBattle)
			return;
        UIController.instance.setText(convos[currentSentence]);
        currentSentence++;
        if (currentSentence == convos.Length && isBattle)
        {
            PlayerPrefs.SetString("EnemyName", transform.name);
            UIController.instance.cameraFadeToBattle(1.5f);
        }
    }
}
