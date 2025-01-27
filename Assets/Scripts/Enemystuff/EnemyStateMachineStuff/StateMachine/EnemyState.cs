using UnityEngine;

// video to this link - https://www.youtube.com/watch?v=RQd44qSaqww
public class EnemyState
{

    // ### THIS IS THE BASE STATE FOR ALL THE ENEMY STATES ALL ENEMY STATES SHOULD INHERIT FROM THIS ###//

    // protected is private to any external scripts unless a script inherits from this script
    protected Enemy enemy; // all children will have acces to the enemy class 
    protected EnemyStateMachine enemyStateMachine;

    public EnemyState(Enemy enemy, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
    }

    public virtual void EnterState() { } // Use as awake 
    public virtual void ExitState() { } // does this when it exits the state
    public virtual void FrameUpdate() { } // Use as Update
    public virtual void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType) { } // use this to set animations in the state
}
