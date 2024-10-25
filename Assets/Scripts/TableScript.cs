using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableScript : MonoBehaviour
{
    StatManager statManager;
    bool shaking = false;
    Vector3 defaultPos;

    private void Awake()
    {
        statManager = GetComponent<StatManager>();
        defaultPos = transform.position;
    }
    private void Update()
    {
        if (shaking)
            transform.position = new Vector3(defaultPos.x + Mathf.Sin(Time.time * 50) * 0.075f, transform.position.y, transform.position.z);
        //transform.position.x = Mathf.Sin(Time.time * 10);
        //transform.position = new Vector3(transform.position.x + Mathf.Sin(Time.time * 10), transform.position.y, transform.position.z + Mathf.Sin(Time.time));
        else
            transform.position = defaultPos;
    }
    public void GetHit(float damageToDeal)
    {
        if (!shaking)
        {
            statManager.LowerStat(StatManager.StatType.Health, damageToDeal);
            shaking = true;
            //AudioHelper.PlayOneShotWithParameters("event:/WoodHit", this.transform.position, ("SFXVolume", PlayerPrefs.GetFloat("SFXVolume")));
            StartCoroutine(ShakingTimer());
        }
    }

    IEnumerator ShakingTimer()
    {
        yield return new WaitForSeconds(0.5f);
        shaking = false;
    }
}