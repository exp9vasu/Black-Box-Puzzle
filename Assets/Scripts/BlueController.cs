using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueController : MonoBehaviour
{
    public Vector2 startClick, DeltaSwipe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        startClick = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        DeltaSwipe = (Vector2)Input.mousePosition - startClick;

        if (DeltaSwipe.x > 0)
        {
            transform.Translate(1, 0, 0);
        }
        if (DeltaSwipe.x < 0)
        {
            transform.Translate(-1, 0, 0);
        }
        if (DeltaSwipe.y > 0)
        {
            transform.Translate(0, 0, 1);
        }
        if (DeltaSwipe.y < 0)
        {
            transform.Translate(0, 0, -1);
        }
    }

    private void OnMouseDrag()
    {
        
    }

    private void OnMouseOver()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        print(DeltaSwipe.x + "X");
    }
}
