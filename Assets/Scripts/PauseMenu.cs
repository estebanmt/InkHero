using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if(paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if(!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Pause()
    {
        paused = true;
    }

    public void Unpause()
    {
        if (paused)
            paused = !paused;
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("SeleccionEtapas2");
        if (paused)
            paused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("TitleScreen2");
        if (paused)
            paused = false;
    }

}
