using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitPool))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    int _maxEnemiesSpawned = 100, _spawnsPerSecond = 1;
    [SerializeField]
    bool _usePooling = false;
    [SerializeField]
    GameObject _enemyPrefab;
    public UnitPool Pool {get; protected set;}
    float _timer = 0;
    [SerializeField]
    int _curSpawned = 0;//Should increment up to maxEnemiesSpawned
    [SerializeField]
    bool _uniqueMaterial = false;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        Pool = GetComponent<UnitPool>();
        player = FindFirstObjectByType<Player>().transform;
    }

    public void EnemyKilled(GameObject enemy)
    {
        _curSpawned--;
        Debug.Log("Enemy Killed");
        if(_usePooling)
            Pool.Pool.Release(enemy);
        else
            Destroy(enemy);
    }

    GameObject SpawnEnemy()
    {
        GameObject go;
        if(_usePooling)
        {
            go = Pool.Pool.Get();
            go.GetComponent<Enemy>().Ready();
        }
        else
        {
            go = Instantiate(_enemyPrefab, transform);
        }
        go.transform.position = new Vector3(player.position.x + Random.Range(-8f, 8), 
            player.position.y + Random.Range(-8f, 8));
            
        if(_uniqueMaterial)
        {
            //This code block automatically instantiates the materials and makes them unique to this renderer. It is your responsibility to destroy the materials when the game object is being destroyed. 
            go.GetComponent<SpriteRenderer>().material.color = Random.ColorHSV();
        }
        //go.GetComponent<SpriteRenderer>().color = Random.ColorHSV();
        _curSpawned++;
        return go;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime * Time.timeScale;
        while(_curSpawned < _maxEnemiesSpawned && _timer > 1f/_spawnsPerSecond)
        {
            SpawnEnemy();
            _timer -= 1f/_spawnsPerSecond;
        }
    }
}
