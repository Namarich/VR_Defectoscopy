using UnityEngine;

public class DefectHighlighter : MonoBehaviour
{
    private Renderer surfaceRenderer;

    void Start()
    {
        surfaceRenderer = GetComponent<Renderer>();
    }

    public void HighlightDefect()
    {
        // Изменение цвета материала для подсветки дефектов
        surfaceRenderer.material.color = Color.red;  // Красный цвет для визуализации дефектов
    }

    public void ResetHighlight()
    {
        // Сброс цвета материала до нормального состояния
        surfaceRenderer.material.color = Color.white;
    }
}
