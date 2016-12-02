using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
	public float lifetime;
	public float fadestart;

	void Start ()
	{
		Destroy (gameObject, lifetime);

	}
	void Update ()
	{
		fadestart -= Time.deltaTime;
		if ( fadestart < 0 )
		{
			StartCoroutine(FadeTo(0f, 1.0f));
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