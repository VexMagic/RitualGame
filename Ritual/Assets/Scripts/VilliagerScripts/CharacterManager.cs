using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public List<Villager> characterList = new List<Villager>();
    void Start()
    {
        Villager[] villgager = FindObjectsOfType<Villager>();


        characterList.AddRange(villgager);
    }


}
