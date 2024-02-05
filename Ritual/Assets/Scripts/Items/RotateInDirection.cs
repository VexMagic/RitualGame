using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class RotateInDirection : MonoBehaviour
{

    public float CurrentAngle { get; private set; }
    [Header("Event")]
    [SerializeField] private Vector2EventSO OnDirectionChange;

    private void OnEnable()
    {
        OnDirectionChange.Action += Rotate;
    }

    private void OnDisable()
    {
        OnDirectionChange.Action -= Rotate;
    }

    private void Rotate(Vector2 input)
    {
        //ResetRotation();
        float angle;
        if (input.x == 1)
        {
            angle = Mathf.Acos(input.x);
            CurrentAngle = angle;
            //transform.Rotate(new Vector3(0, 0, 0));
        transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (input.x == -1)
        {
            angle = Mathf.Acos(input.x);
            CurrentAngle = angle;
            //transform.Rotate(new Vector3(0, 0, -180));
        transform.eulerAngles = new Vector3(0, 0,-180);
        }
        else if (input.y == 1)
        {
            angle = Mathf.Asin(input.y);
            CurrentAngle = angle;
            //transform.Rotate(new Vector3(0, 0, 90));
        transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (input.y == -1)
        {
            angle = Mathf.Asin(input.y);
            CurrentAngle = angle;
            //transform.Rotate(new Vector3(0, 0, -90));
        transform.eulerAngles = new Vector3(0, 0, -90);
        }


    }

    private void ResetRotation()
    {
        float currentRot = transform.rotation.z;
        transform.eulerAngles = new Vector3(0, 0, 0);
        transform.Rotate(new Vector3(0, 0, 360 - currentRot));
    }

}
