using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSwitcher : MonoBehaviour
{
    private MeshRenderer m_renderer;

    public int CurrentColorIndex { get; private set; }
    private void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
        m_renderer.material.color = GameManager.Instance.Colors[CurrentColorIndex];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            FlipColors();
    }

    public void FlipColors()
    {
        CurrentColorIndex = (CurrentColorIndex + 1) % GameManager.Instance.Colors.Count;
        m_renderer.material.color = GameManager.Instance.Colors[CurrentColorIndex];
    }

}
