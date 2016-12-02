using UnityEngine;
using System.Collections;

public class PickUpScript : MonoBehaviour {

    public PickUpType type;
    public int value;
    public AudioClip collectSound;

    bool gaveMoney = false;
    

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.tag.Equals("Player"))
        {
            
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            if (type == PickUpType.Coin && !gaveMoney)
            {
                PlayerScript moneyScript = c.gameObject.GetComponent<PlayerScript>();
                
                GameControl.control.money += 1;
                if (moneyScript != null)
                    moneyScript.addCoin(1);

                gaveMoney = true;
            }
            DestroyObject(gameObject);
        }
    }
}

public enum PickUpType { Coin}
