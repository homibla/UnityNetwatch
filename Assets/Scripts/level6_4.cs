using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class level6_4 : MonoBehaviour {
	public GameObject kalah,menang,starl,starc,starr;
	public Dropdown dropdown;
	public Text textSkor,nyawatext;
	int skor,nyawa;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Awake () {
		dropdown = GetComponent<Dropdown> ();
		dropdown.onValueChanged.AddListener (new UnityAction<int> (index => {

			iptab(dropdown.value);
		}
		));

	}

	void cekbenar(){
		if (PlayerPrefs.GetInt ("Nyawa") == 0) {
			kalah.SetActive (true);
		}
		if (PlayerPrefs.GetInt("Skor")==1) {
			showMenang();
		}
	}

	void showMenang(){
		menang.SetActive (true);
		if(PlayerPrefs.GetInt ("Nyawa")==3)
		{
			textSkor.text="3000";
			starl.SetActive(true);
			starc.SetActive(true);
			starr.SetActive(true);
		}
		if(PlayerPrefs.GetInt ("Nyawa")==2)
		{
			textSkor.text="2000";
			starl.SetActive(true);
			starc.SetActive(true);
		}
		if(PlayerPrefs.GetInt ("Nyawa")==1){
			textSkor.text="1000";
			starl.SetActive(true);
		}
	}
	public void iptab(int i){
		if (i == 4) {
			skor = PlayerPrefs.GetInt ("Skor");
			PlayerPrefs.SetInt ("Skor", skor = skor + 1);
			cekbenar();
			dropdown.interactable = false;
		}else{
			//kurang show warning
			nyawa= PlayerPrefs.GetInt("Nyawa");
			nyawa--;
			PlayerPrefs.SetInt ("Nyawa", nyawa);
			nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			cekbenar();
		}
	}
}