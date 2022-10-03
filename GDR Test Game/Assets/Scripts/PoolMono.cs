using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class PoolMono<T> where T : MonoBehaviour
{
    [SerializeField] private T _prefab;
    [SerializeField] private int _count;
    //[SerializeField] private int _count;

    private Queue<T> _pool ;
    public T Prefab => _prefab;
    public Transform Container { get; private set; }
    public bool AutoExpand { private get; set; }

    public int Count => _pool.Count;
    
    public PoolMono(T prefab, int count)
    {
        
        _prefab = prefab;
        Create(count);
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        _prefab = prefab;
        Container = container;
        Create(count);
    }


    public PoolMono (T prefab, int count, Transform container, bool autoExpand) : this(prefab, count, container)
    {
        AutoExpand = autoExpand;
    }
    public void Create(Transform cointaner)
    {
        Container = cointaner;
        Create(_count);
    }


    public void PopAllElements()
    {
        if (_pool == null) return;

        foreach (T element in _pool)
        {
            element.gameObject.SetActive(false);
        }
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out T element))
            return element;
        if (AutoExpand)
            return CreateObject(true);

        throw new System.Exception($"There is no free elemnts in pool of type {typeof(T)}");
    }

    private void Create(int count)
    {
        _count = count;
        _pool = new Queue<T>();
        for (int i = 0; i < _count; i++)
        {
            CreateObject();
        }
        
    }

    private T CreateObject(bool isActuveByDefault = false)
    {
        var createdObject = Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActuveByDefault);
        _pool.Enqueue(createdObject);
        return createdObject;
    }

    private bool HasFreeElement(out T element)
    {
        foreach(T mono in _pool)
        {
            if(!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                mono.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    
}
