using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    float _z;
    [SerializeField]
    Transform _player;
    // Start is called before the first frame update
    void Start()
    {
        _z = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, _z);
    }
}
