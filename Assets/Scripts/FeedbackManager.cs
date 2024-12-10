using UnityEngine;
using UnityEngine.UI;

public class FeedbackManager : MonoBehaviour
{
    public Text feedbackText;

    public void ShowMessage(string message)
    {
        feedbackText.text = message;
    }
}
