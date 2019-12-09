using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Level1GameController : MonoBehaviour {

	bool sukses1, sukses2, sukses3, sukses4, sukses5, sukses6, sukses7, sukses8;
	int nyawa = 3;
	string oktetA,oktetB,oktetC,oktetD;
	string ipa,ipb,ipc,ipd;
	[SerializeField]
	int waktutimer = 90;
	[SerializeField]
	private Text textSkor;
	[SerializeField]
	private Text timerui;
	[SerializeField]
	private Text textnyawa;
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
	private GameObject panelServ,panelRout,PanelPC1,PanelPC2,PanelPC3,PanelPC4,PanelPC5,PanelPC6;
//--Punya Server--
	[SerializeField]
	private GameObject Warning;
	[SerializeField]
	private Text tempServer;
//
//--Punya Router--
	[SerializeField]
	private GameObject wRouter;
	[SerializeField]
	private Text tempRouter;
//
//--Punya PCTopLeft
	[SerializeField]
	private GameObject wTopLeft;
	[SerializeField]
	private Text tempTopLeft;
//
//--Punya PCTopCenter
	[SerializeField]
	private GameObject wTopCenter;
	[SerializeField]
	private Text tempTopCenter;
//
//--Punya PCTopRight
	[SerializeField]
	private GameObject wTopRight;
	[SerializeField]
	private Text tempTopRight;
//
//punya pc bot left
	[SerializeField]
	private GameObject wBotLeft;
	[SerializeField]
	private Text tempBotLeft;
//
//punya pc bot center
	[SerializeField]
	private GameObject wBotCenter;
	[SerializeField]
	private Text tempBotCenter;
//
//punya pc bot right
	[SerializeField]
	private GameObject wBotRight;
	[SerializeField]
	private Text tempBotRight;
//
	//------------------------------
	//timer
	public void CountDown(){
		if (waktutimer > 0) {
			timerui.text="Waktu : "+waktutimer;
			waktutimer--;
			Invoke ("CountDown", 1.0f);
		} 
		else {
			kalah.SetActive (true);
		}
	}
	//-------------------------------
	public void GetInput(string isi){
		ipa = isi;
	}
	public void GetInputB(string isi){
		ipb = isi;
	}
	public void GetInputC(string isi){
		ipc = isi;
	}
	public void GetInputD(string isi){
		ipd = isi;
	}
	public void GetNetmask(string netmask){
		oktetA=netmask;
	}
	public void GetNetmaskB(string netmask){
		oktetB=netmask;
	}
	public void GetNetmaskC(string netmask){
		oktetC=netmask;
	}
	public void GetNetmaskD(string netmask){
		oktetD=netmask;
	}
	//LOAD SCENE PILIH LEVEL
	public void levelToload (int level) {
		SceneManager.LoadScene (level);
	}
	//--Metode Check Benar/Salah
	void cekbenar(){
		if (nyawa == 0) {
			kalah.SetActive (true);
		}
		if (sukses1 == true && sukses2 == true && sukses3 == true && sukses4 == true 
		&& sukses5 == true && sukses6 == true  && sukses7 == true  && sukses8 == true) {
			showMenang();
		}
	}
	void showMenang(){
		menang.SetActive (true);
		if(nyawa==3)
			{
				textSkor.text="3000";
				starl.SetActive(true);
				starc.SetActive(true);
				starr.SetActive(true);
			}
			if(nyawa==2)
			{
				textSkor.text="2000";
				starl.SetActive(true);
				starc.SetActive(true);
			}
			if(nyawa==1){
				textSkor.text="1000";
				starl.SetActive(true);
			}
	}
	void cleanseIp(){
		ipa="";
		ipb="";
		ipc="";
		ipd="";
		oktetA="";
		oktetB="";
		oktetC="";
		oktetD="";
	}
	//-----------PushNilai------------
	public void serverPush (){	
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
				Warning.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					tempServer.text = "Ok";
					sukses1=true;
					panelServ.SetActive(false);
					cleanseIp();
					cekbenar();
				}
			}catch{
				Warning.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}
		else
		{
			Warning.SetActive(true);
		}
	}
	public void routerPush (){
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
				wRouter.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					sukses2=true;
					panelRout.SetActive(false);
					cleanseIp();
					tempRouter.text = "Ok";
					cekbenar();
				}
			}catch{
				wRouter.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}else
		{
			Warning.SetActive(true);
		}
	}
	public void PCTopLeftPush (){
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
					wTopLeft.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					sukses3=true;
					PanelPC1.SetActive(false);
					cleanseIp();
					tempTopLeft.text = "Ok";
					cekbenar();
				}
			}
			catch{
				wTopLeft.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}else
		{
			wTopLeft.SetActive(true);
		}
	}
	public void PCTopCenterPush (){
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
					wTopCenter.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					sukses4=true;
					PanelPC2.SetActive(false);
					cleanseIp();
					tempTopCenter.text="Ok";
					cekbenar();
				}
			}
			catch{
				wTopCenter.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}else
		{
			wTopCenter.SetActive(true);
		}
	}
	public void PCTopRightPush (){
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
					wTopRight.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					sukses5=true;
					PanelPC3.SetActive(false);
					cleanseIp();
					tempTopRight.text="Ok";
					cekbenar();
				}
			}
			catch{
				wTopRight.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}else
		{
			wTopRight.SetActive(true);
		}
	}
	public void PCBotLeftPush (){
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
					wBotLeft.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					sukses6=true;
					PanelPC4.SetActive(false);
					cleanseIp();
					tempBotLeft.text="Ok";
					cekbenar();
				}
			}
			catch{
				wBotLeft.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}else
		{
			wBotLeft.SetActive(true);
		}
	}
	public void PCBotCenterPush (){
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
					wBotCenter.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					sukses7=true;
					PanelPC5.SetActive(false);
					cleanseIp();
					tempBotCenter.text="Ok";
					cekbenar();
				}
			}
			catch{
				wBotCenter.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}else
		{
			wBotCenter.SetActive(true);
		}
	}
	public void PCBotRightPush (){
		if(string.IsNullOrEmpty(ipa) == false&&string.IsNullOrEmpty(ipb) == false && string.IsNullOrEmpty(ipc) == false && string.IsNullOrEmpty(ipd) == false
		&& string.IsNullOrEmpty(oktetA) == false&&string.IsNullOrEmpty(oktetB) == false && string.IsNullOrEmpty(oktetC) == false && string.IsNullOrEmpty(oktetD) == false)
		{
			try{
			int v1 = int.Parse (ipa);
			int v2 = int.Parse (ipb);
			int v3 = int.Parse (ipc);
			int v4 = int.Parse (ipd);
			int o1 = int.Parse (oktetA);
			int o2 = int.Parse (oktetB);
			int o3 = int.Parse (oktetC);
			int o4 = int.Parse (oktetD);
			if (v1 > 254 || v2 > 254 || v3 > 254 || v4 > 254 || o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255) {
					wBotRight.SetActive (true);
					nyawa--;
					textnyawa.text=nyawa.ToString();
					cekbenar();
				}else{
					sukses8=true;
					PanelPC6.SetActive(false);
					tempBotRight.text="Ok";
					cleanseIp();
					cekbenar();
				}
			}
			catch{
				wBotRight.SetActive (true);
				nyawa--;
				textnyawa.text=nyawa.ToString();
				cekbenar();
			}
		}else
		{
			wBotRight.SetActive(true);
		}
	}
}