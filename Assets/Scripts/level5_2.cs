using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class level5_2 : MonoBehaviour {
	[SerializeField]
	private InputField tcpp;
	[SerializeField]
	private InputField udpp;

	public GameObject kalah,nexttext,pudptcp;
	int skor,tmpNyawa;
	public Dropdown dropdown;
	public Text nyawatext;

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
		if (PlayerPrefs.GetInt ("Skor") == 2) {
			nexttext.SetActive (true);
		}
	}

	public void checkLangkah(int i){
		if (i == 1) {
			pudptcp.SetActive (true);
			dropdown.interactable = false;
		} else {
			tmpNyawa=PlayerPrefs.GetInt("Nyawa");
			PlayerPrefs.SetInt ("Nyawa", tmpNyawa=tmpNyawa-1);
			nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			cekbenar ();
		}
	}

	public void GetPortTCP(string isi){
		tcpp.text = isi;
		if (string.IsNullOrEmpty (tcpp.text) == false) {
			try{
				int v1 = int.Parse(tcpp.text);
				if(v1==1){
					skor = PlayerPrefs.GetInt ("Skor");
					PlayerPrefs.SetInt ("Skor", skor = skor + 1);
					cekbenar();
				}

			}catch{
				//kurang show warning
				tmpNyawa= PlayerPrefs.GetInt("Nyawa");
				tmpNyawa--;
				PlayerPrefs.SetInt ("Nyawa", tmpNyawa);
				cekbenar();
			}
		}
	}
	public void GetPortUDP(string isi){
		udpp.text = isi;
		if (string.IsNullOrEmpty (udpp.text) == false) {
			try{
				int v1 = int.Parse(udpp	.text);
				if(v1==1){
					skor = PlayerPrefs.GetInt ("Skor");
					PlayerPrefs.SetInt ("Skor", skor = skor + 1);
					cekbenar();
				}else{
					tmpNyawa= PlayerPrefs.GetInt("Nyawa");
					tmpNyawa--;
					PlayerPrefs.SetInt ("Nyawa", tmpNyawa);
					cekbenar();
					nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
				}
			}catch{
				//kurang show warning
				tmpNyawa= PlayerPrefs.GetInt("Nyawa");
				tmpNyawa--;
				PlayerPrefs.SetInt ("Nyawa", tmpNyawa);
				cekbenar();
				nyawatext.text = PlayerPrefs.GetInt ("Nyawa").ToString();
			}
		}
	}
}
