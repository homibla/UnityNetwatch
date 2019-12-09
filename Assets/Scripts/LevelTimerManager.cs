using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelTimerManager : MonoBehaviour {
	public static LevelTimerManager instance = null;
	[SerializeField]
	int waktutimer;
	[SerializeField]
	private Text timerui;
	[SerializeField]
	private GameObject kalah;
//	int sceneIndex, levelPassed;
	// Use this for initialization
	void Start () {
//		sceneIndex = SceneManager.GetActiveScene ().buildIndex;
//		levelPassed = PlayerPrefs.GetInt ("LevelPassed");
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt ("Skor", 0);
		PlayerPrefs.SetInt ("Nyawa", 3);//Nyawa di level2
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void resethitunganmenang(){
		PlayerPrefs.SetInt ("Skor", 0);
		PlayerPrefs.SetInt ("Nyawa", 3);
	}
	public void levelToload (int level) {
		SceneManager.LoadScene (level);
	}
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
	public void pauseTimer(){
		CancelInvoke("CountDown");
	}
}
