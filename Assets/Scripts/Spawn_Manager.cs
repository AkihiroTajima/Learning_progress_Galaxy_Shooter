using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    private float _bottom = -4f;
    private float _top = 6f;
    private float _right = 9f;
    private float _left = -9f;
    [SerializeField]
    private GameObject _enemyContainer;

    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine() {
        while(!_stopSpawning) {
             GameObject newEnemy = Instantiate(_enemyPrefab, new Vector3(Random.Range(_left,_right),_top,0), Quaternion.identity);
             newEnemy.transform.parent = _enemyContainer.transform;
             yield return new WaitForSeconds(5); 
        }
    }

    public void OnPlayerDead() {
        _stopSpawning = true;
    }
}
