using UnityEngine;

public class OllamaTest : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(OllamaService.Instance.Query(
            "What is a binary tree? Answer in one sentence.",
            (response) => {
                Debug.Log("Ollama response: " + response);
            }
        ));
    }
}