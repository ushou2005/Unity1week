using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerater : MonoBehaviour
{
    public GameObject Ground;

    float GenerateTime;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ground, new Vector3(380, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GenerateTime += Time.deltaTime;
        if (GenerateTime > 3.9f)
        {
            Instantiate(Ground, new Vector3(380,0,0), Quaternion.identity);
            GenerateTime = 0;
        }
    }
}
