using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialFill : MonoBehaviour
{
    // Start is called before the first frame update
    void Update()
    {
        Fill(DataGame.munition/DataGame.MAX_MUNITION);
    }
    void Fill(float fill_amount)
    {
        gameObject.GetComponent<Image>().fillAmount = fill_amount;
    }

}
