using UnityEngine;

public class ElementalStateMachine 
{
   public ElementalState CurrentElement { get; set; }

    public void Initialize(ElementalState startingElement)
    {
        CurrentElement = startingElement;
        CurrentElement.EnterState();
    }

    public void ChangeState(ElementalState newElement)
    {
        CurrentElement.ExitState();
        CurrentElement = newElement;
        CurrentElement.EnterState();
    }
}
