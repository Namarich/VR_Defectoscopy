using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabInteractable : XRGrabInteractable
{
    // Этот метод вызывается, когда объект взят
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        // Здесь можно добавить дополнительные действия при взятии объекта
        Debug.Log("Объект взят: " + gameObject.name);
    }

    // Этот метод вызывается, когда объект отпущен
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);

        // Проверяем, не было ли взаимодействие отменено
        if (!args.isCanceled)
        {
            // Действия при отпускании объекта
            Debug.Log("Объект отпущен: " + gameObject.name);
        }
    }
}
