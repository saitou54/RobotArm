using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CylindricalFK : MonoBehaviour
{
    public Slider Slider1, Slider2, Slider3;
    private float DegJ1 = 0;
    private float RadJ1 = 0;
    private float LinL2 = 0, LinL3 = 0;
    private Vector3 PosL3, PosEnd;
    private GameObject J1, L2, L3, EC;

    // Start is called before the first frame update
    void Start()
    {
        Slider1.gameObject.SetActive(true);
        Slider2.gameObject.SetActive(true);
        Slider3.gameObject.SetActive(true);

        J1 = this.transform.Find("Joint1").gameObject;
        L2 = this.transform.Find("Linear2").gameObject;
        L3 = this.transform.Find("Linear3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DegJ1 = Slider1.value;
        RadJ1 = DegJ1 * Mathf.Deg2Rad;
        LinL2 = Slider2.value;
        LinL3 = Slider3.value;

        /* 運動学による計算 */
        PosL3.x = LinL3 * Mathf.Cos(RadJ1);
        PosL3.y = LinL2;
        PosL3.z = LinL3 * Mathf.Sin(RadJ1);
        PosEnd.x = (LinL3 + 2.5f) * Mathf.Cos(RadJ1);
        PosEnd.y = LinL2;
        PosEnd.z = (LinL3 + 2.5f) * Mathf.Sin(RadJ1);

        /* 位置 */
        L2.transform.localPosition = new Vector3(0, LinL2, 0);
        L3.transform.localPosition = PosL3;
        EC.transform.localPosition = PosEnd;

        /* 姿勢 */
        J1.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        L2.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        L3.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        EC.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
    }
}
