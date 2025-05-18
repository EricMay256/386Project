using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class UnitPool : MonoBehaviour
{
    public ObjectPool<GameObject> Pool {get; protected set;}
    [SerializeField]
    GameObject _enemyPrefab;
    // Start is called before the first frame update
    void OnEnable()
    {
        Pool = new ObjectPool<GameObject>(CreatePooledEnemy, OnGetEnemyFromPool, OnReleasedToPool, OnDestroyFromPool);
    }

    GameObject CreatePooledEnemy()
    {
        GameObject obj = Instantiate(_enemyPrefab);
        obj.SetActive(false);
        obj.transform.SetParent(transform);
        return obj;
    }

    void OnGetEnemyFromPool(GameObject b)
    {
        b.gameObject.SetActive(true);
    }

    void OnReleasedToPool(GameObject b)
    {
        b.gameObject.SetActive(false);
    }

    void OnDestroyFromPool(GameObject b)
    {
        Destroy(b.gameObject);
    }
}