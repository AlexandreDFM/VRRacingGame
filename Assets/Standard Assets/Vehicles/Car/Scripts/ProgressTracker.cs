using System.Collections;
using UnityEngine;

public class ProgressTracker : MonoBehaviour {
    public int CurrentWP;
    public int ThisWPNumber;
    public int LastWPNumber;
    private bool isPlaying;
    private AudioSource m_Audio;

    private void Start() {
        m_Audio = GetComponent<AudioSource>();
    }

    private void Update() {
        if (CurrentWP > ThisWPNumber) StartCoroutine(Checkdirection());
        if (LastWPNumber > ThisWPNumber) SaveScript.WrongWay = false;
        if (LastWPNumber < ThisWPNumber) SaveScript.WrongWay = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Barrier") && !isPlaying) {
            m_Audio.Play();
            isPlaying = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Barrier")) {
            m_Audio.Stop();
            isPlaying = false;
        }
    }

    private IEnumerator Checkdirection() {
        yield return new WaitForSeconds(0.5f);
        ThisWPNumber = LastWPNumber;
    }
}