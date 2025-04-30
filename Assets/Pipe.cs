using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pipe : MonoBehaviour
{
    public bool isTraining;

    private bool isPenetrantApplied = false;
    private bool isDeveloperApplied = false;

    public int numberOfDamages;
    public float damageRadius = 1.0f;
    public GameObject damageObject;

    public List<GameObject> tablets = new List<GameObject>();
    private int tablet = 0;

    private int defects;
    private int defectsFound;

    private bool isFinding = false;
    private bool hasSpawnde = false;

    public DefectoscopyProcess manager;

    [System.Serializable]
    public struct TimeManager
    {
        public int start;
        public int end;
        public int startingMinutes;
        public int startingHours;
    }

    public TimeManager penetrantTime;

    public TimeManager showerTime;
    

    // Start is called before the first frame update
    void Start()
    {
        numberOfDamages = Random.Range(1, 5);
        defects = numberOfDamages;
    }

    public void ApplyPenetrant()
    {
        if (!isPenetrantApplied)
        {
            isPenetrantApplied = true;
            ChangeTablet(1);
            Invoke("ProceedToDeveloperStep", 5f);
            penetrantTime.startingMinutes = manager.minutes;
            penetrantTime.startingHours = manager.hours;
            // Ожидание 5 секунд перед следующим шагом

        }
    }
    public void SpawnDamages()
    {
        for (int i = 0; i < numberOfDamages; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfDamages + Random.Range(1, 90);
            Vector3 spawnPosition = new Vector3(Mathf.Cos(angle) * damageRadius, 0, Mathf.Sin(angle) * damageRadius);
            GameObject a = Instantiate(damageObject, tablets[tablet].transform.position + spawnPosition, Quaternion.identity);
            a.transform.SetParent(tablets[2].transform);
        }
    }


    private void ChangeTablet(int n)
    {
        tablet = n;
        for (int i = 0; i < tablets.Count; i++)
        {
            tablets[i].gameObject.SetActive(false);
        }
        tablets[tablet].gameObject.SetActive(true);
        tablets[tablet].transform.position = tablets[tablet - 1].transform.position;
        tablets[tablet].transform.rotation = tablets[tablet - 1].transform.rotation;
    }

    public int GetTimeInMinutes(int hours,int minutes)
    {
        return hours * 60 + minutes;
    }

    public int GetCurrentTimeInMinutes()
    {
        return manager.hours * 60 + manager.minutes;
    }


    public void ApplyDeveloper()
    {
        if (isPenetrantApplied && !isDeveloperApplied && GetTimeInMinutes(penetrantTime.startingHours, penetrantTime.startingMinutes) + penetrantTime.end >= GetCurrentTimeInMinutes() && GetCurrentTimeInMinutes() >= GetTimeInMinutes(penetrantTime.startingHours,penetrantTime.startingMinutes)+penetrantTime.start)
        {
            //feedbackText.text = "Очиститель нанесен. Теперь нанесите проявитель(синий балончик) для проверки.";
            SendTheFeedbackTextToManager("Очиститель нанесен. Теперь нанесите проявитель(синий балончик) для проверки.");
            isDeveloperApplied = true;
        }
        else if (GetTimeInMinutes(penetrantTime.startingHours, penetrantTime.startingMinutes) + penetrantTime.end >= GetCurrentTimeInMinutes() || GetCurrentTimeInMinutes() >= GetTimeInMinutes(penetrantTime.startingHours, penetrantTime.startingMinutes) + penetrantTime.start)
        {
            YouHaveFailed();
        }
    }

    public void SendTheFeedbackTextToManager(string text)
    {
        if (isTraining)
        {
            manager.SetTheFeedbackText(text);
        }
    }


    public void FindDefect()
    {
        defectsFound += 1;
        if (defectsFound == defects)
        {
            Debug.Log("You found em all");
        }
    }

    public void UseUVLamp()
    {
        if (isDeveloperApplied)
        {
            //feedbackText.text = "Проявитель нанесён. Проверка дефектов...";
            SendTheFeedbackTextToManager("Проявитель нанесён. Проверка дефектов...");
            ChangeTablet(2);
            HighlightDefects();
            isFinding = true;
            //feedbackText.text = feedbackText.text + "\n" + "Ты нашел " + defectsFound.ToString() + "/" + defects.ToString() + " дефектов";
            SendTheFeedbackTextToManager("Ты нашел " + defectsFound.ToString() + "/" + defects.ToString() + " дефектов");

        }
        else
        {
            //feedbackText.text = "Сначала нанесите пенетрант и очиститель.";
        }
    }


    private void HighlightDefects()
    {
        // Подсветка дефектов (например, изменение цвета области с дефектами)
        //defectArea.GetComponent<Renderer>().material.color = Color.red;  // Подсветка дефекта
        if (!hasSpawnde)
        {
            //feedbackText.text = "Дефекты обнаружены!";
            SpawnDamages();
            hasSpawnde = true;
            Debug.Log("spawn");
        }


    }

    void ProceedToDeveloperStep()
    {
        //feedbackText.text = "Теперь нанесите очиститель(желтый балончик).";
    }

    public void YouHaveFailed()
    {
        SceneManager.LoadScene("Demo");
    }

}
