using UnityEngine;

public class SwordRotate : MonoBehaviour
{
    public Transform target; // Referens till det objekt som ska snurras runt
    public float rotationSpeed = 50f;

    void Update()
    {
        // H�mta anv�ndarens �nskade input (t.ex. Input.GetAxis("Horizontal"))
        float horizontalInput = Input.GetAxis("Horizontal");

        // R�kna ut rotationsvinkeln baserat p� input och hastighet
        float rotationAngle = horizontalInput * rotationSpeed * Time.deltaTime;

        // Utf�r rotationen runt det angivna m�let
        transform.RotateAround(target.position, Vector3.forward, rotationAngle);
    }
}