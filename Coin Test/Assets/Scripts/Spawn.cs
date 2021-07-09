using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start(){
        Pool.instance.CreatePool (prefab, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space)) {
            Pool.instance.ReuseObject(prefab, Vector3.up*5, Quaternion.identity);
        }
    }

    public void spawnNewCoin(){
        Pool.instance.ReuseObject(prefab, Vector3.up*5, Quaternion.identity);
    }
}
