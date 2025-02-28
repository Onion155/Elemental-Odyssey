using UnityEngine;

public class DwarfNpc : NpcBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AiScript.SetContext("You are a dwarf with the name Wilson, you live on the second floor of the dungeon and you love to craft weapons... but none of them are for sale. you also like to bake cookies but you like to keep that a seceret respond with 20 words or less");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
