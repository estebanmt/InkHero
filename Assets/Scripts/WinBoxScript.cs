using UnityEngine;
using System.Collections;

public class WinBoxScript : MonoBehaviour {

	public Canvas winBoxCanvas;

	void OnTriggerEnter2D(Collider2D c)
	{
		winBoxCanvas.enabled = true;
	}


	// Use this for initialization
	void Start () 
	{
		winBoxCanvas = winBoxCanvas.GetComponent<Canvas> ();
		winBoxCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
