using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingManager : MonoBehaviour
{
    [SerializeField] Slider bGMSlider, sESlider;
    bool flag = false;
    // Start is called before the first frame update
    void Start()
    {
        bGMSlider.value = PlayerPrefs.GetFloat("BGMScale");
        float value = PlayerPrefs.GetFloat("SEScale");
        Debug.Log(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSliderValueChanged()
    {
        if (flag)
        {
            PlayerPrefs.SetFloat("BGMScale", bGMSlider.value);
            PlayerPrefs.SetFloat("SEScale", sESlider.value);
            Debug.Log(bGMSlider.value);
        }
        else
        {
            flag = true;
        }
    }
}
