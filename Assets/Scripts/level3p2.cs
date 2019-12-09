using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Dropdown))]
public class level3p2 : MonoBehaviour {
	public Dropdown dropdown1;
	public GameObject kalah;
	public Text nyawatext;
	public GameObject nexttext;
	public GameObject nextDropdown;
	int tmpNyawa;
	void Awake()
	{
		dropdown1 = GetComponent<Dropdown> ();
		dropdown1.onValueChanged.AddListener (new UnityAction<int> (index => {

			checkLangkah2(dropdown1.value);
		}
		));
	}
	public void checkBenar(){
		if (PlayerPrefs.GetInt ("Nyawa") == 0) {
			kalah.SetActive (true);
		}
	}
	void shownext(){
		nexttext.SetActive (true);
		nextDropdown.SetActive (true);
	}
	public void checkLangkah2(int i){
		if (i == 4) {
			Invoke ("shownext",1.2f);
			dropdown1.interactable = false;
		} else {
			tmpNyawa=PlayerPrefs.GetInt("Nyawa");
			PlayerPrefs.SetInt ("Nyawa", tmpNyawa=tmpNyawa-1);
			nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			checkBenar ();
		}
	}
}
