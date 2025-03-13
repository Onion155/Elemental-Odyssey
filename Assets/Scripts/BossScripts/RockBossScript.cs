using System.Collections;
using UnityEngine;
public class RockBossScript : MonoBehaviour
{
    public Rigidbody2D head;
    public Rigidbody2D leftHand;
    public Rigidbody2D rightHand;
    public float moveSpeed = 5f;
    public float stopDistance = 0.5f;

    private Transform player;
    private Rigidbody2D[] bodyParts;
    private Vector3[] originalPositions;
    private int currentPartIndex = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bodyParts = new Rigidbody2D[] { head, leftHand, rightHand };
        originalPositions = new Vector3[bodyParts.Length];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            originalPositions[i] = bodyParts[i].position;
        }

        StartCoroutine(MoveBodyParts());
    }

    IEnumerator MoveBodyParts()
    {
        while (true)
        {
            Rigidbody2D currentPart = bodyParts[currentPartIndex];
            Vector3 targetPosition = player.position;
            Vector3 originalPosition = originalPositions[currentPartIndex];

            // Move current part toward the target
            while (Vector3.Distance(currentPart.position, targetPosition) > stopDistance)
            {
                currentPart.position = Vector3.MoveTowards(currentPart.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null; // Wait for next frame
            }

            // Wait before returning to original position
            yield return new WaitForSeconds(1f);

            // Move back to original position
            while (Vector3.Distance(currentPart.position, originalPosition) > stopDistance)
            {
                currentPart.position = Vector3.MoveTowards(currentPart.position, originalPosition, moveSpeed * Time.deltaTime);
                yield return null; // Wait for next frame
            }

            // Wait before moving the next part
            yield return new WaitForSeconds(1f);

            // Move to the next body part in the cycle
            currentPartIndex = (currentPartIndex + 1) % bodyParts.Length;
        }
    }
}
