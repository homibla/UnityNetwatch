using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Awal : MonoBehaviour {
	// Use this for initialization
	static Awal instance;
	void Awake(){
		
		GameObject[] objs = GameObject.FindGameObjectsWithTag ("music");
	 	if (objs.Length > 1) {
	 		Destroy (this.gameObject);
			 return;
	 	}
		if (instance != null) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
	public void suaralagu(int i){
		if (i == 1) {
			AudioListener.volume = 0;
		} 
		if (i == 0)  {
			AudioListener.volume = 1;
		}
	}
	void OnDestroy(){
		if (instance == this) {
			instance = null;
		}
	}
	// Update is called once per frame
	public void levelToload (int level) {
		SceneManager.LoadScene (level);
	}
}
