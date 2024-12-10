using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DefectoscopyProcess : MonoBehaviour
{
    public GameObject penetrantSpray;  // Баллончик с пенетрантом
    public GameObject uvLamp;          // УФ-лампа
    public GameObject developerSpray;  // Баллончик с проявителем
    //public GameObject defectArea;      // Область, где будут обнаружены дефекты
    public TMP_Text feedbackText;          // Текст для уведомлений

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

    void Start()
    {
        feedbackText.text = "Начнем с подготовки поверхности. Возьмите баллончик с пенетрантом(красный балончик).";
        numberOfDamages = Random.Range(1, 5);
        defects = numberOfDamages;
    }

    public void ApplyPenetrant()
    {
        if (!isPenetrantApplied)
        {
            feedbackText.text = "Пенетрант нанесен! Подождите несколько минут перед следующими действиями.";
            isPenetrantApplied = true;
            ChangeTablet(1);
            Invoke("ProceedToDeveloperStep", 5f);
            // Ожидание 5 секунд перед следующим шагом

        }
    }

    public void SpawnDamages()
    {
        for(int i = 0; i < numberOfDamages; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfDamages + Random.Range(1,90);
            Vector3 spawnPosition = new Vector3(Mathf.Cos(angle) * damageRadius, 0, Mathf.Sin(angle) * damageRadius);
            GameObject a = Instantiate(damageObject, tablets[tablet].transform.position + spawnPosition, Quaternion.identity);
            a.transform.SetParent(tablets[2].transform);
        }
    }

    private void ChangeTablet(int n)
    {
        tablet = n;
        for(int i = 0; i < tablets.Count; i++)
        {
            tablets[i].gameObject.SetActive(false);
        }
        tablets[tablet].gameObject.SetActive(true);
        tablets[tablet].transform.position = tablets[tablet - 1].transform.position;
        tablets[tablet].transform.rotation = tablets[tablet - 1].transform.rotation;
    }

    public void ApplyDeveloper()
    {
        if (isPenetrantApplied && !isDeveloperApplied)
        {
            feedbackText.text = "Очиститель нанесен. Теперь нанесите проявитель(синий балончик) для проверки.";
            isDeveloperApplied = true;
            
        }
    }

    public void FindDefect()
    {
        defectsFound += 1;
        if(defectsFound == defects)
        {
            Debug.Log("You found em all");
        }
    }

    public void UseUVLamp()
    {
        if (isDeveloperApplied)
        {
            feedbackText.text = "Проявитель нанесён. Проверка дефектов...";
            ChangeTablet(2);
            HighlightDefects();
            isFinding = true;
            feedbackText.text = feedbackText.text + "\n" + "Ты нашел " + defectsFound.ToString() + "/" + defects.ToString() + " дефектов";

        }
        else
        {
            feedbackText.text = "Сначала нанесите пенетрант и очиститель.";
        }
    }

    private void Update()
    {
        if (isFinding)
        {
            feedbackText.text = "Дефекты обнаружены!" + "\n" + "Ты нашел " + defectsFound.ToString() + "/" + defects.ToString() + " дефектов";
        }

        if (defectsFound == defects)
        {
            feedbackText.text = "Поздравляю ты нашел их все!!!";
        }
    }

    private void HighlightDefects()
    {
        // Подсветка дефектов (например, изменение цвета области с дефектами)
        //defectArea.GetComponent<Renderer>().material.color = Color.red;  // Подсветка дефекта
        if (!hasSpawnde)
        {
            feedbackText.text = "Дефекты обнаружены!";
            SpawnDamages();
            hasSpawnde = true;
            Debug.Log("spawn");
        }
       
        
    }

    void ProceedToDeveloperStep()
    {
        feedbackText.text = "Теперь нанесите очиститель(желтый балончик).";
    }
}
