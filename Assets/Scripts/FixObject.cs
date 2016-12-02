using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class FixObject : MonoBehaviour {

	public string etiqueta_cosa_fija = "Player";
	private bool collided;
	private float buffer = 1f;
	private FixedJoint2D joint;
	public PlayerScript player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (collided) {
			if (Input.GetButtonDown ("Jump") || CrossPlatformInputManager.GetButtonDown ("Jump")) {
				collided = false;
				Destroy (joint);
			} 
			//intentar q no se vea la animacion y que el personaje no mueva la plataforma
//			else {
//				player.set_grounded_anim();
//				player.setSpeedX(0f) ;
//			}
		}
		if(buffer < 1f){
			buffer += Time.deltaTime;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag.Equals(etiqueta_cosa_fija) && buffer >= 1)
		{
			joint = gameObject.AddComponent<FixedJoint2D> ();
			joint.enableCollision = true;
			joint.connectedBody = c.rigidbody;
			collided = true;
			buffer = 0f;
		}
	}




		
}
