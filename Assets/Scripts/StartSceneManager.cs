using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{
    public GameObject mainCam;

    private void Update()
    {
        mainCam.transform.Translate(10f * Time.deltaTime, 0, 0);
        if (mainCam.transform.position.x > 900f)
        {
            mainCam.transform.position = new Vector3(0f, 0f, 0f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}
