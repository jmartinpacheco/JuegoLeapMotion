using UnityEngine;
using System.Collections;

public class objeto : MonoBehaviour {
	public float vida=20.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void DisminuirVida(float damage){
		vida -= damage;
		if(vida<=0f){
			DestroyObject(this.gameObject);

		}
	}
}
