using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Update is called once per frame

    public GameObject canvas;
    public void GoToNextScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void CreditsCanvas()
    {
        canvas.SetActive(true);
    }
    public void CreditsCanvasClose()
    {
        canvas.SetActive(false);
    }
}

