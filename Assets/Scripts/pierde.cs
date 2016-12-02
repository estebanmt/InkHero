using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pierde : MonoBehaviour {
	Vector3 tempPos;
    public float y_minimo_caida;
	public GameObject animacion_muerte;
	private HeartShower hearts;
	public string ir_a_al_morir = "GameOverScene";
	private bool animando_muerte = false;
	private Object instance_anim;

	public void restart_scene(){
		if (hearts != null) {
			hearts.lose_life ();
			if (hearts.lives > 0){
				int scene = SceneManager.GetActiveScene().buildIndex;
				SceneManager.LoadScene(scene, LoadSceneMode.Single);
			}
			else{
				Application.LoadLevel (ir_a_al_morir);
			}
		}
		else{
			Application.LoadLevel (ir_a_al_morir);
		}
	}

	public void anim_pierde_y_restart_scene()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		Vector3 posicion_player = player.transform.position;
		Rigidbody2D rgbd_player = player.GetComponent<Rigidbody2D>();
		DestroyObject(rgbd_player);
		SpriteRenderer renderer_player = player.GetComponent<SpriteRenderer>();
		renderer_player.enabled = false;

		BoxCollider2D collider_player = player.GetComponent<BoxCollider2D>();
		collider_player.enabled = false;

		instance_anim = Instantiate(animacion_muerte, posicion_player, Quaternion.identity);
		animando_muerte = true;
	}

	void Start ()
	{
		if (GameObject.Find("Hearts") != null){
			hearts = GameObject.Find("Hearts").GetComponentInParent<HeartShower>();
		}

	}


	void Update () {
		if (animando_muerte){
			if (!instance_anim) {
				restart_scene();
			}
			
		}
		else if (transform.position.y < y_minimo_caida) {
			anim_pierde_y_restart_scene();
		}
	}
	void OnCollisionEnter2D(Collision2D c){
		if (c.collider.tag.Equals("Enemy") == true){
			anim_pierde_y_restart_scene();
		}
	}

}