using UnityEngine;
using System.Collections;

public class Quema : MonoBehaviour {
	bool colisiona;

	public float fadestart;
	public float lifetime;

	void Start ()
	{
		colisiona = false;
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag.Equals("fire") == true){
			colisiona = true;
			Destroy (gameObject, lifetime);
		}
	}
		
	void Update ()
	{
		if (colisiona) {
			fadestart -= Time.deltaTime;
			if ( fadestart < 0 )
			{
				StartCoroutine(FadeTo(0f, 1.0f));
			}

		}

	}

	IEnumerator FadeTo(float aValue, float aTime)
	{
		float alpha = transform.GetComponent<Renderer>().material.color.a;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
		{
			Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha,aValue,t));
			transform.GetComponent<Renderer>().material.color = newColor;
			yield return null;
		}
	}
}
