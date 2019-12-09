using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pindahlevel : MonoBehaviour {

	// Use this for initialization
	public void levelToload (int level) {
		SceneManager.LoadScene (level);
	}
	public void stopmu(){
		GameObject objs = GameObject.FindGameObjectWithTag ("music");
		Destroy (objs);
	}
}
