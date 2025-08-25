using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody;
    [SerializeField] GameObject hitfx;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = Instantiate(hitfx);
        obj.transform.position = transform.position;
        
        Destroy(gameObject);
    }
    public void Setup(Vector3 pos, Vector2 velocity)
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = velocity;
        rigidbody.position = pos;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
