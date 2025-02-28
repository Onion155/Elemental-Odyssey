using UnityEngine;

public class NpcBase : MonoBehaviour
{
    public LocalChatbotOllama AiScript;
    public bool deleteText = false;

    // Update is called once per frame
    void Update()
    {
        if (deleteText)
        {
            deleteText = false;
        }
    }
}
