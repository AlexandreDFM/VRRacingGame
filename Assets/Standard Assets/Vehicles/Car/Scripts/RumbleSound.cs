using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleSound : MonoBehaviour
{
    private AudioSource Player;
    void Start()
    {
        Player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SaveScript.Rumble1 || SaveScript.Rumble2) {
            Player.Play();
        } else { 
            Player.Stop();
        }
    }
}
