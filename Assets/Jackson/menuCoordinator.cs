using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuCoordinator : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void loadIntroText()
    {
        SceneManager.LoadScene("Intro");
    }
    public void loadScene()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
