using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineRendererSettings : MonoBehaviour
{
    //LineRenderer attached to the selector
    [SerializeField]
    LineRenderer rend;

    public GameObject panel;
    private Image img;
    private Button button;

    //LineRenderer settings
    Vector3[] points;

    public LayerMask layerMask;

    public bool AlignLineRenderer() {
        bool buttonHit = false;
        Ray ray;
        ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, layerMask)) {
            buttonHit = true;
            button = hit.collider.gameObject.GetComponent<Button>();
            points[1] = transform.forward + new Vector3(0, 0, hit.distance);
            rend.startColor = Color.red;
            rend.endColor = Color.red;
        } else {
            buttonHit = false;
            points[1] = transform.forward + new Vector3(0, 0, 20);
            rend.startColor = Color.green;
            rend.endColor = Color.green;
        }
        rend.SetPositions(points);
        return buttonHit;
    }

    public void OnButtonClick() {
        if(button != null) {
            switch(button.name) {
                case "RedButton":
                    img.color = Color.red;
                    break;
                case "GreenButton":
                    img.color = Color.green;
                    break;
                case "BlueButton":
                    img.color = Color.blue;
                    break;
            }
        }
    }

    void Start() {
        img = panel.GetComponent<Image>();
        rend = gameObject.GetComponent<LineRenderer>();
        points = new Vector3[2];
        //Resets start point to the selector
        points[0] = Vector3.zero;
        //Sets end point
        points[1] = transform.position + new Vector3(0, 0, 20);
        rend.SetPositions(points);
        rend.enabled = true;
    }

    void Update() {
        if(AlignLineRenderer() && Input.GetAxis("Submit") > 0) {
            button.onClick.Invoke();
        }
        rend.material.color = rend.startColor;
    }
}
