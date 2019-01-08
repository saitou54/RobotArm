using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylindricalIK : MonoBehaviour
{
    public Text text;
    private float DegJ1 = 0;
    private float LinL2 = 0, LinL3 = 0;
    private float RadJ1 = 0;
    private Vector3 PosL3;
    private GameObject J1, L2, L3, EC;
    private float endX, endY, endZ;

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(true);

        J1 = this.transform.Find("Joint1").gameObject;
        L2 = this.transform.Find("Linear2").gameObject;
        L3 = this.transform.Find("Linear3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;

        endX = 8.5f;
        endY = 15f;
        endZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (KeyCheck())
        {
            case 'w':
                endX += 0.1f;
                if (8.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2))
                    || 5.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2)))
                {
                    endX -= 0.1f;
                }
                break;
            case 's':
                endX -= 0.1f;
                if (8.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2))
                    || 5.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2)))
                {
                    endX += 0.1f;
                }
                break;
            case 'a':
                endZ += 0.1f;
                if (8.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2))
                    || 5.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2)))
                {
                    endZ -= 0.1f;
                }
                break;
            case 'd':
                endZ -= 0.1f;
                if (8.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2))
                    || 5.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2)))
                {
                    endZ += 0.1f;
                }
                break;
            case 'r':
                endY += 0.1f;
                if (endY > 16)
                {
                    endY -= 0.1f;
                }
                break;
            case 'f':
                endY -= 0.1f;
                if (endY < 2)
                {
                    endY += 0.1f;
                }
                break;
        }
        EC.transform.localPosition = new Vector3(endX, endY, endZ);

        /* 逆運動学による計算 */
        DegJ1 = Mathf.Atan2(endZ, endX) * Mathf.Rad2Deg;
        LinL2 = endY;
        LinL3 = Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2));

        /* 位置 */
        L2.transform.localPosition = new Vector3(0, LinL2, 0);
        RadJ1 = DegJ1 * Mathf.Deg2Rad;
        PosL3.x = (LinL3 - 2.5f) * Mathf.Cos(RadJ1);
        PosL3.y = LinL2;
        PosL3.z = (LinL3 - 2.5f) * Mathf.Sin(RadJ1);
        L3.transform.localPosition = PosL3;

        /* 姿勢 */
        J1.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        L2.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        L3.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        EC.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
    }

    /* キーボード入力処理 */
    private char KeyCheck()
    {
        if (Input.anyKey)
        {
            foreach (var c in Input.inputString)
            {
                if (c.ToString() != "")
                {
                    //Debug.Log(c);
                    return c;
                }
            }
        }
        return '0';
    }

}
