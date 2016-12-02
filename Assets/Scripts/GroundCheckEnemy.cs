using UnityEngine;
using System.Collections;

public class GroundCheckEnemy : MonoBehaviour {

	private SaltoEnemigo player;

	void Start()
	{
		player = gameObject.GetComponentInParent<SaltoEnemigo>();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if(!col.GetComponent<Collider2D>().tag.Equals("trigger"))
			player.grounded = true;
	}

	void OnTriggerStar2D(Collider2D col)
	{
		if (!col.GetComponent<Collider2D>().tag.Equals("trigger"))
			player.grounded = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (!col.GetComponent<Collider2D>().tag.Equals("trigger"))
			player.grounded = false;
	}
}