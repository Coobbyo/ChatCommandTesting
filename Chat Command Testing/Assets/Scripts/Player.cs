using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public string username;
    [SerializeField] TMP_Text nameDisplay;

    private void Update()
    {
        nameDisplay.text = username;
    }
}
