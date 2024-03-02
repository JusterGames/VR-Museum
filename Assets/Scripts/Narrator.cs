using UnityEngine;
using System.Collections;

public class Narrator : MonoBehaviour
{
    private Animator anim;
    private AudioSource aud;
    private bool canTrigger = true;
    public float playerRange = 5f; // Adjust this range as needed
    public Transform player; // Assign the player's transform in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canTrigger && IsPlayerNearby())
        {
            StartCoroutine(TriggerNarrator());
        }
    }

    bool IsPlayerNearby()
    {
        if (player == null)
        {
            Debug.LogWarning("Player transform not assigned to Narrator script.");
            return false;
        }

        // Check the distance between the narrator and the player
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= playerRange;
    }

    IEnumerator TriggerNarrator()
    {
        canTrigger = false; // Prevent triggering again for a while

        // Play the animation if Animator component is not null
        if (anim != null)
        {
            anim.SetTrigger("StartAnim"); // Use "StartAnim" instead of "Play"
        }

        // Play the audio if AudioSource component is not null
        if (aud != null)
        {
            aud.Play();
        }

        // Wait until the animation and audio have finished playing
        yield return new WaitForSeconds(aud.clip.length); // Wait for the duration of the audio clip

        // Wait for an additional 10 seconds
        yield return new WaitForSeconds(20f);

        canTrigger = true; // Allow triggering again
    }
}
