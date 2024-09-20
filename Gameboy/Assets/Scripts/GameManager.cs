using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int points;
    [SerializeField] TMP_Text score;
    [SerializeField] GameObject EndGame;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    public void Score(Enemy e = null)
    {
        points += 100 + (Combo.Instance.count * 10);
        points = Mathf.Clamp(points, 0, 99999);
        score.text = points.ToString("00000");
    }

    public void WinGame()
    {
        EndGame.SetActive(true);
        EndGame.GetComponent<Animator>().Play("Win");
        Time.timeScale = 0;
    }

    public void LoseGame()
    {
        EndGame.SetActive(true);
        EndGame.GetComponent<Animator>().Play("Defeat");
        Time.timeScale = 0;
    }

    public void GoToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    private void OnEnable()
    {
        Enemy.die += Score;
    }

    private void OnDisable()
    {
        Enemy.die -= Score;
    }
}
