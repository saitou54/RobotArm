using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphericalIK : MonoBehaviour
{
    public Text text;
    private float Link1 = 0;
    private float DegJ1 = 0, DegJ2 = 0;
    private float LinL3 = 0;
    private float RadJ1 = 0, RadJ2 = 0;
    private Vector3 PosL3;
    private GameObject L1, J1, J2, L3, EC;
    private float endX, endY, endZ;

    // Start is called before the first frame update
    void Start()
    {
        //text.gameObject.SetActive(true);

        J1 = this.transform.Find("Joint1").gameObject;
        J2 = this.transform.Find("Joint2").gameObject;
        L3 = this.transform.Find("Linear3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;

        endX = 10.5f;
        endY = 10f;
        endZ = 0;

        L1 = this.transform.Find("Joint1/Link1").gameObject;
        Link1 = L1.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        switch (KeyCheck())
        {
            case 'w':
                endX += 0.1f;
                if (10.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2))
                    || 6.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2)))
                {
                    endX -= 0.1f;
                }
                break;
            case 's':
                endX -= 0.1f;
                if (10.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2))
                    || 6.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2)))
                {
                    endX += 0.1f;
                }
                break;
            case 'a':
                endZ += 0.1f;
                if (10.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2))
                    || 6.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2)))
                {
                    endZ -= 0.1f;
                }
                break;
            case 'd':
                endZ -= 0.1f;
                if (10.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2))
                    || 6.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2)))
                {
                    endZ += 0.1f;
                }
                break;
            case 'r':
                endY += 0.1f;
                if (10.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2))
                    || 6.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2)))
                {
                    endY -= 0.1f;
                }
                break;
            case 'f':
                endY -= 0.1f;
                if (10.5 < Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2))
                    || 6.0 > Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endY - Link1, 2) + Mathf.Pow(endZ, 2))
                    || 0 >= endY - 0.5f)
                {
                    endY += 0.1f;
                }
                break;
        }
        EC.transform.localPosition = new Vector3(endX, endY, endZ);

        /* 逆運動学による計算 */
        DegJ1 = Mathf.Atan2(endZ, endX) * Mathf.Rad2Deg;
        DegJ2 = Mathf.Atan2(endY - Link1, Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2))) * Mathf.Rad2Deg;
        LinL3 = Mathf.Sqrt(Mathf.Pow(endX, 2) + Mathf.Pow(endZ, 2) + Mathf.Pow(endY - Link1, 2));

        /* 位置 */
        RadJ1 = DegJ1 * Mathf.Deg2Rad;
        RadJ2 = DegJ2 * Mathf.Deg2Rad;
        PosL3.x = ((LinL3 - 3.0f) * Mathf.Cos(RadJ2)) * Mathf.Cos(RadJ1);
        PosL3.y = ((LinL3 - 3.0f) * Mathf.Sin(RadJ2)) + Link1;
        PosL3.z = ((LinL3 - 3.0f) * Mathf.Cos(RadJ2)) * Mathf.Sin(RadJ1);
        L3.transform.localPosition = PosL3;

        /* 姿勢 */
        J1.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        J2.transform.eulerAngles = new Vector3(DegJ2, DegJ1 * (-1) + (-90), 90);
        L3.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), DegJ2);
        EC.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), DegJ2);
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

    private void OnEnable()
    {
        text.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        text.gameObject.SetActive(false);
    }
}
