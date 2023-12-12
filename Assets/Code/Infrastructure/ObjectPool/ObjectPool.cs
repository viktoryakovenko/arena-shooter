using Code.Infrastructure.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    public bool AutoExpand { get; set; } = false;

    private List<GameObject> _pool;
    private IFactory _factory;

    public ObjectPool(IFactory factory, int count)
    {
        _factory = factory;

        CreatePool(count);
    }

    public GameObject GetFreeElement()
    {
        if (HasFreeElement(out GameObject freeElement))
            return freeElement;

        if (AutoExpand)
            return CreateObject(true);

        throw new Exception($"There is no free elements in pool of type {typeof(GameObject)}");
    }

    public bool HasFreeElement(out GameObject freeElement)
    {
        foreach (var poolElement in _pool)
        {
            if (!poolElement.gameObject.activeInHierarchy)
            {
                freeElement = poolElement;
                poolElement.gameObject.SetActive(true);
                return true;
            }
        }

        freeElement = null;
        return false;
    }

    private void CreatePool(int count)
    {
        _pool = new List<GameObject>();

        for (int i = 0; i < count; i++)
        {
            CreateObject(); 
        }
    }

    private GameObject CreateObject(bool isActiveByDefault = false)
    {
        GameObject createdObject = _factory.Create();
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }
}