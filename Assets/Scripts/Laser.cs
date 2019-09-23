using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 0.8f;
    private Vector3 direction;
    void Start()
    {
        direction = new Vector3(0,_speed,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y >= 7f) {
            Object.Destroy(this.gameObject);
        }
        transform.position += direction;
    }
}
