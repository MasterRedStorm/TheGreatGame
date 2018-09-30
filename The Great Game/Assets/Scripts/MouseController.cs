using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour {
    [Header("Camera Settings")]
    [Tooltip("Main Camera")]
    Camera camera;

    // Use this for initialization
    void Start() {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Pew");

            ////// hierbei gab es das Problem das ich nicht mehr auf die properties zugreifen kann
            ////// diese lösung gefällt mir aber eindeutig besser:
            ////RaycastHit2D? hitNullable = CastRay(camera);
            ////RaycastHit2D hit = hitNullable ?? new RaycastHit2D();   // ! is there a better way to use the properties of a nullable variable? 

            NullableRaycastHit2D hit = CastRay(camera);

            if (hit.success == true) {
                // test
                Debug.Log("Hit object: " + hit.hit.collider.name);

                // Move player to hit Object/Position

                // Stop focusing any objects
            }
        }
    }

    // Helper Functions
    public NullableRaycastHit2D CastRay(Camera camera) {
        NullableRaycastHit2D returnvalue = new NullableRaycastHit2D();
        Vector3 ray = camera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray, Vector3.back);
        if (hit) {
            returnvalue.success = true;
            returnvalue.hit = hit;
        }
        return returnvalue;
    }
}