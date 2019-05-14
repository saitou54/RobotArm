using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartesianFK : MonoBehaviour
{
    public Image SliderBG;
    public Slider Slider1, Slider2, Slider3;
    private float LinL1 = 0, LinL2 = 0, LinL3 = 0;
    private GameObject L1, L2, L3, EC;

    // Start is called before the first frame update
    void Start()
    {
        //Slider1.gameObject.SetActive(true);
        //Slider2.gameObject.SetActive(true);
        //Slider3.gameObject.SetActive(true);

        L1 = this.transform.Find("Linear1").gameObject;
        L2 = this.transform.Find("Linear2").gameObject;
        L3 = this.transform.Find("Linear3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        LinL1 = Slider1.value;
        LinL2 = Slider2.value;
        LinL3 = Slider3.value;

        L1.transform.localPosition = new Vector3(0, 8.5f, LinL1);
        L2.transform.localPosition = new Vector3(6.25f, LinL2 + 3.5f, LinL1);
        L3.transform.localPosition = new Vector3(LinL3 + 1.5f, LinL2 + 2.25f, LinL1);
        EC.transform.localPosition = new Vector3(LinL3 + 1.5f, LinL2 + 1.0f, LinL1);
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
