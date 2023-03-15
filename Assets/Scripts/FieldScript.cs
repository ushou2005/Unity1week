using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    public float Speed = 10f;
    float DestroyTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DestroyTime += Time.deltaTime;
        transform.position += new Vector3(-Speed * Time.deltaTime, 0, 0);
        if(DestroyTime > 10.0)
        {
            Destroy(this.gameObject);
        }
    }
}
