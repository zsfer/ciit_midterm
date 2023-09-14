using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay")]
    public List<Color> Colors = new();
    public bool isGameOver = false;
    public int Score = 0;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
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
        isGameOver = true;
    }
}
