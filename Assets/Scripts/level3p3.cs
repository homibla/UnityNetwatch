using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
[RequireComponent(typeof(Dropdown))]
public class level3p3 : MonoBehaviour {
	public Dropdown dropdown1;
	public GameObject kalah;
	public Text nyawatext;
	public GameObject tekskonfigurasiClamav;
	public GameObject nexttext;
	public GameObject nextDropdown;
	int tmpNyawa;
	void Awake()
	{
		dropdown1 = GetComponent<Dropdown> ();
		dropdown1.onValueChanged.AddListener (new UnityAction<int> (index => {

			checkLangkah3(dropdown1.value);
		}
		));
	}
	public void checkBenar(){
		if (PlayerPrefs.GetInt ("Nyawa") == 0) {
			kalah.SetActive (true);
		}
	}
	void showTek(){
		tekskonfigurasiClamav.SetActive (true);
		nexttext.SetActive (true);
		nextDropdown.SetActive (true);
	}
	public void checkLangkah3(int i){
		if (i == 1) {
			Invoke ("showTek", 1.0f);
			dropdown1.interactable = false;
		} else {
			tmpNyawa=PlayerPrefs.GetInt("Nyawa");
			PlayerPrefs.SetInt ("Nyawa", tmpNyawa=tmpNyawa-1);
			nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			checkBenar ();
		}
	}
}
