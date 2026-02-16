using UnityEngine;
using System.Collections;

public class AudioPlayback : MonoBehaviour
{
    public GameObject zombiePrefab;

    public AudioClip[] incoming; // For Horde begins, size 7
    public AudioClip[] zombie; // For Zombie spawns, size 3
    public AudioClip[] mallgerms; // For Break begins, size 2

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Timer1()); // Start break timer at start of game
    }

    IEnumerator Timer1() // Break period
    {
        audioSource.PlayOneShot(mallgerms[Random.Range(0, mallgerms.Length)]); // Play zombie sound
        yield return new WaitForSeconds(Random.Range(5f, 10f)); // Randomly pick between 5 and 10 seconds
        StartCoroutine(Timer2()); // Start Horde Rush
    }

    IEnumerator Timer2() // Horde rush
    {
        audioSource.PlayOneShot(incoming[Random.Range(0, incoming.Length)]); // Play incoming sound

        float duration = Random.Range(10f, 20f); // Randomly pick between 10 and 20 seconds
        float end = Time.time + duration;

        StartCoroutine(Timer3(duration)); // Start Zombie spawn

        yield return new WaitForSeconds(duration);
        StartCoroutine(Timer1()); // Start Break period
    }

    IEnumerator Timer3(float duration) // Zombie spawn
    {
        float end = Time.time + duration;

        while (Time.time < end) // Stop if time's up
        {
            Instantiate(zombiePrefab, Vector3.zero, Quaternion.identity); // Spawn the zombie
            yield return new WaitForSeconds(Random.Range(0.1f, 2f)); // on a random time interval between 0.1 and 2 seconds
            // Originally it was 0.5 - 2 seconds but like. That's way too easy
            audioSource.PlayOneShot(zombie[Random.Range(0, zombie.Length)]); // Play zombie sound every spawn
        }
    }
}
