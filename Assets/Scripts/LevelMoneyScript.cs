using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelMoneyScript : MonoBehaviour {

    public GameObject moneyObject;

    private Text moneyText;
    private int money;

	// Use this for initialization
	void Start () {

        moneyText = moneyObject.GetComponent<Text>();
        Debug.Log(moneyText);
    }
	
    public void AddMoney(int moneyGained)
    {
        money += moneyGained;
        moneyText.text = money.ToString();
    }
}
