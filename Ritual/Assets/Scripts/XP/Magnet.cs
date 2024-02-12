using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float magnetSpeed;
    [SerializeField] private LayerMask xpLayer;

    void Update()
    {
        PullXp();
    }

    private void PullXp()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, range, xpLayer);
        for (int i = 0; i < hits.Length; i++)
        {
            hits[i].transform.position += (transform.position - hits[i].transform.position).normalized * magnetSpeed * Mathf.Lerp(0,1, Vector3.Distance(transform.position, hits[i].transform.position));
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
