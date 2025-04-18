using UnityEngine;

public abstract class State : MonoBehaviour
{
    protected Rigidbody2D body;
    protected EnemyBase ebase;
    public bool isComplete { get; protected set; } // anything can look at this but only inherited classes can set it

    protected float startTime;

    
    public float time => Time.time - startTime;
    public virtual void Enter() { }
    public virtual void StateUpdate() { }
    public virtual void StateFixedUpdate() { }
    public virtual void Exit() { }

    public void SetUp(Rigidbody2D rigidbody2d, EnemyBase _Enemybase)
    {
        body = rigidbody2d;
        ebase = _Enemybase;
    }
    
}
