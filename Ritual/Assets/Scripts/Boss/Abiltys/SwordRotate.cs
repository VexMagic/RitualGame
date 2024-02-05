using UnityEngine;

public class SwordRotate : MonoBehaviour
{
    public Transform target; // Referens till det objekt som ska snurras runt
    public float rotationSpeed = 50f;

    void Update()
    {
        // Hämta användarens önskade input (t.ex. Input.GetAxis("Horizontal"))
        float horizontalInput = Input.GetAxis("Horizontal");

        // Räkna ut rotationsvinkeln baserat på input och hastighet
        float rotationAngle = horizontalInput * rotationSpeed * Time.deltaTime;

        // Utför rotationen runt det angivna målet
        transform.RotateAround(target.position, Vector3.forward, rotationAngle);
    }
}