using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PlayerAttackType
{
    baseShot,
    arcShot,
    lay,
    homing,

}
public class Weapon : MonoBehaviour
{
    [Header("ÀÌÆåÆ®¿ë")]
    [SerializeField] ParticleSystem psMuzzle;
    [SerializeField] Bullet prefabBullet;
    [SerializeField] HomingMissile prefabHoming;
    [Header("data")]
    [SerializeField] public PlayerAttackType nowAttackType = PlayerAttackType.baseShot;
    [SerializeField] float speed = 10f;
    [SerializeField] float m_fireLength = 1f;
    [SerializeField] int m_bulletCount = 1;
    [SerializeField] int level = 1;

    [Header("arc")]
    [SerializeField] float arc = 60f;

    [Header("homing")]
    [SerializeField] LayerMask homingFind;
    [SerializeField] float homingSearchRadius = 10f;


    // Start is called before the first frame update


    [ContextMenu(nameof(Levelup))]
    public void Levelup()
    {
        m_bulletCount++;
        level++;
    }

    public void Shoot()
    {
        if (nowAttackType == PlayerAttackType.baseShot)
        {
            BasicShoot();
        }
        else if (nowAttackType == PlayerAttackType.arcShot)
        {
            ArcShoot();
        }
        else if (nowAttackType == PlayerAttackType.homing)
        {
            homingShoot();
        }
    }
    public void BasicShoot()
    {
        psMuzzle.Play();
        prefabBullet.damage = level * 2;
        var segment = m_fireLength / (m_bulletCount + 1);
        var basePos = Vector3.up * m_fireLength * 0.5f;
        for (int i = 0; i < m_bulletCount; i++)
        {
            var obj = Instantiate(prefabBullet);
            var seqPos = Vector3.up * segment * (i + 1);
            obj.Setup(transform.position + basePos - seqPos, transform.right * speed);

        }
    }
    public void ArcShoot()
    {
        psMuzzle.Play();
        m_bulletCount += 2;
        prefabBullet.damage = (int)(level * 1.4f);
        var segment = arc / (m_bulletCount + 1);
        var baseArc = arc * 0.5f;
        for (int i = 0; i < m_bulletCount; i++)
        {
            var obj = Instantiate(prefabBullet);
            var ang = baseArc - segment * (i + 1);
            var dir = Quaternion.Euler(0, 0, ang) * transform.right;
            obj.Setup(transform.position, dir * speed);
        }

        m_bulletCount -= 2;
    }

    public void homingShoot()
    {
        psMuzzle.Play();
        prefabHoming.damage = (int)(level * 1.5f);
        var colliders = Physics2D.OverlapCircleAll(transform.position, homingSearchRadius);

        for (int i = 0; i < Mathf.Min(colliders.Length, m_bulletCount); i++)
        {
            var obj = Instantiate(prefabHoming);

            obj.Setup(transform.position, colliders[i].transform, speed);


        }
    }
}