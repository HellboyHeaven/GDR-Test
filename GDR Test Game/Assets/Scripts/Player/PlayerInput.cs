using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 TouchPosition { get; private set; }

    private Camera _camera;
    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            TouchPosition = CalculateTouchPos();
            InputEventManager.OnTouched();
        }
       
    }

    private Vector2 CalculateTouchPos ()
    {
        Touch touch = Input.GetTouch(0);
        return _camera.ScreenToWorldPoint(touch.position);
    }
}
