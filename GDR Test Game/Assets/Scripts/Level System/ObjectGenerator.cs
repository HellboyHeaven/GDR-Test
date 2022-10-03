using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ObjectGenerator : MonoBehaviour, IResetable
{
    [SerializeField] private List<PoolMono<MonoBehaviour>> _pools;
    [SerializeField] private bool _autoExpand;

    //private List<PoolMono<MonoBehaviour>> _pools = new List<PoolMono<MonoBehaviour>>();
    private List<Vector2> _takenPlaceList = new List<Vector2>();
    private StageBound _stageBound;

    


    public void Reset()
    {
        foreach (var pool in _pools)
        {
            pool.PopAllElements();
            CreateObjects(pool);
        }

        _takenPlaceList.Clear();
        _takenPlaceList.Add(Vector2.zero);
    }

    private void Start()
    {
        
        _stageBound = GetBound();
        _takenPlaceList.Add(Vector2.zero);
        CreatePool();
        Reset();

    }
    private void CreatePool()
    {
        foreach (var pool in _pools)
        {
            pool.Create(GetContainer($"{pool.Prefab.name} Pool"));
        }
    }

    private void CreateObjects(PoolMono<MonoBehaviour> pool)
    {

        for (int i = 0; i < pool.Count; i++)
        {
            CreateObject(pool);

        }
    }
    private void CreateObject(PoolMono<MonoBehaviour> pool)
    { 
        if (TryGetFreePlace(out Vector2 position))
        {
            _takenPlaceList.Add(position);

            var element = pool.GetFreeElement();
            element.transform.position = position;
        }
       

    }

    

    private Transform GetContainer(String name)
    {
        GameObject container = new GameObject();
        container.transform.parent = transform;
        container.name = name;
        return container.transform;
    }

    private bool TryGetFreePlace(out Vector2 position)
    {
        position = new Vector2();
        while (_takenPlaceList.Count < _stageBound.Size)
        {
            int rX = (int)UnityEngine.Random.Range(_stageBound.minX, _stageBound.maxX);
            int rY = (int)UnityEngine.Random.Range(_stageBound.minY, _stageBound.maxY);
            position = new Vector2(rX, rY);
            if (!_takenPlaceList.Contains(position))
                return true;
         
        }
        return false;

        
    }

    private StageBound GetBound ()
    {
        Vector2 stage = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        int x = (int)stage.x;
        int y = (int)stage.y;
        return new StageBound(-x-1, -y, x, y-1);
    }
 
        

    private struct StageBound
    {
        public int maxX;
        public int maxY;
        public int minX;
        public int minY;
        public StageBound(int maxX, int maxY, int minX, int minY)
        {
            this.maxX = maxX; this.maxY = maxY; this.minX = minX; this.minY = minY; 
        }
        public int Size => (maxX - minX) * (maxY - minY);
    }

}
        
    


