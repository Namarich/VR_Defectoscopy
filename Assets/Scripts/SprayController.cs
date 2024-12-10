//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.XR.Interaction.Toolkit;

//public class SprayController : MonoBehaviour
//{
//    public Animator animator;  // Ссылка на компонент Animator
//    public InputActionProperty sprayAction;  // Ссылка на Input Action для распыления

//    private bool isSpraying = false;

//    void Update()
//    {
//        // Проверка нажатия кнопки через Input Action
//        if (sprayAction.action.ReadValue<float>() > 0.1f && !isSpraying)
//        {
//            StartSpray();
//        }
//        else if (sprayAction.action.ReadValue<float>() <= 0.1f && isSpraying)
//        {
//            StopSpray();
//        }
//    }

//    // Запуск анимации распыления
//    void StartSpray()
//    {
//        animator.SetTrigger("SprayTrigger");
//        isSpraying = true;
//    }

//    // Остановка анимации распыления
//    void StopSpray()
//    {
//        isSpraying = false;
//    }
//}

using HTC.UnityPlugin.Vive;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SprayController : MonoBehaviour
{
    //public Animator animator;  // Ссылка на компонент Animator
    public ParticleSystem sprayParticles;  // Ссылка на компонент Particle System
    public InputActionProperty sprayAction;  // Ссылка на Input Action для распыления

    public bool isSpraying = false;


    void Start()
    {
        // Убедитесь, что анимация и частицы не запущены при старте
        //animator.ResetTrigger("SprayTrigger");
        if (sprayParticles.isPlaying)
        {
            sprayParticles.Stop();  // Останавливаем систему частиц, если она работает
        }
        isSpraying = false;

        Debug.Log("Начальное состояние: анимация и частицы не должны быть активными");
    }

    void Update()
    {
        
    }

    public void Spray()
    {
            Debug.Log("Кнопка нажата: начинаем распыление");
            StartSpray();
            isSpraying = true;
    }

    public void DontSpray()
    {
        Debug.Log("Кнопка отпущена: останавливаем распыление");
        StopSpray();
        isSpraying = false;
    }

    public void SetRotation()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
    }

    // Запуск анимации распыления и системы частиц
    void StartSpray()
    {
        //animator.SetTrigger("SprayTrigger");  // Запускаем анимацию
        sprayParticles.Play();  // Запускаем систему частиц
        Debug.Log("Анимация и частицы запущены");
    }

    // Остановка анимации распыления и системы частиц
    void StopSpray()
    {
        sprayParticles.Stop();  // Останавливаем систему частиц
        Debug.Log("Анимация и частицы остановлены");
    }
}
