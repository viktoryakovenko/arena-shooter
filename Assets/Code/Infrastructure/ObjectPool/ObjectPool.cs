/*using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ObjectPool<TMono> where TMono : MonoBehaviour
{
    public bool AutoExpand { get; set; }
    public Transform Contrainer;
    public TMono Prefab => _prefab;

    private List<TMono> _pool;
    private TMono _prefab;

    public ObjectPool(TMono prefab, int count)
    {
        _prefab = prefab;
        Contrainer = null;

        CreatePool(count);
    }

    public ObjectPool(TMono prefab, int count, Transform contrainer)
    {
        Contrainer = contrainer;
        _prefab = prefab;

        CreatePool(count);
    }

    public bool HasFreeElement(out TMono freeElement)
    {
        foreach (var mono in _pool)
        {
            if (mono.gameObject.activeInHierarchy)
            {
                freeElement = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        freeElement = null;
        return false;
    }

    public TMono GetFreeElement()
    {
        if (HasFreeElement(out TMono freeElement))
            return freeElement;

        if (AutoExpand)
            return CreateObject(true);

        throw new Exception($"There is no free elements in pool of type {typeof(TMono)}");
    }

    private void CreatePool(int count)
    {
        _pool = new List<TMono>();

        for (int i = 0; i < count; i++)
        {
            CreateObject(); 
        }
    }

    private TMono CreateObject(bool isActiveByDefault = false)
    {
        TMono createdObject = Object.Instantiate(_prefab, Contrainer);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }
}
*/