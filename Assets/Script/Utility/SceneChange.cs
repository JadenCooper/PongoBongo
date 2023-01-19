using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayGameTwoPlayer()
    {
        SceneManager.LoadScene("TwoPlayerGameScene");
    }
}
