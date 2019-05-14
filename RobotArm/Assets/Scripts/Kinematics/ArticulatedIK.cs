using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ArticulatedIK : MonoBehaviour
{
    public Text text;
    public float Link1, Link2, Link3;
    private float LenA, LenB;
    private float DegJ1 = 0, DegJ2 = 0, DegJ3 = 0, DegA, DegB;
    private float RadJ1 = 0, RadJ2 = 0/*, RadJ3 = 0*/;
    private Vector3 /*PosJ1, PosJ2,*/ PosJ3/*, PosEnd*/;
    private GameObject L1, L2, L3, J1, J2, J3, EC;
    private float endX, endY, endZ;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("Deg1").gameObject.SetActive(false);
        //GameObject.Find("Deg2").gameObject.SetActive(false);
        //GameObject.Find("Deg3").gameObject.SetActive(false);
        //text.gameObject.SetActive(true);

        L1 = this.transform.Find("Joint1/Link1").gameObject;
        L2 = this.transform.Find("Joint2/Link2").gameObject;
        L3 = this.transform.Find("Joint3/Link3").gameObject;
        L1.transform.localPosition = new Vector3(0, Link1 * 0.5f, 0);
        L2.transform.localPosition = new Vector3(0, 0, -(Link2 * 0.5f));
        L3.transform.localPosition = new Vector3(0, 0, -(Link3 * 0.5f));
        L1.transform.localScale = new Vector3(L1.transform.localScale.x, Link1, L1.transform.localScale.z);
        L2.transform.localScale = new Vector3(L2.transform.localScale.x, Link2, L2.transform.localScale.z);
        L3.transform.localScale = new Vector3(L3.transform.localScale.x, Link3, L3.transform.localScale.z);

        J1 = this.transform.Find("Joint1").gameObject;
        J2 = this.transform.Find("Joint2").gameObject;
        J3 = this.transform.Find("Joint3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;
        J2.transform.localPosition = new Vector3(0, Link1 * 0.5f, 0);
        J3.transform.localPosition = new Vector3(Link2, Link1 * 0.5f, 0);
        EC.transform.localPosition = new Vector3(Link2 + Link3, Link1 * 0.5f, 0);

        endX = EC.transform.localPosition.x;
        endY = EC.transform.localPosition.y;
        endZ = EC.transform.localPosition.z;
    }

    // Update is called once per frame
    void Update()
    {
        switch (KeyCheck())
        {
            case 'w':
                endX += 0.1f;
                if (Mathf.Pow(Link2 + Link3, 2) <= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2))
                    || Mathf.Pow(Link2 - Link3, 2) + 0.1f >= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2)))
                {
                    Debug.Log("Out of range!");
                    endX -= 0.1f;
                }
                break;
            case 's':
                endX -= 0.1f;
                if (Mathf.Pow(Link2 + Link3, 2) <= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2))
                    || Mathf.Pow(Link2 - Link3, 2) + 0.1f >= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2)))
                {
                    Debug.Log("Out of range!");
                    endX += 0.1f;
                }
                break;
            case 'a':
                endZ += 0.1f;
                if (Mathf.Pow(Link2 + Link3, 2) <= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2))
                    || Mathf.Pow(Link2 - Link3, 2) + 0.1f >= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2)))
                {
                    Debug.Log("Out of range!");
                    endZ -= 0.1f;
                }
                break;
            case 'd':
                endZ -= 0.1f;
                if (Mathf.Pow(Link2 + Link3, 2) <= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2))
                    || Mathf.Pow(Link2 - Link3, 2) + 0.1f >= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2)))
                {
                    Debug.Log("Out of range!");
                    endZ += 0.1f;
                }
                break;
            case 'r':
                endY += 0.1f;
                if (Mathf.Pow(Link2 + Link3, 2) <= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2))
                    || Mathf.Pow(Link2 - Link3, 2) + 0.1f >= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2)))
                {
                    Debug.Log("Out of range!");
                    endY -= 0.1f;
                }
                break;
            case 'f':
                endY -= 0.1f;
                if (Mathf.Pow(Link2 + Link3, 2) <= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2))
                    || Mathf.Pow(Link2 - Link3, 2) + 0.1f >= (Mathf.Pow(endX, 2)) + (Mathf.Pow(endY - Link1 * 0.5f, 2)) + (Mathf.Pow(endZ, 2))
                    || endY - 0.5f <= 0)
                {
                    Debug.Log("Out of range!");
                    endY += 0.1f;
                }
                break;
        }
        EC.transform.localPosition = new Vector3(endX, endY, endZ);

        /* 逆運動学による姿勢(角度)の計算 */
        LenA = Mathf.Sqrt(endX*endX + endZ*endZ)/*endX / Mathf.Cos(Mathf.Atan2(endZ, endX))*/;
        LenB = (endY - Link1 * 0.5f) * (-1);
        DegA = Mathf.Acos((LenA*LenA + LenB*LenB - Link2*Link2 - Link3*Link3) / (2.0f*Link2*Link3));
        DegB = Mathf.Atan2(Link3*Mathf.Sin(DegA), Link2 + Link3*Mathf.Cos(DegA));
        DegJ1 = Mathf.Atan2(endZ, endX) * Mathf.Rad2Deg;
        DegJ2 = Mathf.Asin(LenB / Mathf.Sqrt(LenA*LenA + LenB*LenB)/*(LenA / Mathf.Cos(Mathf.Atan2(LenB, LenA)))*/) * Mathf.Rad2Deg - DegB * Mathf.Rad2Deg;
        DegJ3 = DegA * Mathf.Rad2Deg;
        
        //Debug.Log("J1 = " + DegJ1);
        //Debug.Log("J2 = " + DegJ2);
        //Debug.Log("J3 = " + DegJ3);

        /* 位置 */
        RadJ1 = DegJ1 * Mathf.Deg2Rad;
        RadJ2 = DegJ2 * Mathf.Deg2Rad;
        PosJ3.x = (Link2 * Mathf.Cos(RadJ2)) * Mathf.Cos(RadJ1);
        PosJ3.y = (Link2 * Mathf.Sin(RadJ2*(-1))) + Link1 * 0.5f;
        PosJ3.z = (Link2 * Mathf.Cos(RadJ2)) * Mathf.Sin(RadJ1);
        J3.transform.localPosition = PosJ3;

        /* 姿勢 */
        J1.transform.eulerAngles = new Vector3(0, DegJ1*(-1), 0);
        J2.transform.eulerAngles = new Vector3(DegJ2*(-1), DegJ1*(-1) + (-90), 90);
        J3.transform.eulerAngles = new Vector3((DegJ2+DegJ3)*(-1), DegJ1*(-1) + (-90), 90);
        EC.transform.eulerAngles = new Vector3(0, DegJ1*(-1), (DegJ2 + DegJ3) * (-1));
    }

    /* キーボード入力処理 */
    private char KeyCheck()
    {
        if(Input.anyKey)
        {
            foreach(var c in Input.inputString)
            {
                if(c.ToString() != "")
                {
                    //Debug.Log(c);
                    return c;
                }
            }
            /*
            foreach(KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if(Input.GetKeyDown(code))
                {
                    Debug.Log(code);
                    return code;
                }
            }
            */
        }
        return '0';
    }

    private void OnEnable()
    {
        text.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        text.gameObject.SetActive(false);
    }
}
