using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float transitionTime = 2.5f;

    public void TargetNewPosition (Vector2 newPos) {
        StartCoroutine (Transition (newPos));
    }

    IEnumerator Transition (Vector2 newPos) {
        Vector3 startPos = transform.position;
        Vector3 targetPos;
        for (float i = 0; i < transitionTime; i += Time.deltaTime) {
            targetPos = Vector3.Slerp (startPos, newPos, i / transitionTime);
            targetPos.z = -10;
            transform.position = targetPos;
            yield return null;
        }
    }
}
