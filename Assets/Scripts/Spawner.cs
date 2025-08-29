using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Spawner : MonoBehaviour
{
    [System.Serializable]
    struct SpawnData
    {
        public Enemy prefabEnemy;
        public int spawnCount;
        public float spawnTime;
        public SplineContainer spline;
        
    }
    // Start is called before the first frame update
    [SerializeField]
    SpawnData[] m_spawnDatas;

    IEnumerator Start()
    {
        foreach (var data in m_spawnDatas) {
            for (int i = 0; i < data.spawnCount; i++) {
                var obj = Instantiate(data.prefabEnemy);
                obj.Setup(data.spline);
                yield return new WaitForSeconds(data.spawnTime);
            }
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
