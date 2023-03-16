using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    [SerializeField] float DestroyTime;
    [SerializeField] float FieldSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
      
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(FieldSpeed * Time.deltaTime, 0, 0);
        DestroyTime += Time.deltaTime;
        if(DestroyTime > 15.0)
        {
            Destroy(this.gameObject);
        }
    }
}
