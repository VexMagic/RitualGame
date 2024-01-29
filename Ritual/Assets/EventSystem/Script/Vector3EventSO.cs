using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/Vector3Event")]
public class Vector3EventSO : ScriptableObject
{
    [SerializeField, TextArea(1, 5)]
    string description;

    public event Action<Vector3> Action;

    public void Invoke(Vector3 go) => Action?.Invoke(go);
}
