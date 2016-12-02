using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class HeartShower : MonoBehaviour {
	
	public float scale = 2f;
	public Texture2D tex;
	public int lives = 3;
	public string current_scene_name = "";
	private bool changed = true;
	private float texWidth;
	private float texHeight;
	private static bool _created = false;

	public void lose_life (){
		lives -= 1;
	}

	void Start() {
		texWidth = tex.width * scale;
		texHeight = tex.height * scale;
		tex.Resize ((int) texWidth, (int) texHeight);
	}

	void Update () {
		if (SceneManager.GetActiveScene ().name != current_scene_name) {
			Destroy (this.gameObject);
			_created = false;
		}
	}


	void OnGUI() {
		if (lives > 0) {
			Rect posRect = new Rect (10f, 10f, texWidth / 5f * lives, texHeight);
			Rect texRect = new Rect (0f, 0f, 1.0f / 5f * lives, 1.0f);
			GUI.DrawTextureWithTexCoords (posRect, tex, texRect);
		} 
		else {
			Destroy(this.gameObject);
			_created = false;
			print ("?");
		}
	}
	void Awake() {
		if (! _created) {
			// this is the first instance - make it persist
			DontDestroyOnLoad(this.gameObject);
			_created = true;
		} 
		else {
			print (_created);
			// this must be a duplicate from a scene reload - DESTROY!
			Destroy(this.gameObject);
		}
	}

}
