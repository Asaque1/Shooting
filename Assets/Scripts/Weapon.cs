using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAttackType
{
    baseShot,
    arcShot,
    Lay,

}
public class Weapon : MonoBehaviour
{
    [Header("ÀÌÆåÆ®¿ë")]
    [SerializeField] ParticleSystem psMuzzle;
    [SerializeField] Bullet prefabBullet;
    [Header("data")]
    [SerializeField] public PlayerAttackType nowAttackType = PlayerAttackType.baseShot;
    [SerializeField] float speed = 10f;
    [SerializeField] float m_fireLength = 1f;
    [SerializeField] int m_bulletCount = 1;
    // Start is called before the first frame update


public void BasicShoot()
    {
        psMuzzle.Play();
        var segment = m_fireLength / (m_bulletCount+1);
        var basePos = Vector3.up * m_fireLength * 0.5f;
        for(int i=0; i<m_bulletCount; i++)
        {
            var obj = Instantiate(prefabBullet);
            var seqPos = Vector3.up * segment * (i + 1);
            obj.Setup(transform.position + basePos - seqPos, transform.right * speed);

        }
    }
    [ContextMenu(nameof(Levelup))]
    public void Levelup()
    {
        m_bulletCount++;
    }
}
