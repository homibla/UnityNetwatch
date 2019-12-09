using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Dropdown))]
public class readDropdown : MonoBehaviour {
	public Dropdown dropdownNano;
	public GameObject panel,panelpart1;
	public Text nyawatext;
	public GameObject kalah;
	int v1;
	int option;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Awake()
	{
		dropdownNano = GetComponent<Dropdown> ();
		dropdownNano.onValueChanged.AddListener (new UnityAction<int> (index => {
			
			checkSSH(dropdownNano.value);
		}
		));
	}
	public void checkBenar(){
		if (PlayerPrefs.GetInt ("Nyawa") == 0) {
			kalah.SetActive (true);
		}
	}
	public void checkdropdown(){
		if (dropdownNano.interactable == false) {
			panel.SetActive (true);
			panelpart1.SetActive (false);
		}
	}
	public void checkSSH(int i){
		if (i == 3) {
			panel.SetActive (true);
			panelpart1.SetActive (false);
			dropdownNano.interactable = false;
		} else {
			v1=PlayerPrefs.GetInt("Nyawa");
			PlayerPrefs.SetInt ("Nyawa", v1=v1-1);
			nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			checkBenar ();
		}
	}
}
