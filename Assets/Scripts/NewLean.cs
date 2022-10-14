using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;

public class NewLean : MonoBehaviour
{
    private void OnMouseDown()
    {
        GetComponent<Lean.Touch.LeanDragTranslateRigidbody>().enabled = true;
    }

    private void OnMouseUp()
    {
        GetComponent<Lean.Touch.LeanDragTranslateRigidbody>().enabled = false;
    }
}
