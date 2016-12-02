using UnityEngine;
using System.Collections;

public class movimiento_horizontal : MonoBehaviour {

	public float movespeed;
	public float limite_min_x;
	public float limite_max_x;
	// Use this for initialization
	private SaltoEnemigo player;
	void Start()
	{
		player = gameObject.GetComponentInParent<SaltoEnemigo>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (movespeed, 0, 0) * Time.deltaTime);
		if ((transform.position.x <= limite_min_x && movespeed < 0) || 
			(transform.position.x >= limite_max_x && movespeed > 0)) {
			transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
//			Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//			transform.localScale = temp;
		}
	}
	void OnCollisionEnter2D(Collision2D c){
		if (! player.grounded) {
			transform.localScale = new Vector3(transform.localScale.x *-1, transform.localScale.y, transform.localScale.z);
//			Vector3 temp = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
//			transform.localScale = temp;
		}
	}
		
}
