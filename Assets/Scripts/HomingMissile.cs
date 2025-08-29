using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField] GameObject hitfx;
    Transform m_target;
    [SerializeField] AnimationCurve accelCurve;
    [SerializeField] float maxStearingAngle = 100f;
    [SerializeField] public int damage;
    float m_speed;
    float m_time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = Instantiate(hitfx);
        obj.transform.position = transform.position;
        
        var collisionEvent = collision.GetComponent<Enemy>();
        if (collisionEvent != null)
            collisionEvent.damage.Invoke(damage);
        Destroy(gameObject);
    }
    public void Setup(Vector3 pos, Transform target, float speed)
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.position = pos;
        m_speed = speed;
        m_target = target;
    }

    public void Update()
    {
        m_time += Time.deltaTime;
        var dir = transform.right;
        if(m_target != null)
            dir = (m_target.position - transform.position).normalized;
        
        dir = Vector3.RotateTowards(transform.right, dir, maxStearingAngle
            * Time.deltaTime * Mathf.Deg2Rad, 0f);
        rigidbody.linearVelocity = dir * accelCurve.Evaluate(m_time / 3f) * m_speed;
        transform.right = dir;
    }


}
