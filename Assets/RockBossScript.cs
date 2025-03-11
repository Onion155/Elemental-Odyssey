using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.XR;

public class RockBossScript : MonoBehaviour
{
 
    private Rigidbody2D Head, LeftHand, RightHand;
    private Transform PlayerTransform;
    private CharacterStatBase PlayerStats;
    private Vector3 targetPos, Direction;
    private bool attackinprogress;
    private int witchattack;


    void Start()
    {
        Head = transform.GetChild(0).GetComponent<Rigidbody2D>();
        LeftHand = transform.GetChild(1).GetComponent<Rigidbody2D>();
        RightHand = transform.GetChild(2).GetComponent<Rigidbody2D>();

        PlayerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PlayerStats = PlayerTransform.GetComponent<CharacterStatBase>();
    }

    // Update is called once per frame
    void Update()
    {
        if (attackinprogress)
        {
            // funnel to correct function
            if (witchattack == 0)
            {
                HeadAttack();
            }
            else if (witchattack == 1)
            {
                LeftArmAttack();
            }
            else if (witchattack == 2)
            {
                RightArmAttack();
            }
        }
        else
        {
            // pick one to funnel into 
            witchattack = Random.Range(0, 2);
            attackinprogress = true;
            getTarget();
        }
       
    }

    private void HeadAttack()// called when the head needs to attack
    {
        Direction = (targetPos - Head.transform.position).normalized;
        Head.velocity = new Vector2(Direction.x * 4,Direction.y *4);
        if (Head.transform.position == targetPos)
        {
            attackinprogress = false;
        }
    }
    private void LeftArmAttack()// called when the left arm needs to attack 
    {
        Direction = (targetPos - LeftHand.transform.position).normalized;
        LeftHand.velocity = new Vector2(Direction.x * 4, Direction.y * 4);
        if (LeftHand.transform.position == targetPos)
        {
            attackinprogress = false;
        }
    }
    private void RightArmAttack()// called when the right arm needs to attack 
    {
        Direction = (targetPos - RightHand.transform.position).normalized;
        RightHand.velocity = new Vector2(Direction.x * 4, Direction.y * 4);
        if (RightHand.transform.position == targetPos)
        {
            attackinprogress = false;
        }
    }
    private void getTarget()
    {
        targetPos = PlayerTransform.position;
        Debug.Log(targetPos);
    }

   
}
