using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Collections;

public class DefectoscopyProcess : MonoBehaviour
{
    public TMP_Text feedbackText;          // Текст для уведомлений

    public int minutes=0;
    public int hours=15;
    public TMP_Text clockText;

    public List<Pipe> pipes;

    public Transform learningSpawnPoint;
    public Transform trainingSpawnPoint;

    public GameObject player;
    void Start()
    {
        feedbackText.text = "Начнем с подготовки поверхности. Возьмите баллончик с пенетрантом(красный балончик).";
        StartCoroutine(ChangeTime());
    }

    public IEnumerator ChangeTime()
    {
        while (true)
        {
            minutes += 2;
            if (minutes == 60)
            {
                minutes = 0;
                hours++;
            }

            if (hours > 24)
            {
                hours = 0;
            }
            clockText.text = $"{hours:D2}:{minutes:D2}";
            yield return new WaitForSeconds(1.5f);
        }      
    }

    public void SetTheFeedbackText(string text)
    {
        feedbackText.text = text;
    }

    public void Learning()
    {
        player.transform.position = learningSpawnPoint.position;
    }

    public void Training()
    {
        player.transform.position = trainingSpawnPoint.position;
    }
}
