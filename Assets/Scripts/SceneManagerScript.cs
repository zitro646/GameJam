using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public  void end_game()
    {
        Debug.Log("Cierra el programa\n");
        Application.Quit();
    }
}
