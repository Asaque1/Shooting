using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    [Header("how")]
    [SerializeField] SplineContainer m_spline;
    [SerializeField] float m_time;
    [SerializeField] float m_mSpeed;
    [SerializeField] GameObject prefabExplosion;
    [SerializeField] int hp = 10;

    [SerializeField] public UnityEvent<int> damage;

    public void Start()
    {
        damage.AddListener(Ondamage);
    }
    public void Ondamage(int dmg)
    {
        var obj = Instantiate(prefabExplosion);
        obj.transform.position = transform.position;
        hp -= dmg;
    }

    private void Update()
    {
        m_time += Time.deltaTime * m_mSpeed;

        if (m_time > 1)
            m_time = 0;

        var pos = m_spline.EvaluatePosition(m_time);
        transform.position = pos;
    
        if(hp <= 0)
            Destroy(gameObject);
    }

    public void Setup(SplineContainer spline)
    {
        m_spline = spline;
        transform.position = m_spline.EvaluatePosition(0f);
    }


}