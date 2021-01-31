using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class WinGame : MonoBehaviour {

    public static bool GameOver = false;

    [SerializeField] VideoPlayer videoPlayer;
    public RectTransform videoDisplayer;
    public RectTransform walkman;
    public GameObject winText;
    public Transform cam;
    public Image FadeToBlack;

    private void OnTriggerEnter2D (Collider2D collision) {
        if (GameOver) { return; }
        GameOver = true;
        StartCoroutine (GameWinCutscene ());
    }

    IEnumerator GameWinCutscene () {
        for (float i = 0; i < 1; i += Time.deltaTime / 1.5f) {
            FadeToBlack.color = new Color (0, 0, 0, i);
            yield return null;
        }

        videoPlayer.Play ();
        videoPlayer.GetComponent<AudioSource> ().Play ();
        cam.position = new Vector3 (0, 0, -10);

        for (float i = 0; i < 1; i += Time.deltaTime / 1.5f) {
            videoDisplayer.anchoredPosition = -Vector3.up * (1 - i) * Screen.height;
            yield return null;
        }

        for (float i = 0; i < 1; i += Time.deltaTime / 0.75f) {
            walkman.anchoredPosition = Vector3.up * (1 - i) * Screen.height + Vector3.up * 300f;
            yield return null;
        }

        winText.SetActive (true);
    }
}
