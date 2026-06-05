using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SLMPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TextMeshProUGUI responseText;
    [SerializeField] private Button submitButton;

    private string systemPrompt = "You are a Discrete Mathematics tutor in a VR learning environment. Only answer questions about Logic, Set Theory, Graph Theory. Keep answers under 120 words. Current module: Hub.";

    public void OnSubmit()
    {
        Debug.Log("OnSubmit called");

        string userQuery = "What is a binary tree?";

        responseText.text = "Thinking...";
        submitButton.interactable = false;

        string fullPrompt = systemPrompt + "\nStudent: " + userQuery;

        StartCoroutine(OllamaService.Instance.Query(fullPrompt, (response) =>
        {
            Debug.Log("Response received: " + response);
            responseText.text = ParseResponse(response);
            submitButton.interactable = true;
        }));
    }

    private string ParseResponse(string json)
    {
        int responseIndex = json.IndexOf("\"response\":\"");
        if (responseIndex == -1) return "Error parsing response.";
        int start = responseIndex + 12;
        int end = json.IndexOf("\"", start);
        if (end == -1) return "Error parsing response.";
        return json.Substring(start, end - start);
    }
}