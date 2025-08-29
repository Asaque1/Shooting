using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D rigid;
    Weapon weapon;
    [SerializeField]
    float m_speed = 5f;
    [SerializeField]
    int life = 5;
    Vector2 m_velocity = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        m_velocity = new Vector2(x, y) * m_speed;

        if (Input.GetKeyDown(KeyCode.J))
            weapon.Shoot();


    }
    private void FixedUpdate()
    {
        rigid.linearVelocity = m_velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(life <= 0)
        {
            SceneManager.LoadScene("end");
        }
        else
        {
            this.transform.position = new Vector3(0,0,0);
            life--;
        }

    }

}

