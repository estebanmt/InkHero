using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SelectorEtapa : MonoBehaviour {

	// Use this for initialization
	public string nivel_a_cargar = "Level 1";
	void Start () {
	
	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag.Equals("Player") == true){
			SceneManager.LoadScene (nivel_a_cargar);

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
