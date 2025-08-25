using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D m_rigid;

    [SerializeField]
    float m_speed = 1f;

    [ContextMenu(nameof(Fire))]
    void Fire()
    {
        m_rigid.velocity = transform.right * m_speed;
    }

    public void Fire(Vector3 v)
    {
        m_rigid.velocity = v * m_speed;
        transform.right = v;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"Ãæµ¹: {collision.gameObject.name}");

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
    private void OnCollisonEnter2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionEnter2D:{collision.gameObject.name}");
    }

}