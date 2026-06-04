using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class OllamaService : MonoBehaviour
{
    public static OllamaService Instance;

    [SerializeField] private string endpoint = "http://localhost:11434/api/generate";
    [SerializeField] private string model = "phi3";
    [SerializeField] private float timeout = 15f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Query(string prompt, System.Action<string> callback)
    {
        string jsonBody = "{\"model\":\"" + model + "\",\"prompt\":\"" + prompt + "\",\"stream\":false}";

        UnityWebRequest request = new UnityWebRequest(endpoint, "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonBody);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = (int)timeout;

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            callback(response);
        }
        else
        {
            callback("Error: " + request.error);
        }
    }
}