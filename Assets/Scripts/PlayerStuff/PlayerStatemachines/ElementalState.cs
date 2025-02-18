using UnityEngine;

// this is simular to the enemy state
public class ElementalState
{
    protected Elemental element;
    protected ElementalStateMachine ElementstateMachine;

    public ElementalState(Elemental element, ElementalStateMachine elementstateMachine)
    {
        this.element = element;
        ElementstateMachine = elementstateMachine;
    }

    public virtual void EnterState() { } // Use as awake 
    public virtual void ExitState() { } // does this when it exits the state
    public virtual void FrameUpdate() { } // Use as Update
}

