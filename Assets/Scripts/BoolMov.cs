using UnityEngine;
using System.Collections;

public class BoolMov : MonoBehaviour {
	private Vector3 posicion_inicial;
	public bool has_moved = false;
	// Use this for initialization
	void Start () {
		posicion_inicial = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Abs(posicion_inicial.x - transform.position.x) > 0.5f||
			Mathf.Abs(posicion_inicial.y - transform.position.y) > 0.5f){
			has_moved = true;
		}
	
	}
}
