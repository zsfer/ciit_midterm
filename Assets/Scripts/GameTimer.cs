using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Actually a stopwatch...
/// </summary>
public class GameTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_timerUI;

    private float m_time = 0;

    public string FormattedTime
    {
        get
        {
            var time = TimeSpan.FromSeconds(m_time);
            return time.ToString(@"mm\:ss");
        }
    }

    void Update()
    {
        m_time += Time.deltaTime;
        m_timerUI.text = FormattedTime;
    }
}
