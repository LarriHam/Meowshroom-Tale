using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CongratsScreen : MonoBehaviour
{
    public GameObject transition;
    public void BackToMainMenu()
    {
        transition.GetComponent<LevelLoader>().LoadMainMenu();
    }
}
