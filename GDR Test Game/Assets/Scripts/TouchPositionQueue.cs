using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class TouchPositionQueue : MonoBehaviour, IResetable
{
    private Queue<Vector2> _queue = new Queue<Vector2>();
    private PlayerInput _input;

    public bool IsEmpty => (_queue.Count == 0 ? true : false);

    public void Reset() => _queue.Clear();
    public List<Vector2> GetList() => _queue.ToList();
    public Vector2 Peek() => _queue.Peek();
    



    private void Start()
    {
        _input = GetComponent<PlayerInput>();
        InputEventManager.Touched += Add;
        PlayerEventManager.TargetReached += Remove;

    }

    private void OnDestroy()
    {
        InputEventManager.Touched -= Add;
        PlayerEventManager.TargetReached -= Remove;
        
    }

    private void Add() => _queue.Enqueue(_input.TouchPosition);
    private void Remove() => _queue.Dequeue();
   


}
