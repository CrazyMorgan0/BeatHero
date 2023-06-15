using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenu : MonoBehaviour
{
    public GameObject menu;
    public LineRenderer[] lineRenderers;

    public void HideMenu() {
        menu.SetActive(false);
        foreach(LineRenderer rend in lineRenderers) {
            rend.gameObject.SetActive(false);
        }
    }

    public void ShowMenu() {
        menu.SetActive(true);
        foreach(LineRenderer rend in lineRenderers) {
            rend.gameObject.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HideMenu();
    }
}
