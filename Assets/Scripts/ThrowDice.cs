using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;

public class ThrowDice : MonoBehaviour
{
    public GameObject dicePrefab;
    public Camera arCamera;
    public float throwForce = 5f;
    public TMP_Text resultDiceText;
    public ImageRecognition imageRecognition;
    public float timeDesableDice = 5;
    
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

        if (currentDice != null)
        {
            Dice diceScript = currentDice.GetComponent<Dice>();
            if (diceScript != null)
            {
                diceScript.SetThrowDiceScript(this);
            }
        }

        Rigidbody rb = currentDice.GetComponent<Rigidbody>();
        rb.AddForce(arCamera.transform.forward * throwForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * 10f, ForceMode.Impulse);

        StartCoroutine(ResetAfterDelay(timeDesableDice));
    }

    public void ReceiveDiceResult(int result)
    {
        if (resultDiceText != null)
        {
            resultDiceText.text = result.ToString();

            DiceDataManager.Instance.nbMob = result;

            // Transmet la valeur au script ImageRecognition
            // if (imageRecognition != null)
            // {
            //     imageRecognition.nbMob = result; // Assurez-vous que nbMob est un int dans ImageRecognition

            //     Debug.Log("nbMob correctement assigné à ImageRecognition : " + result);
            // }
            // else
            // {
            //     Debug.LogWarning("ImageRecognition n'est pas assigné dans l'inspecteur.");
            // }
        }
        else
        {
            Debug.LogWarning("resultDiceText n'est pas assigné dans l'inspecteur.");
        }

        if (currentDice != null)
        {
            Destroy(currentDice);
        }

        SceneManager.LoadScene("ShootARobjects");
    }

    IEnumerator ResetAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (currentDice != null)
        {
            Destroy(currentDice);
        }

        if (resultDiceText != null)
        {
           isTouching = false;
        }
    }
}
