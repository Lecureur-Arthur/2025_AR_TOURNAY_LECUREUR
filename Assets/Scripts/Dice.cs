using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private bool hasStopped = false;
    private ThrowDice throwDiceScript;
    private Vector3[] faceNormals = new Vector3[]
    {
        Vector3.forward,    // face 1
        Vector3.up,         // face 2
        Vector3.left,       // face 3
        Vector3.right,      // face 4
        Vector3.down,       // face 5
        Vector3.back        // face 6
    };

    private void Update()
    {
        if (!hasStopped && rb.IsSleeping())
        {
            hasStopped = true;
            int topFace = GetTopFace();
            Debug.Log("Face supérieure : " + topFace);

            // Envoie le résultat au script ThrowDice
            if (throwDiceScript != null)
            {
                throwDiceScript.ReceiveDiceResult(topFace);
            }
            else
            {
                Debug.LogWarning("Le script ThrowDice n'est pas assigné.");
            }
        }
    }

    private int GetTopFace()
    {
        Vector3 worldUp = Vector3.up;
        float maxDot = -Mathf.Infinity;
        int topFace = -1;

        for (int i = 0; i < faceNormals.Length; i++)
        {
            Vector3 worldNormal = transform.TransformDirection(faceNormals[i]);
            float dot = Vector3.Dot(worldNormal, worldUp);

            if (dot > maxDot)
            {
                maxDot = dot;
                topFace = i + 1;
            }
        }
        return topFace;
    }

    public void SetThrowDiceScript(ThrowDice script)
    {
        throwDiceScript = script;
    }
}
