using System.Collections;
using System.Text;
using UnityEngine;

public class AudioPlayback : MonoBehaviour
{
    public GameObject zombiePrefab;

    public AudioClip[] incoming;   // 7 audio clips
    public AudioClip[] zombie;     // 3 audio clips
    public AudioClip[] mallgerms;  // 2 audio clips

    AudioSource audioSource;

    float timer1;   // Break timer
    float timer2;   // Horde timer
    float timer3;   // spawn interval

    bool hordeActive = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartTimer1(); // Start break timer at start of game
    }

    void Update()
    {
        if (!hordeActive)
        {
            timer1 -= Time.deltaTime; // deltaTime is important because
            if (timer1 <= 0f) // Check if timer 1 is done
                StartTimer2(); // Start timer 2 when timer 1 ends
        }
        else
        {
            timer2 -= Time.deltaTime; // It's used to track frame time
            timer3 -= Time.deltaTime; // So it's consistent across framerates

            if (timer3 <= 0f)
            {
                Instantiate(zombiePrefab, Vector3.zero, Quaternion.identity);
                timer3 = Random.Range(0.5f, 2f); // Restart timer 3 when timer 3 ends
            }

            if (timer2 <= 0f)
                StartTimer1(); // Start timer 1 when timer 2 ends
        }
    }

    void StartTimer1() // 
    {
        hordeActive = false;
        timer1 = Random.Range(5f, 10f);
        audioSource.PlayOneShot(mallgerms[Random.Range(0, mallgerms.Length)]); // Play random mallgerms sound when break starts
    }

    void StartTimer2()
    {
        hordeActive = true;
        timer2 = Random.Range(10f, 20f); // 10 to 20 seconds
        timer3 = Random.Range(0.1f, 2f); // 0.1 to 2 seconds
        // Originally it was 0.5 seconds but I like a challenge

        audioSource.PlayOneShot(incoming[Random.Range(0, incoming.Length)]); // Play Rochelle incoming when timer2 starts
        audioSource.PlayOneShot(zombie[Random.Range(0, zombie.Length)]); // Start playing zombie sounds when timer3 starts
    }
}