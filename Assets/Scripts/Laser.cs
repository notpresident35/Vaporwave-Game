using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public Vector2 Size = new Vector2 (25, 0.33f);

    LineRenderer line;
    Vector3 startPos;
    Vector3 endPos;
    float offsetAngle;

    private void Awake () {
        line = GetComponent<LineRenderer> ();
        GetComponentInChildren<BoxCollider2D> ().size = new Vector2 (Size.x, Size.y);
    }

    void Update() {
        startPos = transform.position;
        offsetAngle = Mathf.Atan2 (endPos.y - startPos.y, endPos.x - startPos.x);

        // Line renderer
        line.SetPosition (0, startPos);
        line.SetPosition (1, endPos);

        // Box collider
        transform.rotation = Quaternion.Euler (0, 0, offsetAngle * Mathf.Rad2Deg);
    }

    public void SetTargetPosition (Vector3 position) {
        endPos = position.normalized * Size.x;
    }
}
