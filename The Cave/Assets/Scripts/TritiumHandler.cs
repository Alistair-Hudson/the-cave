using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TritiumHandler : MonoBehaviour
{
    [SerializeField] float maxTritium = 100f;

    float tritium = 0;
    Image tritiumGuage = null;

    // Start is called before the first frame update
    void Start()
    {
        tritiumGuage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        tritiumGuage.fillAmount = tritium / maxTritium;
    }

    public void AlterTritiumAmount(float amount)
    {
        tritium += amount;
        if(tritium >= maxTritium)
        {
            Debug.Log("Game Won");
            return;
        }
        if (tritium < 0)
        {
            tritium = 0;
        }
    }

    public float GetTritiumAmount()
    {
        return tritium;
    }
}
