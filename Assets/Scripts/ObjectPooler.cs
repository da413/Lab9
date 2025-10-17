using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // Assign these in the Inspector
    [System.Serializable]
    public class Pool
    {
        public string tag; // Each object should have its own unique tag assigned to its prefab
        public GameObject prefab; // Object prefab to spawn & despawn with object pool
        public int poolSize; // Max number of the object that can exist at a one time
    }

    public static ObjectPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<Pool> poolsList; // List to manage multiple pools for multiple object types
    private Dictionary<string, Queue<GameObject>> poolDictionary; 
    private Dictionary<GameObject, string> objectToTag;

    // Adds objects to a pool and prepares for spawning later.
    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        objectToTag = new Dictionary<GameObject, string>();

        foreach (Pool pool in poolsList)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject gameObject = Instantiate(pool.prefab);
                gameObject.SetActive(false);

                objectPool.Enqueue(gameObject);
                objectToTag[gameObject] = pool.tag;
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    
    // Call this instead of Instantiating a new object whenever something spawns. This will pull from the existing object pools to optimize memory usage.
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (poolDictionary[tag].Count == 0)
        {
            return null;
        }

        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist!");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    // Call this instead of Destroying object. Returns the object to the pool and "despawns" it until it respawns later
    public void ReturnToPool(GameObject gameObject)
    {
        if (!objectToTag.ContainsKey(gameObject))
        {
            Debug.LogWarning("Trying to return object not managed by pooler: " + gameObject.name);
            return;
        }

        gameObject.SetActive(false);

        string tag = objectToTag[gameObject];
        poolDictionary[tag].Enqueue(gameObject);
    }
}
