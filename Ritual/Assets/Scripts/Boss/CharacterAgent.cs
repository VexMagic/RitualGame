using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAgent : MonoBehaviour
{
    float movmentSpeed = 6f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void MoveTo(Vector2 destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination, movmentSpeed * Time.deltaTime);
    }
}
