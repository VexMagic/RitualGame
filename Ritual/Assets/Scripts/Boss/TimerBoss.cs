using UnityEngine;

public class TimerBoss : MonoBehaviour
{
    [SerializeField] float countdownTime = 10f;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject healthbar;
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
        healthbar.SetActive(true);
        boss.SetActive(true);
    }
}