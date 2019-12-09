using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class testpanel : MonoBehaviour {
	int skor,sukses;
	int nyawa,counternetmask;
	string oktetA,oktetB,oktetC,oktetD;
	// string[] netmas= new string[]{
	// 	"255.0.0.0","255.128.0.0","255.192.0.0","255.224.0.0","255.240.0.0","255.248.0.0","255.252.0.0","255.254.0.0","255.255.0.0",
	// 	"255.255.128.0","255.255.192.0","255.255.224.0","255.255.240.0","255.255.248.0","255.255.252.0","255.255.254.0","255.255.255.0",
	// 	"255.255.255.128","255.255.255.192","255.255.255.224","255.255.255.240","255.255.255.248","255.255.255.252"
	// };
	string[] netmas = new string[]{
		"255.255.255.0","255.255.255.128","255.255.255.192",
		"255.255.255.224","255.255.255.240","255.255.255.248","255.255.255.252"
	};
	string ipa,ipb,ipc,ipd;
	[SerializeField]
	private Text textipdiluar;
	[SerializeField]
	private Text textnmdiluar;
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
//--Punya Server--
	[SerializeField]
	private GameObject Warning;
	[SerializeField]
	private GameObject WarningIP;
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
		if (PlayerPrefs.GetInt("Nyawa") == 0) {
			kalah.SetActive (true);
		}
		if (PlayerPrefs.GetInt("Skor")==8) {
			showMenang();
		}
	}
	
	void showMenang(){
		menang.SetActive (true);
		if(PlayerPrefs.GetInt("Nyawa")==3)
			{
				textSkor.text="3000";
				starl.SetActive(true);
				starc.SetActive(true);
				starr.SetActive(true);
			}
		if(PlayerPrefs.GetInt("Nyawa")==2)
			{
				textSkor.text="2000";
				starl.SetActive(true);
				starc.SetActive(true);
			}
		if(PlayerPrefs.GetInt("Nyawa")==1){
				textSkor.text="1000";
				starl.SetActive(true);
			}
	}
	void turnWarning(){
		Warning.SetActive (true);
		nyawa=PlayerPrefs.GetInt("Nyawa");
		nyawa--;
		textnyawa.text=nyawa.ToString();
		PlayerPrefs.SetInt("Nyawa",nyawa);
		PlayerPrefs.DeleteKey("ipbagian1");
		cekbenar();
	}
	//-----------PushNilai------------
	public void goPush (int pc){	
		int tempnm;
		tempnm = netmas.Length;
		if (string.IsNullOrEmpty (inputIPa.text) == false && string.IsNullOrEmpty (inputIPb.text) == false
		   && string.IsNullOrEmpty (inputIPc.text) == false && string.IsNullOrEmpty (inputIPd.text) == false
		   && string.IsNullOrEmpty (inputNMa.text) == false && string.IsNullOrEmpty (inputNMb.text) == false
		   && string.IsNullOrEmpty (inputNMc.text) == false && string.IsNullOrEmpty (inputNMd.text) == false) {
			string ipbag1 = inputIPa.text + inputIPb.text + inputIPc.text;
			string ipbag2 = inputIPa.text + inputIPb.text + inputIPc.text + inputIPd.text;
			string netm = inputNMa.text + inputNMb.text + inputNMc.text + inputNMd.text;
			string netm2 = inputNMa.text +"."+ inputNMb.text +"."+ inputNMc.text +"."+ inputNMd.text;
			if (PlayerPrefs.HasKey ("ipbagian1") == false) {
				PlayerPrefs.SetString ("ipbagian1", ipbag1);

			}
			if (PlayerPrefs.HasKey ("netms") == false) {
				PlayerPrefs.SetString ("netms", netm);
			}
			try {
				int v1 = int.Parse (inputIPa.text);
				int v2 = int.Parse (inputIPb.text);
				int v3 = int.Parse (inputIPc.text);
				int v4 = int.Parse (inputIPd.text);
				//int o1 = int.Parse (inputNMa.text);
				//int o2 = int.Parse (inputNMb.text);
				//int o3 = int.Parse (inputNMc.text);
				//int o4 = int.Parse (inputNMd.text);
				//|| o1 != 255 || o2 != 255 || o3 != 255 || o4 > 255
				if (v1 > 223 ||v1<192 || v2 > 254 || v3 > 254 || v4 > 254 || v4 ==0 ||v4==255) {
					turnWarning ();
				}else{
					for(int i = 0;i<netmas.Length;i++){
						if(netm2==netmas[i]){
							if(PlayerPrefs.HasKey("globalnetmask")==false){
								PlayerPrefs.SetString("globalnetmask",netm);
							}
							if (sukses < 1) {
								if (PlayerPrefs.GetString ("ipbagian1") == ipbag1 && PlayerPrefs.GetString ("netms") == netm) {
									switch (pc) {
									case 1:
										PlayerPrefs.SetString ("server", ipbag2);
										PlayerPrefs.SetString("servernm",netm);
										if (PlayerPrefs.GetString ("server") == PlayerPrefs.GetString ("pc1")
											|| PlayerPrefs.GetString ("server") == PlayerPrefs.GetString ("pc2")
											|| PlayerPrefs.GetString ("server") == PlayerPrefs.GetString ("pc3")
											|| PlayerPrefs.GetString ("server") == PlayerPrefs.GetString ("pc4")
											|| PlayerPrefs.GetString ("server") == PlayerPrefs.GetString ("pc5")
											|| PlayerPrefs.GetString ("server") == PlayerPrefs.GetString ("pc6")
											|| PlayerPrefs.GetString ("server") == PlayerPrefs.GetString ("router")
											|| PlayerPrefs.GetString ("servernm") != PlayerPrefs.GetString ("globalnetmask")
											|| PlayerPrefs.GetString("server") == "127001"
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}
										break;
									case 2:
										PlayerPrefs.SetString ("router", ipbag2);
										PlayerPrefs.SetString("routernm",netm);
										if (PlayerPrefs.GetString ("router") == PlayerPrefs.GetString ("pc1")
											|| PlayerPrefs.GetString ("router") == PlayerPrefs.GetString ("pc2")
											|| PlayerPrefs.GetString ("router") == PlayerPrefs.GetString ("pc3")
											|| PlayerPrefs.GetString ("router") == PlayerPrefs.GetString ("pc4")
											|| PlayerPrefs.GetString ("router") == PlayerPrefs.GetString ("pc5")
											|| PlayerPrefs.GetString ("router") == PlayerPrefs.GetString ("pc6")
											|| PlayerPrefs.GetString ("router") == PlayerPrefs.GetString ("server")
											|| PlayerPrefs.GetString ("routernm") != PlayerPrefs.GetString ("globalnetmask")
											|| PlayerPrefs.GetString("router") == "127001"
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}
										break;
									case 3:
										PlayerPrefs.SetString ("pc1", ipbag2);
										PlayerPrefs.SetString("pc1nm",netm);
										if (PlayerPrefs.GetString ("pc1") == PlayerPrefs.GetString ("router")
											|| PlayerPrefs.GetString ("pc1") == PlayerPrefs.GetString ("pc2")
											|| PlayerPrefs.GetString ("pc1") == PlayerPrefs.GetString ("pc3")
											|| PlayerPrefs.GetString ("pc1") == PlayerPrefs.GetString ("pc4")
											|| PlayerPrefs.GetString ("pc1") == PlayerPrefs.GetString ("pc5")
											|| PlayerPrefs.GetString ("pc1") == PlayerPrefs.GetString ("pc6")
											|| PlayerPrefs.GetString ("pc1") == PlayerPrefs.GetString ("server")
											|| PlayerPrefs.GetString("pc1") == "127001"
											|| PlayerPrefs.GetString ("pc1nm") != PlayerPrefs.GetString ("globalnetmask")
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}
										break;
									case 4:
										PlayerPrefs.SetString ("pc2", ipbag2);
										PlayerPrefs.SetString("pc2nm",netm);
										if (PlayerPrefs.GetString ("pc2") == PlayerPrefs.GetString ("router")
											|| PlayerPrefs.GetString ("pc2") == PlayerPrefs.GetString ("pc1")
											|| PlayerPrefs.GetString ("pc2") == PlayerPrefs.GetString ("pc3")
											|| PlayerPrefs.GetString ("pc2") == PlayerPrefs.GetString ("pc4")
											|| PlayerPrefs.GetString ("pc2") == PlayerPrefs.GetString ("pc5")
											|| PlayerPrefs.GetString ("pc2") == PlayerPrefs.GetString ("pc6")
											|| PlayerPrefs.GetString ("pc2") == PlayerPrefs.GetString ("server")
											|| PlayerPrefs.GetString ("pc2nm") != PlayerPrefs.GetString ("globalnetmask")
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}
										break;
									case 5:
										PlayerPrefs.SetString ("pc3", ipbag2);
										PlayerPrefs.SetString("pc3nm",netm);
										if (PlayerPrefs.GetString ("pc3") == PlayerPrefs.GetString ("router")
											|| PlayerPrefs.GetString ("pc3") == PlayerPrefs.GetString ("pc1")
											|| PlayerPrefs.GetString ("pc3") == PlayerPrefs.GetString ("pc2")
											|| PlayerPrefs.GetString ("pc3") == PlayerPrefs.GetString ("pc4")
											|| PlayerPrefs.GetString ("pc3") == PlayerPrefs.GetString ("pc5")
											|| PlayerPrefs.GetString ("pc3") == PlayerPrefs.GetString ("pc6")
											|| PlayerPrefs.GetString ("pc3") == PlayerPrefs.GetString ("server")
											|| PlayerPrefs.GetString ("pc3nm") != PlayerPrefs.GetString ("globalnetmask")
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}

										break;
									case 6:
										PlayerPrefs.SetString ("pc4", ipbag2);
										PlayerPrefs.SetString("pc4nm",netm);
										if (PlayerPrefs.GetString ("pc4") == PlayerPrefs.GetString ("router")
											|| PlayerPrefs.GetString ("pc4") == PlayerPrefs.GetString ("pc1")
											|| PlayerPrefs.GetString ("pc4") == PlayerPrefs.GetString ("pc2")
											|| PlayerPrefs.GetString ("pc4") == PlayerPrefs.GetString ("pc3")
											|| PlayerPrefs.GetString ("pc4") == PlayerPrefs.GetString ("pc5")
											|| PlayerPrefs.GetString ("pc4") == PlayerPrefs.GetString ("pc6")
											|| PlayerPrefs.GetString ("pc4") == PlayerPrefs.GetString ("server")
											|| PlayerPrefs.GetString ("pc4nm") != PlayerPrefs.GetString ("globalnetmask")
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}

										break;
									case 7:
										PlayerPrefs.SetString ("pc5", ipbag2);
										PlayerPrefs.SetString("pc5nm",netm);
										if (PlayerPrefs.GetString ("pc5") == PlayerPrefs.GetString ("router")
											|| PlayerPrefs.GetString ("pc5") == PlayerPrefs.GetString ("pc1")
											|| PlayerPrefs.GetString ("pc5") == PlayerPrefs.GetString ("pc2")
											|| PlayerPrefs.GetString ("pc5") == PlayerPrefs.GetString ("pc3")
											|| PlayerPrefs.GetString ("pc5") == PlayerPrefs.GetString ("pc4")
											|| PlayerPrefs.GetString ("pc5") == PlayerPrefs.GetString ("pc6")
											|| PlayerPrefs.GetString ("pc5") == PlayerPrefs.GetString ("server")
											|| PlayerPrefs.GetString ("pc5nm") != PlayerPrefs.GetString ("globalnetmask")
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}

										break;
									case 8:
										PlayerPrefs.SetString ("pc6", ipbag2);
										PlayerPrefs.SetString("pc6nm",netm);
										if (PlayerPrefs.GetString ("pc6") == PlayerPrefs.GetString ("router")
											|| PlayerPrefs.GetString ("pc6") == PlayerPrefs.GetString ("pc1")
											|| PlayerPrefs.GetString ("pc6") == PlayerPrefs.GetString ("pc2")
											|| PlayerPrefs.GetString ("pc6") == PlayerPrefs.GetString ("pc3")
											|| PlayerPrefs.GetString ("pc6") == PlayerPrefs.GetString ("pc4")
											|| PlayerPrefs.GetString ("pc6") == PlayerPrefs.GetString ("pc5")
											|| PlayerPrefs.GetString ("pc6") == PlayerPrefs.GetString ("server")
											|| PlayerPrefs.GetString ("pc5nm") != PlayerPrefs.GetString ("globalnetmask")
											) {
											WarningIP.SetActive (true);
											PlayerPrefs.DeleteKey("ipbagian1");
										} else {
											tempServer.text = "Ok";
											skor = PlayerPrefs.GetInt ("Skor");
											PlayerPrefs.SetInt ("Skor", skor = skor + 1);
											sukses = 1;
											cekbenar ();
											textipdiluar.text = inputIPa.text + "." + inputIPb.text + "." + inputIPc.text + "." + inputIPd.text;
											textnmdiluar.text = inputNMa.text + "." + inputNMb.text + "." + inputNMc.text + "." + inputNMd.text;
										}

										break;
									}
									break;
								} else {
									WarningIP.SetActive (true);
									break;
								}
							}
							break;
						}
						if(netm2!=netmas[i]){
							counternetmask++;
						}
					}
					if(counternetmask==netmas.Length){
						WarningIP.SetActive(true);
						PlayerPrefs.DeleteKey("netms");
					}
				}
			} catch {
				turnWarning ();
			}
		}
		else
		{
				turnWarning();
		}
	}
}
