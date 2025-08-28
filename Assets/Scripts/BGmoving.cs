using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BGmoving : MonoBehaviour
{
    [Header("imgs")]
    [SerializeField] GameObject[] spaces;
    [SerializeField] GameObject[] stars;
    [SerializeField] GameObject planet;

    [Header("parameter")]
    [SerializeField] float m_speed;
    [SerializeField] float m_time;
    [SerializeField] float reapitPosition;
    [SerializeField] float spawnPoint;
    [SerializeField] float planetData;
    void Start()
    {
        planetData = Random.Range(-20f, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        m_time += Time.deltaTime;
        for (int i = 0; i < spaces.GetLength(0);i++)
        {
            spaces[i].gameObject.transform.position += new Vector3(-0.45f, 0, 0) * m_speed;
            if (spaces[i].gameObject.transform.position.x <= reapitPosition)
            {
                spaces[i].gameObject.transform.position += new Vector3(54.4f, 0, 0);
            }
        }
        for (int i = 0; i < stars.GetLength(0); i++)
        {
            stars[i].gameObject.transform.position += new Vector3(-1.3f, 0, 0) * m_speed;
            if (stars[i].gameObject.transform.position.x <= reapitPosition)
            {
                stars[i].gameObject.transform.position += new Vector3(53.2f - (Mathf.Abs(planetData)/4), 0, 0);
            }
        }
        
        planet.gameObject.transform.position += new Vector3(-0.9f, 0, 0) * m_speed;
        if(planet.gameObject.transform.position.x <= (reapitPosition - Mathf.Abs(planetData)))
        {
            planetData = Random.Range(-20f, 20f);
            planet.gameObject.transform.position = new Vector3(20.2f + Mathf.Abs(planetData), 0, 0);
            
        }
        if (planetData > 0)
        {
            planet.gameObject.transform.rotation = Quaternion.Euler(0, 0, 180);

        }
        else
        {
            planet.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
