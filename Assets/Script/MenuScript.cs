using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName:"SampleScene");
    }

    public void CreditsGame()
    {
        SceneManager.LoadScene(sceneName:"Cerdits");
    }

    public void RetourMenu()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }

    public void QuitGame()

    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}