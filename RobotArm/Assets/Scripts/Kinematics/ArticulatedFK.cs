using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArticulatedFK : MonoBehaviour
{
    public Image SliderBG;
    public Slider Slider1, Slider2, Slider3;
    //public GameObject Joint1, Joint2, Joint3, EndChip;
    public float Link1, Link2, Link3;
    private float DegJ1 = 0, DegJ2 = 0, DegJ3 = 0;
    private float RadJ1 = 0, RadJ2 = 0, RadJ3 = 0;
    private Vector3 /*PosJ1, PosJ2,*/ PosJ3, PosEnd;
    private GameObject L1, L2, L3, J1, J2, J3, EC;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject.Find("KeyInput").gameObject.SetActive(false);
        //Slider1.gameObject.SetActive(true);
        //Slider2.gameObject.SetActive(true);
        //Slider3.gameObject.SetActive(true);

        //L1 = Joint1.transform.Find("Link1").gameObject;
        //L2 = Joint2.transform.Find("Link2").gameObject;
        //L3 = Joint3.transform.Find("Link3").gameObject;
        L1 = this.transform.Find("Joint1/Link1").gameObject;
        L2 = this.transform.Find("Joint2/Link2").gameObject;
        L3 = this.transform.Find("Joint3/Link3").gameObject;
        L1.transform.localPosition = new Vector3(0, Link1*0.5f, 0);
        L2.transform.localPosition = new Vector3(0, 0, -(Link2*0.5f));
        L3.transform.localPosition = new Vector3(0, 0, -(Link3*0.5f));
        L1.transform.localScale = new Vector3(L1.transform.localScale.x, Link1, L1.transform.localScale.z);
        L2.transform.localScale = new Vector3(L2.transform.localScale.x, Link2, L2.transform.localScale.z);
        L3.transform.localScale = new Vector3(L3.transform.localScale.x, Link3, L3.transform.localScale.z);

        J1 = this.transform.Find("Joint1").gameObject;
        J2 = this.transform.Find("Joint2").gameObject;
        J3 = this.transform.Find("Joint3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;
        J2.transform.localPosition = new Vector3(0, Link1*0.5f, 0);
        J3.transform.localPosition = new Vector3(Link2, Link1*0.5f, 0);
        EC.transform.localPosition = new Vector3(Link2+Link3, Link1*0.5f, 0);
        /*
        PosJ1.x = Joint1.transform.position.x;
        PosJ1.y = Joint1.transform.position.y;
        PosJ1.z = Joint1.transform.position.z;
        PosJ2.x = Joint2.transform.position.x;
        PosJ2.y = Link2;
        PosJ2.z = Joint2.transform.position.z;
        */
    }

    // Update is called once per frame
    void Update()
    {
        DegJ1 = Slider1.value;
        DegJ2 = Slider2.value;
        DegJ3 = Slider3.value;
        RadJ1 = DegJ1 * Mathf.Deg2Rad;
        RadJ2 = DegJ2 * Mathf.Deg2Rad;
        RadJ3 = DegJ3 * Mathf.Deg2Rad;

        /* 運動学による位置の計算 */
        PosJ3.x = (Link2 * Mathf.Cos(RadJ2)) * Mathf.Cos(RadJ1);
        PosJ3.y = (Link2 * Mathf.Sin(RadJ2)) + Link1 * 0.5f;
        PosJ3.z = (Link2 * Mathf.Cos(RadJ2)) * Mathf.Sin(RadJ1);
        PosEnd.x = ((Link3 * Mathf.Cos(RadJ2 + RadJ3)) + (Link2 * Mathf.Cos(RadJ2))) * Mathf.Cos(RadJ1);
        PosEnd.y = (Link3 * Mathf.Sin(RadJ2 + RadJ3)) + (Link2 * Mathf.Sin(RadJ2)) + Link1*0.5f;
        PosEnd.z = ((Link3 * Mathf.Cos(RadJ2 + RadJ3)) + (Link2 * Mathf.Cos(RadJ2))) * Mathf.Sin(RadJ1);

        if(PosEnd.y - 0.5f <= 0)
        {
            Slider2.value++;
            Slider3.value++;
        }

        /* 位置 */
        J3.transform.localPosition = PosJ3;
        EC.transform.localPosition = PosEnd;
        
        /* 姿勢 */
        J1.transform.eulerAngles = new Vector3(0, DegJ1*(-1), 0);
        J2.transform.eulerAngles = new Vector3(DegJ2, DegJ1*(-1)+(-90), 90);
        J3.transform.eulerAngles = new Vector3(DegJ2+DegJ3, DegJ1*(-1)+(-90), 90);
        EC.transform.eulerAngles = new Vector3(0, DegJ1*(-1), DegJ2 + DegJ3);
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
