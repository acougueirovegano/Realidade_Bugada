using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI KillCountText;
     [SerializeField] private GameObject gameOverUI;

    private int killCount;
    public static UI instance;

    private void Awake()
    {
        instance = this;
        Time.timeScale = 1;
    }

    private void Update()
    {
        timerText.text = Time.time.ToString("F2") + "s";
    }
public void EnableGameOverUi()
    {
        Time.timeScale = .5f;
        gameOverUI.SetActive(true);
    }
    public void AddKillCount()
    {
        killCount++;
        KillCountText.text = killCount.ToString();
    }

    public void RestartLevel()
    {
       int SceneIndex = SceneManager.GetActiveScene().buildIndex;
       SceneManager.LoadScene(SceneIndex);
    }
}