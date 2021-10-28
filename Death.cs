using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Dungeon");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
