using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[CreateAssetMenu(menuName ="Settings/World")]
public class WordSettings : SingletonSettings<WordSettings>
{
    public int hpPlayer;

    public int nbBriqueTot;

    public int nbBriqueBrake;

    public int nbBalle;


    public void CheckGameOver()
    {
        if (hpPlayer < 0)
        {
           // SceneManager.LoadScene(sceneName: "MenuLoose");
        }
    }


    public void CheckBrique()
    {
        brique[] br = GameObject.FindObjectsOfType<brique>();
        nbBriqueTot = br.Length;
    }

    public void GameOver()
    {
        // SceneManager.LoadScene(sceneName: "MenuLoose");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void CheckWin()
    {
        if (nbBriqueBrake == nbBriqueTot)
        {
            // SceneManager.LoadScene(sceneName: "MenuWin");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Awake()
    {
        
    }


}



