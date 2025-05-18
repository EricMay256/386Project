using UnityEngine;

public class PlayerController03 : MonoBehaviour
{
  float _moveSpeed = 5f;
  EnemyManager _enemyManager;
  int _totalHealth = 100, _curHealth = 100;
  public float HealthPct => (float)_curHealth / _totalHealth;
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    _curHealth = _totalHealth;
    //Finding objects by type is more effective than using FindObjectOfType, but this is being called once total
    _enemyManager = FindFirstObjectByType<EnemyManager>();
    if (!_enemyManager)
    {
      Debug.LogError("EnemyManager not found");
      this.enabled = false;
    }
  }

  // Update is called once per frame
  void Update()
  {
    transform.position += new Vector3(
      PlayerInputManager.Instance.Movement.x,
      PlayerInputManager.Instance.Movement.y,
      0) * Time.deltaTime * _moveSpeed;
  }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if (_enemyManager)
    {
      if (collision.CompareTag("Enemy"))
      {
        _enemyManager.EnemyKilled(collision.gameObject);
      }
    }
    else
    {
      Destroy(collision.gameObject);
    }
  }
}
