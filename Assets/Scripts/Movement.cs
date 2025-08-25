using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D m_rigid;
    [SerializeField]
    Animator m_anim;
    [SerializeField]
    Vector2 m_velocity;

    [SerializeField]
    Gun m_prefabBullet;

    private void Start()
    {
        m_rigid = GetComponent<Rigidbody2D>();
        m_anim = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        m_velocity = new Vector2(x, y);

        m_anim.SetFloat("Yvelo",y);

        if (Input.GetMouseButtonDown(0))
        {
            var pos = transform.position;
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = 0;

            var dir = targetPos - pos;

            var obj = Instantiate(m_prefabBullet);
            obj.transform.position = pos;
            obj.Fire(dir.normalized * 5f);

            Destroy(obj.gameObject, 2f);
        }
    }
    private void FixedUpdate()
    {
        m_rigid.velocity = m_velocity;
    }

    private void OnDrawGizmos()
    {
        var pos = transform.position;
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0;

        var dir = targetPos - pos;

        Debug.DrawLine(pos, pos + dir, Color.blue);
        Debug.DrawLine(pos, pos + dir.normalized, Color.green);
    }
}