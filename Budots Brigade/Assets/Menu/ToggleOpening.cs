using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ToggleOpening : MonoBehaviour {
    public GameObject[] Pages;
    private int _currentPage = 0;

    public void NextPage() {
        Pages[_currentPage].gameObject.SetActive(false);
        _currentPage = (_currentPage + 1) % Pages.Length;
        Pages[_currentPage].gameObject.SetActive(true);
    }
    public void PreviousPage() {
        Pages[_currentPage].gameObject.SetActive(false);
        _currentPage = (_currentPage - 1) % Pages.Length;
        Pages[_currentPage].gameObject.SetActive(true);
    }
}
