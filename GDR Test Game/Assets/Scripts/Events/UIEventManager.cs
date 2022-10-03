using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventManager : MonoBehaviour
{

    public static event Action RestartClicked;
    public static void OnRestartClicked() => RestartClicked?.Invoke();
}
