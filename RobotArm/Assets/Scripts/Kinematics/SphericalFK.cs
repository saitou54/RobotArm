using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphericalFK : MonoBehaviour
{
    public Image SliderBG;
    public Slider Slider1, Slider2, Slider3;
    private float Link1;
    private float DegJ1 = 0, DegJ2 = 0;
    private float RadJ1 = 0, RadJ2 = 0;
    private float LinL3 = 0;
    private Vector3 PosL3, PosEnd;
    private GameObject J1, J2, L3, EC;

    // Start is called before the first frame update
    void Start()
    {
        //Slider1.gameObject.SetActive(true);
        //Slider2.gameObject.SetActive(true);
        //Slider3.gameObject.SetActive(true);

        J1 = this.transform.Find("Joint1").gameObject;
        J2 = this.transform.Find("Joint2").gameObject;
        L3 = this.transform.Find("Linear3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;

        Link1 = this.transform.Find("Joint1/Link1").gameObject.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        DegJ1 = Slider1.value;
        DegJ2 = Slider2.value;
        LinL3 = Slider3.value;
        RadJ1 = DegJ1 * Mathf.Deg2Rad;
        RadJ2 = DegJ2 * Mathf.Deg2Rad;

        /* 運動学による計算 */
        PosL3.x = LinL3 * Mathf.Cos(RadJ2) * Mathf.Cos(RadJ1);
        PosL3.y = LinL3 * Mathf.Sin(RadJ2) + Link1;
        PosL3.z = LinL3 * Mathf.Cos(RadJ2) * Mathf.Sin(RadJ1);
        PosEnd.x = (LinL3 + 3.0f) * Mathf.Cos(RadJ2) * Mathf.Cos(RadJ1);
        PosEnd.y = (LinL3 + 3.0f) * Mathf.Sin(RadJ2) + Link1;
        PosEnd.z = (LinL3 + 3.0f) * Mathf.Cos(RadJ2) * Mathf.Sin(RadJ1);

        /* 位置 */
        L3.transform.localPosition = PosL3;
        EC.transform.localPosition = PosEnd;

        /* 姿勢 */
        J1.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), 0);
        J2.transform.eulerAngles = new Vector3(DegJ2, DegJ1 * (-1) + (-90), 90);
        L3.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), DegJ2);
        EC.transform.eulerAngles = new Vector3(0, DegJ1 * (-1), DegJ2);
    }

    private void OnEnable()
    {
        SliderBG.gameObject.SetActive(true);
        Slider1.gameObject.SetActive(true);
        Slider2.gameObject.SetActive(true);
        Slider3.gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        SliderBG.gameObject.SetActive(false);
        Slider1.gameObject.SetActive(false);
        Slider2.gameObject.SetActive(false);
        Slider3.gameObject.SetActive(false);
    }
}
