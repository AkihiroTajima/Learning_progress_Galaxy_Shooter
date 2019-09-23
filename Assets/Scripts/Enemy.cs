using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 4f;
    private float _bottom = -4f;
    private float _top = 6f;
    private float _right = 9f;
    private float _left = -9f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(_left,_right),_top,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, -_speed, 0)*Time.deltaTime);

        if (transform.position.y <= _bottom) {
            float _x = Random.Range(_left,_right);
            transform.position = new Vector3(_x, _top, 0);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Hit: " + other.transform.name);
        
        if (other.tag == "Player") {
            Destroy(this.gameObject);
            PLayer p = other.transform.GetComponent<PLayer>();
            if (p != null) {
                p.Damage();
            }
        }
        if (other.tag == "Laser") {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
    
}
