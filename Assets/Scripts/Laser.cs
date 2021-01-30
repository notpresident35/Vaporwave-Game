using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float Width = 0.33f;
    public bool Active = false;

    LineRenderer line;
    BoxCollider2D col;
    Vector3 startPos;
    Vector3 endPos;
    float offsetAngle;

    private void Awake () {
        line = GetComponent<LineRenderer> ();
        col = GetComponentInChildren<BoxCollider2D> ();
    }

    /*private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.GetComponent<HealthBarScript> ()) {
            collision.GetComponent<HealthBarScript> ().hurtMe (1);
        }
    }
    */
    void Update () {

        col.enabled = Active;
        if (!Active) {
            line.SetPosition (0, transform.position);
            line.SetPosition (1, transform.position);
            return;
        }

        // Finds the angle from startPos to endPos
        startPos = transform.position;
        offsetAngle = Mathf.Atan2 (endPos.y - startPos.y, endPos.x - startPos.x);

        // Set lineRenderer positions
        line.SetPosition (0, startPos);
        line.SetPosition (1, endPos);

        // Rotate and scale the collider
        transform.rotation = Quaternion.Euler (0, 0, offsetAngle * Mathf.Rad2Deg);
        col.size = new Vector2 ((startPos - endPos).magnitude, Width);
        col.transform.localPosition = new Vector3 ((startPos - endPos).magnitude / 2, 0, 0);
    }

    public void SetTargetPosition (Vector3 position) {
        endPos = position;
    }
}
