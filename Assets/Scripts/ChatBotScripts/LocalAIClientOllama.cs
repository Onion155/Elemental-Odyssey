using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;

public class LocalAIClientOllama : MonoBehaviour
{
    public string baseUrl = "http://localhost:11434"; // Default port for Ollama

    // Function to send a message to the Ollama model
    public async Task<string> SendMessage(string context)
    {
        var requestData = new
        {
            model = "llama3.2", // Replace with your Ollama model name
            prompt = context
        };

        string jsonData = JsonConvert.SerializeObject(requestData);
        Debug.Log($"JSON Payload: {jsonData}");

        UnityWebRequest request = new UnityWebRequest($"{baseUrl}/api/generate", "POST");
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.timeout = 30;

        var asyncOp = request.SendWebRequest();

        while (!asyncOp.isDone)
        {
            await Task.Yield();
        }

        if (request.result == UnityWebRequest.Result.Success)
        {
            try
            {
                // Get the raw response
                string rawResponse = request.downloadHandler.text;
                Debug.Log($"Raw JSON Response: {rawResponse}");

                // Split the streamed JSON responses by lines
                string[] jsonResponses = rawResponse.Split('\n');
                StringBuilder fullResponse = new StringBuilder();

                foreach (string json in jsonResponses)
                {
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        // Deserialize each JSON object separately
                        ResponseData responseData = JsonConvert.DeserializeObject<ResponseData>(json);
                        if (responseData != null && responseData.response != null)
                        {
                            fullResponse.Append(responseData.response); // Accumulate the response parts
                        }
                    }
                }

                return fullResponse.ToString().Trim(); // Return the full accumulated response
            }
            catch (JsonException e)
            {
                Debug.LogError($"JSON Parsing Error: {e.Message}\nRaw JSON: {request.downloadHandler.text}");
                return "There was an error processing the response. Please try again.";
            }
        }
        else
        {
            Debug.LogError($"Request failed. Status: {request.responseCode}, Error: {request.error}");
            return "An error occurred while processing your request. Please try again.";
        }
    }

    // Class to map the JSON response structure
    [System.Serializable]
    private class ResponseData
    {
        public string response; // Adjusted to match the actual response key from Ollama
    }
}

