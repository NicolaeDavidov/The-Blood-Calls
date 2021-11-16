/*using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public PlayerStats stats;
    public Animator animator;

    public Transform healingPositionVFX;
    public Transform auraPosition;
    public GameObject parent;

    [Header("Healing")]
    public GameObject healingPrefabVFX;
    public GameObject healingVFX;

    [Header("Frost")]
    public GameObject frostPrefabVFX;
    public GameObject frostVFX;

    [Header("Fire")]
    public GameObject firePrefabVFX;
    public GameObject fireVFX;

    [Header("Water")]
    public GameObject waterPrefabVFX;
    public GameObject waterVFX;

    [Header("Dark")]
    public GameObject darkPrefabVFX;
    public GameObject darkVFX;

    [Header("Lightning")]
    public GameObject lightningPrefabVFX;
    public GameObject lightningVFX;

    public void ActivateHealing()
    {
        if (healingVFX == null)
        {
            animator.SetTrigger("skillUpgrade");
            healingVFX = Instantiate(healingPrefabVFX);
            healingVFX.transform.position = healingPositionVFX.position;
            healingVFX.transform.parent = parent.transform;
        }

    }

    public void ActivateFrost()
    {
        if (frostVFX == null)
        {
            animator.SetTrigger("skillUpgrade");
            frostVFX = Instantiate(frostPrefabVFX);
            frostVFX.transform.position = auraPosition.position;
            frostVFX.transform.parent = parent.transform;
            frostVFX.transform.localScale = new Vector3(2,2,2);
        }

    }

    public void ActivateFire()
    {
        if (fireVFX == null)
        {
            animator.SetTrigger("skillUpgrade");
            fireVFX = Instantiate(firePrefabVFX);
            fireVFX.transform.position = auraPosition.position;
            fireVFX.transform.parent = parent.transform;
            fireVFX.transform.localScale = new Vector3(2, 2, 2);
        }

    }

    public void ActivateWater()
    {
        if (waterVFX == null)
        {
            animator.SetTrigger("skillUpgrade");
            waterVFX = Instantiate(waterPrefabVFX);
            waterVFX.transform.position = auraPosition.position;
            waterVFX.transform.parent = parent.transform;
            waterVFX.transform.localScale = new Vector3(2, 2, 2);
        }

    }

    public void ActivateDark()
    {
        if (darkVFX == null)
        {
            animator.SetTrigger("skillUpgrade");
            darkVFX = Instantiate(darkPrefabVFX);
            darkVFX.transform.position = auraPosition.position;
            darkVFX.transform.parent = parent.transform;
            darkVFX.transform.localScale = new Vector3(2, 2, 2);
        }

    }

    public void ActivateLightning()
    {
        if (lightningVFX == null)
        {
            animator.SetTrigger("skillUpgrade");
            lightningVFX = Instantiate(lightningPrefabVFX);
            lightningVFX.transform.position = auraPosition.position;
            lightningVFX.transform.parent = parent.transform;
            lightningVFX.transform.localScale = new Vector3(2, 2, 2);
        }

    }

    public void UpgradeDamage()
    {
        animator.SetTrigger("skillUpgrade");
        stats.physicaldamage += 10;
    }



}
*/