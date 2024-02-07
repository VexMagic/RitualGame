using UnityEngine;

public class TimerBoss : MonoBehaviour
{
    [SerializeField] float countdownTime = 10f;
    [SerializeField] GameObject objectToActivate;

    private bool timerActive = false;

    private void Start()
    {
        StartTimer();
    }

    private void StartTimer()
    {
        timerActive = true;
        Invoke("ActivateObject", countdownTime);
    }

    private void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }
}