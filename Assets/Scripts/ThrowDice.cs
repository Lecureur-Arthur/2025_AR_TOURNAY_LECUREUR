using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowDice : MonoBehaviour
{
    public GameObject dicePrefab;
    public Camera arCamera;
    public float throwForce = 5f;

    void Update()
    {
        // Debug.Log("Update method called");
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            Debug.Log("Touch detected (new Input System)");
            Throw();
        }
    }

    void Throw()
    {
        Vector3 spawnPos = arCamera.transform.position + arCamera.transform.forward * 0.5f;
        GameObject dice = Instantiate(dicePrefab, spawnPos, Random.rotation);
        Rigidbody rb = dice.GetComponent<Rigidbody>();
        rb.AddForce(arCamera.transform.forward * throwForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * 10f, ForceMode.Impulse);
    }
}
