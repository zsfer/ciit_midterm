using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody m_rb;
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        m_rb.AddForce(transform.forward * 2000);

        GetComponent<Renderer>().material.color = GameManager.Instance.Colors[GameManager.Instance.GetPlayer().GetComponent<ColorSwitcher>().CurrentColorIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (!IsSameColor(other.GetComponent<Renderer>().material))
                return;

            GameManager.Instance.Score++;
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    bool IsSameColor(Material otherMaterial)
    {
        var mat = GetComponent<Renderer>().material;

        return mat.color.Equals(otherMaterial.color);
    }
}
