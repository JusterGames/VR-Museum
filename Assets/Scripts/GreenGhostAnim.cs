using UnityEngine;

public class GreenGhostAnim : MonoBehaviour
{
    public string playerTag = "Player"; // Tag of the player GameObject
    public float activationRange = 5f; // The range at which the animation should be triggered
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        animator = GetComponent<Animator>();

        // Check if the playerTag is not set
        if (string.IsNullOrEmpty(playerTag))
        {
            Debug.LogError("Player tag is not set in the inspector!");
        }
    }

    void Update()
    {
        GameObject player = GameObject.FindWithTag(playerTag);

        // Check if a GameObject with the specified tag is found
        if (player != null)
        {
            // Check if the player is within the activation range
            if (Vector3.Distance(transform.position, player.transform.position) < activationRange)
            {
                // Play the animation
                animator.SetBool("GreenGhost", true);
            }
            else
            {
                // Stop the animation
                animator.SetBool("GreenGhost", false);
            }
        }
        else
        {
            Debug.LogWarning("Player GameObject with tag '" + playerTag + "' not found in the scene.");
        }
    }
}
