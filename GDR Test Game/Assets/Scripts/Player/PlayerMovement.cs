using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private MovementData _data;
    [SerializeField] private TouchPositionQueue _touchPositions;

    private Vector2 target;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        
        
        if (_touchPositions.IsEmpty) return;
        transform.position = Vector2.MoveTowards(transform.position, target, _data.Speed * Time.deltaTime);
        target = _touchPositions.Peek();
        if (Vector2.Distance((Vector2)transform.position, target) <= 0.01) PlayerEventManager.OnTargetReached();

        PlayerEventManager.OnMoved();
        
    }
}
