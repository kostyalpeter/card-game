using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Animations2 : MonoBehaviour
{
    public GameObject ice;
    public GameObject lightning;
    public GameObject fireRain;
    public GameObject burst;
    public GameObject sword;
    public GameObject fireBall;
    public GameObject theBlackArrow;
    public GameObject fireShots;
    public GameObject arrowRain;
    public GameObject arrowShot;
    public GameObject iceButton;
    public GameObject lightningButton;
    public GameObject fireRainButton;
    public GameObject burstButton;
    public GameObject swordButton;
    public GameObject fireBallButton;
    public GameObject theBlackArrowButton;
    public GameObject fireShotsButton;
    public GameObject arrowRainButton;
    public GameObject arrowShotButton;
    public bool FireRainBool;
    public bool FireShotsBool;
    public bool ArrowRainBool;

    public GameObject heal;
    public GameObject moreXp;
    public GameObject moreTime;
    public GameObject lessDamage;
    public GameObject damageBoost;
    public GameObject moreGold;
    public GameObject shield;
    public GameObject hp;
    public GameObject water;
    public GameObject oil;
    public GameObject HpButton;
    public GameObject HealButton;
    public GameObject MoreXpButton;
    public GameObject MoreTimeButton;
    public GameObject LessDamageButton;
    public GameObject DamageBoostButton;
    public GameObject MoreGoldButton;
    public GameObject ShieldButton;
    public GameObject OilButton;
    public GameObject WaterButton;
    Button btn;

    private Dictionary<Transform, Vector3> initialPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Quaternion> initialRotations = new Dictionary<Transform, Quaternion>();
    
    // Szótár a futó időzítők (Coroutine-ok) nyomon követésére
    private Dictionary<GameObject, Coroutine> activeCoroutines = new Dictionary<GameObject, Coroutine>();

    void Awake()
    {
        SaveInitialTransforms(ice);
        SaveInitialTransforms(lightning);
        SaveInitialTransforms(fireRain);
        SaveInitialTransforms(burst);
        SaveInitialTransforms(sword);
        SaveInitialTransforms(fireBall);
        SaveInitialTransforms(theBlackArrow);
        SaveInitialTransforms(fireShots);
        SaveInitialTransforms(arrowRain);
        SaveInitialTransforms(arrowShot);
        SaveInitialTransforms(heal);
        SaveInitialTransforms(moreXp);
        SaveInitialTransforms(moreTime);
        SaveInitialTransforms(lessDamage);
        SaveInitialTransforms(damageBoost);
        SaveInitialTransforms(moreGold);
        SaveInitialTransforms(shield);
        SaveInitialTransforms(hp);
        SaveInitialTransforms(water);
        SaveInitialTransforms(oil);
    }

    void Update()
    {
        if (NonAttacks.Shield)
        {
            shield.SetActive(true);
        }
    }

    private void SaveInitialTransforms(GameObject parent)
    {
        if (parent == null) return;

        Transform[] transforms = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in transforms)
        {
            if (!initialPositions.ContainsKey(t))
            {
                initialPositions.Add(t, t.localPosition);
                initialRotations.Add(t, t.localRotation);
            }
        }
    }

    private void ResetTransforms(GameObject parent)
    {
        if (parent == null) return;

        Transform[] transforms = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in transforms)
        {
            if (initialPositions.TryGetValue(t, out Vector3 startPos))
            {
                t.localPosition = startPos;
            }
            if (initialRotations.TryGetValue(t, out Quaternion startRot))
            {
                t.localRotation = startRot;
            }
        }
    }

    private void PlayAttack(GameObject parentObj)
    {
        if (parentObj == null) return;

        // Ha erre az objektumra már futott egy kikapcsoló időzítő, leállítjuk
        if (activeCoroutines.TryGetValue(parentObj, out Coroutine runningCoroutine))
        {
            if (runningCoroutine != null)
            {
                StopCoroutine(runningCoroutine);
            }
        }

        ResetTransforms(parentObj);
        parentObj.SetActive(true);

        Transform[] allChildren = parentObj.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            child.gameObject.SetActive(true);
        }

        Animator[] animators = parentObj.GetComponentsInChildren<Animator>(true);
        foreach (Animator anim in animators)
        {
            anim.enabled = true;
            anim.Rebind();
            anim.Update(0f);
            anim.SetTrigger("Attack");
        }

        // Elindítjuk a 3 másodperces automatikus kikapcsoló időzítőt
        activeCoroutines[parentObj] = StartCoroutine(DisableAfterDelay(parentObj, 3f));
    }

    private void PlayTriggerAnimation(GameObject obj)
    {
        if (obj == null) return;

        if (activeCoroutines.TryGetValue(obj, out Coroutine runningCoroutine))
        {
            if (runningCoroutine != null)
            {
                StopCoroutine(runningCoroutine);
            }
        }

        ResetTransforms(obj);
        obj.SetActive(true);

        Transform[] allChildren = obj.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in allChildren)
        {
            child.gameObject.SetActive(true);
        }

        Animator anim = obj.GetComponent<Animator>();
        if (anim != null)
        {
            anim.enabled = true;
            anim.Rebind();
            anim.Update(0f);
            anim.SetTrigger("Trigger");
        }

        activeCoroutines[obj] = StartCoroutine(DisableAfterDelay(obj, 3f));
    }

    // Időzítő függvény: vár 'delay' másodpercet, majd kikapcsolja az objektumot
    private IEnumerator DisableAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (obj != null)
        {
            obj.SetActive(false);
        }
    }

    public void Ice() => PlayAttack(ice);
    public void Lightning() => PlayAttack(lightning);
    public void FireRain() => PlayAttack(fireRain);
    public void Burst() => PlayAttack(burst);
    public void Sword() => PlayAttack(sword);
    public void FireBall() => PlayAttack(fireBall);
    public void TheBlackArrow() => PlayAttack(theBlackArrow);
    public void FireShots() => PlayAttack(fireShots);
    public void ArrowRain() => PlayAttack(arrowRain);
    public void ArrowShot() => PlayAttack(arrowShot);

    public void Heal() => PlayTriggerAnimation(heal);
    public void MoreGold() => PlayTriggerAnimation(moreGold);
    public void DamageBoost() => PlayTriggerAnimation(damageBoost);
    public void LessDamage() => PlayTriggerAnimation(lessDamage);
    public void MoreXp() => PlayTriggerAnimation(moreXp);
    public void MoreTime() => PlayTriggerAnimation(moreTime);
    public void Hp() => PlayTriggerAnimation(hp);
    public void Water() => PlayTriggerAnimation(water);
    public void Oil() => PlayTriggerAnimation(oil);

    public void Shield()
    {
        shield.SetActive(true);
        NonAttacks.Shield = true;
        shield.GetComponent<NonAttacks>().Shieldd();
    }
}