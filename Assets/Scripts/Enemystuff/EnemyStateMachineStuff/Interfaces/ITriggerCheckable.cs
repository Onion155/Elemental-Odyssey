using UnityEngine;

public interface ITriggerCheckable 
{
   bool IsAggroed { get; set; }
   bool isWithinAttackingDistance {  get; set; }

    void SetAggroedStatus(bool IsAggroed);
    void SetWithinAttackingDistance(bool isWithinAttackingDistance);
}
