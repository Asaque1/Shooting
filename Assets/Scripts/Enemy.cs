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
    private void Update()
    {
        m_time += Time.deltaTime * m_mSpeed;
        var pos = m_spline.EvaluatePosition(m_time);
        transform.position = pos;
    
        if(m_time >= 1)
        {
            m_time = 0;
        }
    }




}