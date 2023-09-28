using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
   [SerializeField] Slider _slider;
   [SerializeField] Vector3 _offset;

    private void Update() 
    {
        _slider.transform.rotation = Quaternion.Euler(0f, 0f, 0f);    
    }
   public void SetHealthValue(int currenHealth, int maxHealth)
   {
        _slider.maxValue = maxHealth;
        _slider.value = currenHealth;
   }
}
