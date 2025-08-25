using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Enemy : MonoBehaviour
{
    [Header("how")]
    [SerializeField] SplineContainer m_spline;
    [SerializeField] float m_time;
    [SerializeField] float m_mSpeed;
    [SerializeField] GameObject prefabExplosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = Instantiate(prefabExplosion);
        obj.transform.position = transform.position;

        Destroy(gameObject);
    }
    private void Update()
    {
        m_time += Time.deltaTime * m_mSpeed;
        var pos = m_spline.EvaluatePosition(m_time);
        transform.position = pos;
    
        
    }

    public void Setup(SplineContainer spline)
    {
        m_spline = spline;
        transform.position = m_spline.EvaluatePosition(0f);
    }


}