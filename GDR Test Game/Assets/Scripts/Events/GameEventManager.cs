using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    public static event Action CoinCollected;
    public static void OnCoinCollected() => CoinCollected?.Invoke();

    public static event Action PlayerDied;
    public static void OnPlayerDied() => PlayerDied?.Invoke();

    public static event Action Won;
    public static void OnWon() => Won?.Invoke();

    public static event Action Restarted;
    public static void OnRestarted() => Restarted?.Invoke();
}
