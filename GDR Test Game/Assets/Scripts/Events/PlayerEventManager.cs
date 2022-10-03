using System;
using UnityEngine;

public class PlayerEventManager : MonoBehaviour
{
    public static event Action TargetReached;
    public static void OnTargetReached() { TargetReached?.Invoke(); }

    public static event Action Moved;
    public static void OnMoved() { Moved?.Invoke(); }
}
