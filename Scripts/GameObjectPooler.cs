using UnityEngine;
using System.Collections.Generic;

public class GameObjectPooler : MonoBehaviour
{
    public static GameObjectPooler instance;

    private List<GameObject> pool;
    [SerializeField] private GameObject objectPool;
    [SerializeField] private int initialPoolSize;
    [SerializeField] private bool shouldExpand = true;

    private void Awake()
    {
        if (instance != null)
            Destroy(this);
        else
            instance = this;
    }

    private void Start()
    {
        //Este es el evento para resetear la pool, no creo que deba esta aquí.
        PinHead.dieEvent += ResetPool;

        pool = new List<GameObject>();
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject poolObject = Instantiate(objectPool, transform);
            poolObject.SetActive(false);
            pool.Add(poolObject);
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            if(!pool[i].activeInHierarchy)
                return pool[i];
        }
        
        if(shouldExpand)
        {
            GameObject adicionalObject = Instantiate(objectPool, transform);
            adicionalObject.SetActive(false);
            pool.Add(adicionalObject);
            return adicionalObject;
        }
        return null;
    }

    //No me convence del todo que esta funcion este aquí, ya que este objeto solo se debe encargar de generar esos objetos de la pool no de resetearla segun un evento en concreto.
    private void ResetPool()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (pool[i].activeInHierarchy)
            {
                pool[i].transform.SetParent(transform);
                pool[i].SetActive(false);
            }
        }
    }
}
