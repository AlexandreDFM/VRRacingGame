using System.Collections;
using TMPro;
using UnityEngine;

public class UITimeTrial : MonoBehaviour {
    public TMP_Text TimeTrialMinutesG;
    public TMP_Text TimeTrialSecondsG;
    public TMP_Text TimeTrialMinutesS;
    public TMP_Text TimeTrialSecondsS;
    public TMP_Text TimeTrialMinutesB;
    public TMP_Text TimeTrialSecondsB;

    public TMP_Text WinMessage;
    public GameObject TimeTrialObject;
    public GameObject TimeTrialResults;
    public GameObject GoldStar;
    public GameObject SilverStar;
    public GameObject BronzeStar;
    private bool Winner = false;

    private void Start() {
        TimeTrialObject.SetActive(true);
        TimeTrialResults.SetActive(false);
    }

    private void Update() {
        ScoreTimeDraw(SaveScript.TimeTrialMinG, SaveScript.TimeTrialSecondsG, TimeTrialMinutesG, TimeTrialSecondsG);
        ScoreTimeDraw(SaveScript.TimeTrialMinS, SaveScript.TimeTrialSecondsS, TimeTrialMinutesS, TimeTrialSecondsS);
        ScoreTimeDraw(SaveScript.TimeTrialMinB, SaveScript.TimeTrialSecondsB, TimeTrialMinutesB, TimeTrialSecondsB);

        if (SaveScript.RaceOver)
            if (!Winner) {
                Winner = true;
                StartCoroutine(WinnDisplay());
            }
    }

    private void ScoreTimeDraw(float min, float sec, TMP_Text MinText, TMP_Text SecText) {
        if (min <= 9)
            MinText.text = "0" + Mathf.Round(min) + ":";
        else if (min >= 10) MinText.text = Mathf.Round(min) + ":";

        if (sec <= 9)
            SecText.text = "0" + Mathf.Round(sec);
        else if (sec >= 10) SecText.text = Mathf.Round(sec).ToString();
    }

    private IEnumerator WinnDisplay() {
        yield return new WaitForSeconds(0.15f);
        TimeTrialResults.SetActive(true);
        if (SaveScript.Gold) {
            GoldStar.SetActive(true);
            WinMessage.text = "YOU WON GOLD";
        }
        else if (SaveScript.Silver) {
            SilverStar.SetActive(true);
            WinMessage.text = "YOU WON SILVER";
        }
        else if (SaveScript.Bronze) {
            BronzeStar.SetActive(true);
            WinMessage.text = "YOU WON BRONZE";
        }
        else if (SaveScript.Fail) {
            WinMessage.text = "TRY AGAIN";
        }
    }
}