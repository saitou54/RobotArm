using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartesianIK : MonoBehaviour
{
    public Text text;
    private GameObject L1, L2, L3, EC;
    private float endX, endY, endZ;

    // Start is called before the first frame update
    void Start()
    {
        text.gameObject.SetActive(true);

        L1 = this.transform.Find("Linear1").gameObject;
        L2 = this.transform.Find("Linear2").gameObject;
        L3 = this.transform.Find("Linear3").gameObject;
        EC = this.transform.Find("EndChip").gameObject;

        endX = 11.5f;
        endY = 11f;
        endZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(KeyCheck())
        {
            case 'w':
                endX += 0.1f;
                if(endX > 11.5)
                {
                    endX -= 0.1f;
                }
                break;
            case 's':
                endX -= 0.1f;
                if (endX < 1.5)
                {
                    endX += 0.1f;
                }
                break;
            case 'a':
                endZ += 0.1f;
                if (endZ > 6.0)
                {
                    endZ -= 0.1f;
                }
                break;
            case 'd':
                endZ -= 0.1f;
                if (endZ < -6.0)
                {
                    endZ += 0.1f;
                }
                break;
            case 'r':
                endY += 0.1f;
                if (endY > 11)
                {
                    endY -= 0.1f;
                }
                break;
            case 'f':
                endY -= 0.1f;
                if (endY < 1)
                {
                    endY += 0.1f;
                }
                break;
        }
        EC.transform.localPosition = new Vector3(endX, endY, endZ);

        L1.transform.localPosition = new Vector3(0, 8.5f, endZ);
        L2.transform.localPosition = new Vector3(6.25f, endY + 2.5f, endZ);
        L3.transform.localPosition = new Vector3(endX, endY + 1.25f, endZ);
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
