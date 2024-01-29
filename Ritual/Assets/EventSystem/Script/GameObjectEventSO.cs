using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/GameObjectEvent")]
public class GameObjectEventSO : ScriptableObject
{
    [SerializeField, TextArea(1, 5)]
    string description;

    public event Action<GameObject> Action;

    public void Invoke(GameObject go) => Action?.Invoke(go);
}
