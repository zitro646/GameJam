using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Nivel_1");
    }

    public void GoBackToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public  void end_game()
    {
        Debug.Log("Cierra el programa\n");
        Application.Quit();
    }
}
