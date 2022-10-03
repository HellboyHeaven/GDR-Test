using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(LineRenderer))]
public class PathLineDrawer : MonoBehaviour, IResetable
{
    [SerializeField] private float _width;
    [SerializeField] private Transform _player;
    [SerializeField] private TouchPositionQueue _touchPositions;
    private LineRenderer _lineRenderer;

    public void Reset()
    {
        _lineRenderer.positionCount = 0;
    }

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        PlayerEventManager.Moved += Draw;
    }
    private void OnDestroy()
    {
        PlayerEventManager.Moved -= Draw;
    }

    private void Draw()
    {
        List<Vector3> positions = _touchPositions.GetList().Select((e) => (Vector3)e).ToList();
        positions.Insert(0, _player.position);

        _lineRenderer.positionCount = positions.Count;
        _lineRenderer.SetPositions(positions.ToArray());
    }
}
