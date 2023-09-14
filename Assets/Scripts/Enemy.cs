using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform m_target;
    public float MoveSpeed;

    void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(m_target);

        GetComponent<Renderer>().material.color = GameManager.Instance.GetRandomColor();
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = MoveSpeed * Time.deltaTime * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SetGameOver(true);
        }
    }
}
