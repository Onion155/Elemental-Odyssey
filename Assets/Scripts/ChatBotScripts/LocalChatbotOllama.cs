using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LocalChatbotOllama : MonoBehaviour
{
    public TMP_InputField userInputField;  // TextMeshPro InputField for user input
    public TMP_Text responseText;         // TextMeshPro Text for assistant's response

    public ScrollRect scrollRect;

    private LocalAIClientOllama localAIClient;
    [ SerializeField ] [TextArea(15,20)]
    private string context = ""; // how it should behave
    private string AIName = "";
    private string PlayerName = $"<color=#FED8B1>{ "Player" }</color>";
    private List<string> conversationHistory = new List<string>();
    private int maxHistorySize = 3; // Limit to the last 10 exchanges for performance

    void Start()
    {
        // Get reference to the LocalAIClient component
        localAIClient = GetComponent<LocalAIClientOllama>();
        // Initial assistant message to set the tone
        responseText.text = "Chatbot Ready! Type a message."; // change for whateverr NPC will be talking
        AddHistory(AIName + ": " + context);
    }


    public async void OnSendButtonClicked()
    {
        // Retrieve and validate user input
        string userInput = userInputField.text.Trim();
        if (string.IsNullOrWhiteSpace(userInput))
        {
            //responseText.text = "Please enter a valid message.";
            return;
        }

        // Add the user’s input to the conversation history and display it immediately
       AddHistory($"{PlayerName}: {userInput}");
        responseText.text = string.Join("\n", conversationHistory);

        // Scroll to the bottom to show the user's message
        if (scrollRect != null)
        {
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
        }

        // Clear the input field for the next message
        userInputField.text = string.Empty;

        // Construct the full context with initial instruction and recent conversation history
        string currentContext = context + "\n\n" + string.Join("\n", conversationHistory) + "\nAssistant:";

        // Send the context (conversation history) to the AI model and await the assistant's response
        string assistantResponse = await localAIClient.SendMessage(currentContext);

        // Add the assistant’s response to the conversation history
        AddHistory($"{AIName}: {assistantResponse.Trim()}");

        // Update the responseText field to show the entire conversation history including the new response
        responseText.text = string.Join("\n", conversationHistory);

        // Scroll to the bottom again to show the latest response
        if (scrollRect != null)
        {
            Canvas.ForceUpdateCanvases();
            scrollRect.verticalNormalizedPosition = 0f;
        }

        // Set focus back to the input field
        userInputField.ActivateInputField();
    }

    public void SetContext(string Context)
    {
        context = Context;
    }
    public void SetName(string Name)
    {
        AIName = $"<color=#Add8e6>{Name}</color>"; // this changes the colour only for this string, light blue
    }

    public void ClearHistory()// clears the list for the chat history ( this is used in the npc base)
    {
        conversationHistory.Clear();
    }

    private void AddHistory(string Context) // this will keep a limit on the conversation history
    {
        if (conversationHistory.Count > maxHistorySize)
        {
            conversationHistory.RemoveAt(0);
        }
        conversationHistory.Add(Context);
    }


}
