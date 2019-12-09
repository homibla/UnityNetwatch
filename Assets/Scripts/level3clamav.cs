using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Dropdown))]
public class level3clamav : MonoBehaviour {
	public Dropdown dropdown1;
	public GameObject kalah;
	public Text nyawatext;
	public GameObject k1,k2,k3,k4;
	public GameObject nexttext;
	public GameObject nextDropdown;
	int tmpNyawa;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Awake()
	{
		dropdown1 = GetComponent<Dropdown> ();
		dropdown1.onValueChanged.AddListener (new UnityAction<int> (index => {

			checkLangkah1(dropdown1.value);
		}
		));
	}
	public void checkBenar(){
		if (PlayerPrefs.GetInt ("Nyawa") == 0) {
			kalah.SetActive (true);
		}
	}
	void showk1(){
		k1.SetActive (true);
	}
	void showk2(){
		k2.SetActive (true);
	}
	void showk3(){
		k3.SetActive (true);
	}
	void showk4(){
		k4.SetActive (true);
	}
	void showTeks2(){
		nexttext.SetActive (true);
		nextDropdown.SetActive (true);
	}
	public void checkLangkah1(int i){
		if (i == 3) {
			Invoke ("showk1", 0.1f);
			Invoke ("showk2", 0.3f);
			Invoke ("showk3", 0.5f);
			Invoke ("showk4", 0.7f);
			Invoke ("showTeks2", 1.2f);
			dropdown1.interactable = false;
		} else {
			tmpNyawa=PlayerPrefs.GetInt("Nyawa");
			PlayerPrefs.SetInt ("Nyawa", tmpNyawa=tmpNyawa-1);
			nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			checkBenar ();
		}
	}
}
