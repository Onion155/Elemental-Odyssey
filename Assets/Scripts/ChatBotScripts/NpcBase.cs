using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class NpcBase : MonoBehaviour
{
    [Header ("Referances")]
    public GameObject ChatBoxOBJ;
    public LocalChatbotOllama AiScript;

    [Header ("CharacterName")]
    public string Name = "";

    [Header ("Charactacter attributes")]
    [TextArea(3, 10)] // Minimum of 3 lines and maximum of 10 lines
    public string Context = "";
    
    private void ActivateChatBot()
    {
        // if this is active the player should not be able to move
        ChatBoxOBJ.SetActive(true); // activate the ai

        AiScript.SetContext(Context); // give context 
        AiScript.SetName(Name);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ActivateChatBot();
        }
    }
}
