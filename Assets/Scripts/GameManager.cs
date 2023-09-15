using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public List<Color> Colors = new();
    public bool isGameOver = false;
    public int Score = 0;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI m_scoreUI;
    [SerializeField] private GameObject m_gameOverScreen;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        m_scoreUI.text = Score.ToString();
    }

    public Color GetRandomColor()
    {
        int idx = Random.Range(0, Colors.Count);
        return Colors[idx];
    }

    public GameObject GetPlayer()
    {
        return GameObject.FindGameObjectWithTag("Player");
    }

    public void SetGameOver(bool state)
    {
        isGameOver = state;
        m_gameOverScreen.SetActive(state);

        var time = GetComponent<GameTimer>().FormattedTime;
        m_gameOverScreen.GetComponent<GameOverScreen>().SetScore(Score, time);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
