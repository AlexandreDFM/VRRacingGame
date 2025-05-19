using System.Collections;
using UnityEngine;

public class StartingLightScript : MonoBehaviour {
    public GameObject RLightOff;
    public GameObject RLightOn;
    public GameObject ALightOff;
    public GameObject ALightOn;
    public GameObject GLightOff;
    public GameObject GLightOn;
    public AudioSource Sound1;
    public AudioSource Sound2;
    public GameObject Go;

    private void Start() {
        Go.SetActive(false);
        StartCoroutine(StartingLight());
    }

    private IEnumerator StartingLight() {
        yield return new WaitForSeconds(1f);
        RLightOff.SetActive(false);
        RLightOn.SetActive(true);
        Sound1.Play();
        yield return new WaitForSeconds(1f);
        RLightOn.SetActive(false);
        RLightOff.SetActive(true);
        Sound1.Play();
        ALightOff.SetActive(false);
        ALightOn.SetActive(true);
        yield return new WaitForSeconds(1f);
        ALightOn.SetActive(false);
        ALightOff.SetActive(true);
        Sound2.Play();
        GLightOff.SetActive(false);
        GLightOn.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        SaveScript.RaceStart = true;
        Go.SetActive(true);
        GLightOn.SetActive(false);
        GLightOff.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GLightOn.SetActive(true);
        GLightOff.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GLightOn.SetActive(false);
        GLightOff.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        GLightOn.SetActive(true);
        GLightOff.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        GLightOn.SetActive(false);
        GLightOff.SetActive(true);
        Go.SetActive(false);
    }
}