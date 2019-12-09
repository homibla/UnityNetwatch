using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class level4_4 : MonoBehaviour {
	public Dropdown dropdown;
	public GameObject kalah;
	public Text nyawatext;
	public GameObject nexttext;
	int tmpNyawa;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void cekbenar () {
		if (PlayerPrefs.GetInt ("Nyawa") == 0) {
			kalah.SetActive (true);
		}
	}
	void Awake()
	{
		dropdown = GetComponent<Dropdown> ();
		dropdown.onValueChanged.AddListener (new UnityAction<int> (index => {

			checkLangkah(dropdown.value);
		}
		));
	}
	void checkLangkah(int i)
	{
		if (i == 3) {
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
