using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {

    public string mainMenu, level1, level2, level3, level4, level5, level6;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
    public void LoadLevel1()
    {
        SceneManager.LoadScene(level1);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene(level2);
    }
    public void LoadLevel3()
    {
        SceneManager.LoadScene(level3);
    }
    public void LoadLevel4()
    {
        SceneManager.LoadScene(level4);
    }
    public void LoadLevel5()
    {
        SceneManager.LoadScene(level5);
    }
    public void LoadLevel6()
    {
        SceneManager.LoadScene(level6);
    }

}
