using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnRetry(int num)
    {
        switch (num)
        {
            case 0:
                SceneManager.LoadScene("Title");
                break;
            case 1:
                SceneManager.LoadScene("Articulated Robot");
                break;
            case 2:
                SceneManager.LoadScene("Cartesian Robot");
                break;
            case 3:
                SceneManager.LoadScene("Cylindrical Robot");
                break;
            case 4:
                SceneManager.LoadScene("Spherical Robot");
                break;
        }
    }
}
