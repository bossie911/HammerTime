using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerScript : MonoBehaviour
{
    public static HammerScript instance;

    [SerializeField] private GameObject Explosion;
    [SerializeField] private GameObject UIObject;
    [SerializeField] private float delay;

    private JoystickPlayerExample playerController;

    private float timer;

    public bool isActive;
    public float hammerTime;
    [SerializeField] private AnimationsScript animations;
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        playerController = GetComponentInParent<JoystickPlayerExample>();
        gameObject.SetActive(false);
        UIObject.SetActive(false);
        animations.GetComponent<AnimationsScript>();
    }
    private void FixedUpdate()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
        }
    }
    private IEnumerator HammerSmash()
    {
        if (isActive)
        {
            Instantiate(Explosion, transform.position + playerController.GetDirection() / 2, transform.rotation);
            
            if (timer > hammerTime)
            {
                animations.smash = false;
                timer = 0;
                hammerTime = 0;
                isActive = false;
                UIObject.SetActive(false);
                gameObject.SetActive(false);
                GameEvents.current.StartChasing();
            }
            else
            {
                yield return new WaitForSeconds(delay);
                StartCoroutine(HammerSmash());
            }
        }
        yield return null;
    }
    public void StartHammering()
    {
        animations.smash = true;
        isActive = true;
        gameObject.SetActive(true);
        UIObject.SetActive(true);
        StartCoroutine(HammerSmash());
    }
    public float GetTimeLeft()
    {
        return hammerTime - timer;
    }
}