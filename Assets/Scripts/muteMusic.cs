using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muteMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void kontrollagu(int i){
		if (i == 1) {
			AudioListener.volume = 0;
		} else {
			AudioListener.volume = 1;
		}
	}
}
