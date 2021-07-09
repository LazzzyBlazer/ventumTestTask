using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    Dictionary<int, Queue<GameObject>> poolDictionary = new Dictionary<int, Queue<GameObject>>();

static Pool _instance;
public static Pool instance{
    get{
        if (_instance == null){
            _instance = FindObjectOfType<Pool> ();
        }
        return _instance;
    }
}

    public void CreatePool(GameObject prefab, int pollSize){
        int poolKey = prefab.GetInstanceID ();

        if(!poolDictionary.ContainsKey (poolKey)){
            poolDictionary.Add (poolKey, new Queue<GameObject> ());

            for(int i = 0; i < pollSize; i++){
                GameObject newObject = Instantiate (prefab) as GameObject;
                newObject.SetActive (false);
                poolDictionary [poolKey].Enqueue (newObject);
            }
        }

    }
    public void ReuseObject(GameObject prefab, Vector3 position, Quaternion rotation) {
        int poolKey = prefab.GetInstanceID();

        if(poolDictionary.ContainsKey (poolKey)){
            GameObject objectToReuse = poolDictionary [poolKey].Dequeue ();
            poolDictionary [poolKey].Enqueue (objectToReuse);

            objectToReuse.SetActive (true);
            objectToReuse.transform.position = position;
            objectToReuse.transform.rotation = rotation;
        }
    }
}
