using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    public GameObject transition;
    public void PlayGameButton()
    {
        transition.GetComponent<LevelLoader>().LoadNextLevel();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
