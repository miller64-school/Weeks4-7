using Unity.VisualScripting;
using UnityEngine;

public class PlayOnStart : MonoBehaviour
{
    void Button()
    {
        GetComponent<AudioSource>().Play();
    }
}

