using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    [SerializeField]
    private float _speed = 8.5f;
    private Vector3 cpos;
    const float max_x = 9f;
    const float min_x = -9f;
    const float max_y = 6f;
    const float min_y = -4f;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _live = 3;
    private Spawn_Manager _spawn_Manager;
    // Start is called before the first frame update
    void Start()
    {
        cpos = new Vector3(0, 0, 0);
        transform.position = cpos;
        _spawn_Manager = GameObject.Find("Spawn_Manager").GetComponent<Spawn_Manager>();

        if (_spawn_Manager == null) {
            Debug.Log("the Spawn manager is NULL");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ClaculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire) {
            fire();
        }
    }
    void ClaculateMovement() {
        // get input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // update position
        transform.Translate(new Vector3(h, v, 0) * Time.deltaTime * _speed);
        // chack position in range
        float _x = Mathf.Max(min_x,transform.position.x);
        _x = Mathf.Min(max_x,_x);
        float _y = Mathf.Max(min_y,transform.position.y);
        _y = Mathf.Min(max_y,_y);
        cpos.x = _x;
        cpos.y = _y;
        transform.position = cpos;

        //transform.position = new Vector3(Mathf.Clamp(transform.position.x,min_x,max_x),Mathf.Clamp(transform.position.y,min_y,max_y),0);
    }

    void fire() {
        _canFire = Time.time + _fireRate;
        // Debug.Log("Space Key Pressed");
        Instantiate(_laserPrefab, transform.position+ new Vector3(0, 0.8f, 0), Quaternion.identity);
    }

    public void Damage(){
        this._live--;
        if (this._live < 1) {
            _spawn_Manager.OnPlayerDead();
            Destroy(this.gameObject);
        }
    }
}
