/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public Skills skill;
    public GameObject skillUi;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            skillUi.gameObject.SetActive(!skillUi.activeSelf);
        }
    }

    public void Healing()
    {
        skill.ActivateHealing();
    }

    public void Fire()
    {
        skill.ActivateFire();
    }

    public void Water()
    {
        skill.ActivateWater();
    }

    public void Lightning()
    {
        skill.ActivateLightning();
    }

    public void Dark()
    {
        skill.ActivateDark();
    }

    public void Frost()
    {
        skill.ActivateFrost();
    }

    public void Damage()
    {
        skill.UpgradeDamage();
    }

    public void HideAllAuras()
    {
        Destroy(skill.darkVFX.gameObject);
        Destroy(skill.frostVFX.gameObject);
        Destroy(skill.lightningVFX.gameObject);
        Destroy(skill.waterVFX.gameObject);
        Destroy(skill.fireVFX.gameObject);
        Destroy(skill.healingVFX.gameObject);
    }

    public void HideButton()
    {
        button.interactable = false;
    }

}
*/