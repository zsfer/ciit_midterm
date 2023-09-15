using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_score;
    [SerializeField] private TextMeshProUGUI m_time;

    public void SetScore(int score, string time)
    {
        m_score.text = score.ToString();
        m_time.text = time;
    }

}
