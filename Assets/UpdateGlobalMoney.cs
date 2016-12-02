using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateGlobalMoney : MonoBehaviour {

    Text text;
    
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = GameControl.control.money.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
