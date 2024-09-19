using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; 
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void DelayGameTime(float value, float time)
    {
        Time.timeScale = value;

        Invoke("ResetTime", time);
    }

    private void ResetTime()
    {
        Time.timeScale = 1;
    }
}
