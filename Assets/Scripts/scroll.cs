using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
	public float speed = 0.1f;
	private MeshRenderer meshRen;
	// Use this for initialization
	void Awake () {
		meshRen = GetComponent<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * speed,0);
		meshRen.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}
