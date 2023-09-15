using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform m_target;
    public float MoveSpeed;

    [SerializeField] private SkinnedMeshRenderer m_renderer;

    public Material Material
    {
        get
        {
            return m_renderer.material;
        }
    }

    void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(m_target);

        m_renderer.material.color = GameManager.Instance.GetRandomColor();
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

            Destroy(other.gameObject);
        }
    }
}
