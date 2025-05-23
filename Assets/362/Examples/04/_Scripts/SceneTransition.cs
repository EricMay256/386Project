using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
  [SerializeField]
  string sceneName;
  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      SceneManager.LoadScene(sceneName);
    }
  }
  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      SceneManager.LoadScene(sceneName);
    }
  }
  void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Player"))
    {
      SceneManager.LoadScene(sceneName);
    }
  }
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Player"))
    {
      SceneManager.LoadScene(sceneName);
    }
  }
  public void TriggerTransition()
  {
    SceneManager.LoadScene(sceneName);
  }
}
