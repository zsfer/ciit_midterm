using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorSwitcher), typeof(Shooter))]
public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask m_detectionMask;
    public float DetectionRadius = 10f;
    [SerializeField] private float m_rotationSpeed = 20;

    private readonly Collider[] m_overlapResults = new Collider[20];

    private GameObject m_target;

    private void Update()
    {
        m_target = GetNearestEnemy();

        if (m_target != null)
        {
            var dir = m_target.transform.position - transform.position;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), m_rotationSpeed * Time.deltaTime);
        }

    }

    private void OnMouseDown()
    {
        GetComponent<ColorSwitcher>().FlipColors();
    }

    private GameObject GetNearestEnemy()
    {
        int found = Physics.OverlapSphereNonAlloc(transform.position, DetectionRadius, m_overlapResults, m_detectionMask);
        GameObject closest = null;
        float shortestDst = 0;

        if (found > 0)
        {
            closest = m_overlapResults[0].gameObject;
            shortestDst = Vector3.Distance(transform.position, closest.transform.position);
        }

        for (int i = 0; i < found; i++)
        {
            var obj = m_overlapResults[i].gameObject;
            float dst = Vector3.Distance(transform.position, obj.transform.position);

            if (dst < shortestDst)
            {
                shortestDst = dst;
                closest = obj;
            }
        }

        return closest;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, DetectionRadius);
    }
}
