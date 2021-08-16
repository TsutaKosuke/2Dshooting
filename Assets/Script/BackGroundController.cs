using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    private float deadLine = -4.5f;
    private float startLine = 4.5f;
    private float scrollspeed = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, this.scrollspeed * Time.deltaTime, 0);

        if (this.transform.position.y < deadLine)
        {
            transform.position = new Vector2(0, this.startLine);
        }
    }
}
