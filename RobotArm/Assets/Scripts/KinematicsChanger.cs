using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KinematicsChanger : MonoBehaviour
{
    public GameObject RobotArm;
    /*
    // Flag : true = IK, false = FK
    bool ArticulatedFlag = true;
    bool CartesianFlag = true;
    bool CylindricalFlag = true;
    bool SphericalFlag = true;
    */
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (SceneManager.GetActiveScene().name == "Articulated Robot")
        {
            RobotArm.GetComponent<ArticulatedFK>().enabled = !RobotArm.GetComponent<ArticulatedFK>().enabled;
            RobotArm.GetComponent<ArticulatedIK>().enabled = !RobotArm.GetComponent<ArticulatedIK>().enabled;
        }
        else if(SceneManager.GetActiveScene().name == "Cartesian Robot")
        {
            RobotArm.GetComponent<CartesianFK>().enabled = !RobotArm.GetComponent<CartesianFK>().enabled;
            RobotArm.GetComponent<CartesianIK>().enabled = !RobotArm.GetComponent<CartesianIK>().enabled;
        }
        else if (SceneManager.GetActiveScene().name == "Cylindrical Robot")
        {
            RobotArm.GetComponent<CylindricalFK>().enabled = !RobotArm.GetComponent<CylindricalFK>().enabled;
            RobotArm.GetComponent<CylindricalIK>().enabled = !RobotArm.GetComponent<CylindricalIK>().enabled;
        }
        else if (SceneManager.GetActiveScene().name == "Spherical Robot")
        {
            RobotArm.GetComponent<SphericalFK>().enabled = !RobotArm.GetComponent<SphericalFK>().enabled;
            RobotArm.GetComponent<SphericalIK>().enabled = !RobotArm.GetComponent<SphericalIK>().enabled;
        }
    }
}
