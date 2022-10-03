using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/MovementData")]
public class MovementData : ScriptableObject
{
    [SerializeField] private float _speed;
    public float Speed => (_speed >= 0 ? _speed : 0);
}
