using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public string playerTag = "Player"; // The tag assigned to the player GameObject
    public float activationRange = 5f; // The range at which the animation should be triggered
    private Animator animator; // Reference to the Animator component

    void Start()
    {
        animator = GetComponent<Animator>();

        // Check if the player tag is not set
        if (string.IsNullOrEmpty(playerTag))
        {
            Debug.LogError("Player tag is not set in the inspector!");
        }
    }

    void Update()
    {
        // Find all GameObjects with the specified tag
        GameObject[] players = GameObject.FindGameObjectsWithTag(playerTag);

        // Check if there is at least one player with the specified tag
        if (players.Length > 0)
        {
            // Get the closest player
            Transform closestPlayer = GetClosestPlayer(players);

            // Check if the closest player is within the activation range
            if (Vector3.Distance(transform.position, closestPlayer.position) < activationRange)
            {
                // Play the animation
                animator.SetBool("GhostChase", true);
            }
            else
            {
                // Stop the animation
                animator.SetBool("GhostChase", false);
            }
        }
        else
        {
            // No player found with the specified tag
            Debug.LogWarning("No player found with the specified tag: " + playerTag);
        }
    }

    Transform GetClosestPlayer(GameObject[] players)
    {
        Transform closestPlayer = null;
        float closestDistance = float.MaxValue;

        // Iterate through all players to find the closest one
        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = player.transform;
            }
        }

        return closestPlayer;
    }
}
