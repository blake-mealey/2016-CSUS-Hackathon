using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RestartManager : MonoBehaviour {

	public void resetEverything(){
		ContinuityManager temp = ContinuityManager.instance;
		ContinuityManager.instance = null;
		if(temp!=null)
			Destroy(temp);
		SceneManager.LoadScene("main");
	}
}
