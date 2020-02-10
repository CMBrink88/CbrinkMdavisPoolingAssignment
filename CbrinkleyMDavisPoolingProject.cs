//Christopher Brinkley and Morgan Davis
//MMC215 Pooling Assignment
//2/14/20
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CbrinkleyMDavisPoolingProject : MonoBehaviour
{
    
    public Dictionary<string, Queue<GameObject>> poolDictionary; //Dictionary to hold the tag and pool of game objects
    
    [System.Serializable] //Marks it inside of the system
    public class Pool{
        public string tag; //Tag of the pool
        public GameObject prefab; //Game ojbects of the pool
        public int size; //size of the pool AKA Limit on how many objects outside fo pool beore creating new ones
    }

    #region Singleton
    public static ObjectPooler Instance;

    private void Awake(){
        Instance = this; //Starts up the pooling project when the "game" starts
    }
    #endregion

    public List<pool> pools;

    void Start(){

        poolDictionary = new Dictionary<string, Queue<GameObject>>(); //Creates a new dictionary at the start of the game

        foreach (Pool pool in pools){ //loops through each othe pools
            Queue<GameObject> objectPool = new Queue<GameObject>(); //creates a Queue of game Objects

            for (int i = 0; i < pool size; i++){ //Creates a new game object as long as it is under the pool size
                GameObject obj = Instantiate(pool.prefab);//MAkes a clone of the object and references it via the GameObject obj
                obj.SetActive(false);//Disables so we cannot see it yet
                objectPool.Enqueue(obj);//Adds it to the end of our Queue
            }

            poolDictionary.Add(pool.tag, objectPool);//Adds the object to the pool
        }
    }

    public GameObject SpawnFromPool (string tag, Vector3 position, Quaternion rotation){ //Creates the object and puts it in queue
        
        if (!poolDictionary.ContainsKey(tag)){
            Debug.LogWarning("Yo! This tag- " + tag + " doesnt exist, maybe check on that!:)")
            return null; //If the tag is not available, it will send this message
        }

        Gameobject objectToSpawn = poolDictionary[tag].Dequeue //Pulls the first object in the queue and sets it to objectToSpawn

        objectToSpawn.SetActive(true);//spawns object
        objectToSpawn.transform.position = position; //sets the position of the spawned object
        objectToSpawn.transform.rotation = rotation; //sets the rotation of the spawned object

        poolDictionary[tag].Enqueue(objectToSpawn); //Adds the object back into the pool

        return objectToSpawn;
    }

}