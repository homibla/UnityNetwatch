using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
//Jane ga butuh pcpush e.
public class level2ssh : MonoBehaviour {
	int skor,sukses;
	int nyawa;
	public GameObject warningsalah;
	string oktetA,oktetB,oktetC,oktetD;
	string ipa,ipb,ipc,ipd;
	[SerializeField]
	private Text textnyawa;
	[SerializeField]
	private Text textSkor;
	[SerializeField]
	private GameObject menang;
	[SerializeField]
	private GameObject kalah;
	[SerializeField]
	private GameObject starl;
	[SerializeField]
	private GameObject starc;
	[SerializeField]
	private GameObject starr;
	[SerializeField]
	private InputField inputIPa;
	[SerializeField]
	private InputField inputIPb;
	[SerializeField]
	private InputField inputIPc;
	[SerializeField]
	private InputField inputIPd;
	[SerializeField]
	private InputField inputNMa;
	[SerializeField]
	private InputField inputNMb;
	[SerializeField]
	private InputField inputNMc;
	[SerializeField]
	private InputField inputNMd;
	[SerializeField]
	private InputField ssh;
	[SerializeField]
	private GameObject SSHWarning;
//--Punya Server--
	[SerializeField]
	private GameObject Warning;
	[SerializeField]
	private GameObject ButtonOk;
	[SerializeField]
	private Text tempServer;
//
	//------------------------------
	
//	//-----------INPUT------------
	public void GetInputA(string isi){
		inputIPa.text = isi;
	}
	public void GetInputB(string isi){
		inputIPb.text = isi;
	}
	public void GetInputC(string isi){
		inputIPc.text = isi;
	}
	public void GetInputD(string isi){
		inputIPd.text = isi;
	}
	public void GetNetmaskA(string netmask){
		inputNMa.text=netmask;
	}
	public void GetNetmaskB(string netmask){
		inputNMb.text=netmask;
	}
	public void GetNetmaskC(string netmask){
		inputNMc.text=netmask;
	}
	public void GetNetmaskD(string netmask){
		inputNMd.text=netmask;
	}
//	
	//LOAD SCENE PILIH LEVEL
	public void levelToload (int level) {
		SceneManager.LoadScene (level);
	}
	//--Metode Check Benar/Salah
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
	public void GetPortSSH(string isi){
		ssh.text = isi;
		
	}
	public void HabisPortSSH(){
		if (string.IsNullOrEmpty (ssh.text) == false) {
			try{
				int v1 = int.Parse(ssh.text);
				if(v1>0&&v1!=22){
					skor = PlayerPrefs.GetInt ("Skor");
					PlayerPrefs.SetInt ("Skor", skor = skor + 1);
					cekbenar();
				}
			}catch{
				//kurang show warning
				nyawa= PlayerPrefs.GetInt("Nyawa");
				nyawa--;
				PlayerPrefs.SetInt ("Nyawa", nyawa);
				textnyawa.text=PlayerPrefs.GetInt("Nyawa").ToString();
				warningsalah.SetActive (true);
				cekbenar();
			}

		}

	}
	//-----------PushNilai------------
	public void goPush (){	
		if(string.IsNullOrEmpty(inputIPa.text) == false&&string.IsNullOrEmpty(inputIPb.text) == false 
		&& string.IsNullOrEmpty(inputIPc.text) == false && string.IsNullOrEmpty(inputIPd.text) == false
		&& string.IsNullOrEmpty(inputNMa.text) == false&&string.IsNullOrEmpty(inputNMb.text) == false 
		&& string.IsNullOrEmpty(inputNMc.text) == false && string.IsNullOrEmpty(inputNMd.text) == false)
		{
			try{
			int v1 = int.Parse (inputIPa.text);
			int v2 = int.Parse (inputIPb.text);
			int v3 = int.Parse (inputIPc.text);
			int v4 = int.Parse (inputIPd.text);
			int o1 = int.Parse (inputNMa.text);
			int o2 = int.Parse (inputNMb.text);
			int o3 = int.Parse (inputNMc.text);
			int o4 = int.Parse (inputNMd.text);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
					Warning.SetActive (true);
					nyawa=PlayerPrefs.GetInt("Nyawa");
					nyawa--;
					PlayerPrefs.SetInt ("Nyawa", nyawa);
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					if(sukses<1){
						tempServer.text = "Ok";
						//skor++;
						skor=PlayerPrefs.GetInt("Skor");
						PlayerPrefs.SetInt("Skor",skor=skor+1);
						sukses=1;
						//panelServ.SetActive(false);
						cekbenar();
					}
				}
			}catch{
				Warning.SetActive (true);
				nyawa=PlayerPrefs.GetInt("Nyawa");
				nyawa--;
				PlayerPrefs.SetInt ("Nyawa", nyawa);
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}
		else
		{
			Warning.SetActive(true);
			nyawa=PlayerPrefs.GetInt("Nyawa");
			nyawa--;
			PlayerPrefs.SetInt ("Nyawa", nyawa);
			textnyawa.text=nyawa.ToString();
		}
	}
}
