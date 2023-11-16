using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static List<PooledObjectInfo> ObjectPools = new List<PooledObjectInfo>();

    private GameObject objectPoolEmptyHolder;

    private static GameObject bulletsEmpty;
    private static GameObject enemiesEmpty;
    private static GameObject sheepEmpty;
    private static GameObject particleSystemEmpty;


    public enum PoolType
    {
        Bullets,
        Enemies,
        Sheep,
        ParticleSystem,
        None
    }
    public static PoolType PoolingType;

    private void Awake()
    {
        SetupEmpties();
    }

    private void SetupEmpties()
    {
        objectPoolEmptyHolder = new GameObject("Pooled Objects");

        bulletsEmpty = new GameObject("Bullets");
        bulletsEmpty.transform.SetParent(objectPoolEmptyHolder.transform);

        enemiesEmpty = new GameObject("Enemies");
        enemiesEmpty.transform.SetParent(objectPoolEmptyHolder.transform);

        sheepEmpty = new GameObject("Sheep");
        sheepEmpty.transform.SetParent(objectPoolEmptyHolder.transform);

        particleSystemEmpty = new GameObject("Particle System");
        particleSystemEmpty.transform.SetParent(objectPoolEmptyHolder.transform);
    }

    public static GameObject SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition, Quaternion spawnRotation, PoolType poolType = PoolType.None)
    {
        PooledObjectInfo pool = null;
        foreach (PooledObjectInfo p in ObjectPools)
        {
            if (p.LookupString == objectToSpawn.name)
            {
                pool = p;
                break;
            }
        }

        //If the pool does not exist, it will be created.
        if (pool == null)
        {
            pool = new PooledObjectInfo() { LookupString = objectToSpawn.name };
            ObjectPools.Add(pool);
        }

        //Checks for inactive objects in pool.
        GameObject spawnableObj = null;
        foreach (GameObject obj in pool.InactiveObjects)
        {
            if (obj != null)
            {
                spawnableObj = obj;
                break;
            }
        }

        if (spawnableObj == null)
        {
            //Finds the parent of the empty object.
            GameObject parentObject = SetParentObject(poolType);

            //If there is no inactive objects, it will create a new one.
            spawnableObj = Instantiate(objectToSpawn, spawnPosition, spawnRotation);

            if (parentObject != null)
            {
                spawnableObj.transform.SetParent(parentObject.transform);
            }
        }

        else
        {
            //If there is an inactive object, it is activated.
            spawnableObj.transform.position = spawnPosition;
            spawnableObj.transform.rotation = spawnRotation;
            pool.InactiveObjects.Remove(spawnableObj);
            spawnableObj.SetActive(true);
        }

        return spawnableObj;
    }

    public static void ReturnObjectToPool(GameObject obj)
    {
        //Removes "(Clone)" from the name of the passed object.
        string goName = obj.name.Substring(0, obj.name.Length - 7);

        PooledObjectInfo pool = ObjectPools.Find(p => p.LookupString == goName);

        if (pool == null)
        {
            Debug.LogWarning("Trying to release an object that is not pooled: " + obj.name);
        }

        else
        {
            obj.SetActive(false);
            pool.InactiveObjects.Add(obj);
        }
    }

    private static GameObject SetParentObject(PoolType poolType)
    {
        switch (poolType)
        {
            case PoolType.Bullets:
                return bulletsEmpty;

            case PoolType.Enemies:
                return enemiesEmpty;

            case PoolType.Sheep:
                return sheepEmpty;

            case PoolType.ParticleSystem:
                return particleSystemEmpty;

            case PoolType.None:
                return null;

            default:
                return null;
        }
    }
}

public class PooledObjectInfo
{
    public string LookupString;
    public List<GameObject> InactiveObjects = new List<GameObject>();
}
