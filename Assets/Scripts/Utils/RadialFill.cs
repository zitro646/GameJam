using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialFill : MonoBehaviour
{
    public GameObject Filler;
    // Start is called before the first frame update
    void Start()
    {
        Fill(0.8f);
        
    }
    void Fill(float fill_amount)
    {
        Filler.GetComponent<Image>().fillAmount = fill_amount;
    }

}
