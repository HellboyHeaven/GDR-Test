using System;
using UnityEngine;

public class InputEventManager : MonoBehaviour
{
    public static event Action Touched;
    public static void OnTouched() => Touched?.Invoke();

}
