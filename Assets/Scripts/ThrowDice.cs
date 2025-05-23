using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class ThrowDice : MonoBehaviour
{
    public GameObject dicePrefab;
    public Camera arCamera;
    public float throwForce = 5f;

    public int timeDesableDice;

    private bool isTouching = false;
    private GameObject currentDice;

    void Update()
    {
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            if (!isTouching)
            {
                isTouching = true;
                Throw();
            }
        }
    }

    void Throw()
    {
        Vector3 spawnPos = arCamera.transform.position + arCamera.transform.forward * 0.5f;
        currentDice = Instantiate(dicePrefab, spawnPos, Random.rotation);
        Rigidbody rb = currentDice.GetComponent<Rigidbody>();
        rb.AddForce(arCamera.transform.forward * throwForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * 10f, ForceMode.Impulse);

        StartCoroutine(ResetAfterDelay(timeDesableDice));
    }

    IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (currentDice != null)
        {
            Destroy(currentDice);
        }

        isTouching = false;
    }
}
