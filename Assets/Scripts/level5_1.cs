using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class level5_1 : MonoBehaviour {
	public Dropdown dropdown;
	public GameObject kalah;
	public Text nyawatext;
	public GameObject nexttext;
	int tmpNyawa;
	// Use this for initialization
	void Awake()
	{
		dropdown = GetComponent<Dropdown> ();
		dropdown.onValueChanged.AddListener (new UnityAction<int> (index => {

			checkLangkah(dropdown.value);
		}
		));
	}
	
	void cekbenar () {
		if (PlayerPrefs.GetInt ("Nyawa") == 0) {
			kalah.SetActive (true);
		}
	}
	public void checkLangkah(int i){
		if (i == 4) {
			nexttext.SetActive (true);
			dropdown.interactable = false;
		} else {
			tmpNyawa=PlayerPrefs.GetInt("Nyawa");
			PlayerPrefs.SetInt ("Nyawa", tmpNyawa=tmpNyawa-1);
			nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			cekbenar ();
		}
	}
}
