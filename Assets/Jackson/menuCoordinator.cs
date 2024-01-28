using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuCoordinator : MonoBehaviour
{
    public void loadScene()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
