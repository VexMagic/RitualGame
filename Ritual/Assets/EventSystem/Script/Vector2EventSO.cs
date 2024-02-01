using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Event/Vector2Event")]
public class Vector2EventSO : ScriptableObject
{
    [SerializeField, TextArea(1, 5)]
    string description;

    public event Action<Vector2> Action;

    public void Invoke(Vector2 vec) => Action?.Invoke(vec);
}
