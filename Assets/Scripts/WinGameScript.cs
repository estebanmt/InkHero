using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinGameScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        StartCoroutine(backToMenu());

    }

    IEnumerator backToMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("SeleccionEtapas2");
    }
}