using UnityEngine;
using System.Collections;

public class FixedYScript : MonoBehaviour {


    public Transform player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 v3 = new Vector3(player.position.x, transform.position.y, transform.position.z);
        transform.position = v3;
	}
}
