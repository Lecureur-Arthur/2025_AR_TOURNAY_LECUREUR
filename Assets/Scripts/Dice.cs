using UnityEngine;

public class Dice : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private bool hasStopped = false;

    private Vector3[] faceNormals = new Vector3[]
    {
        Vector3.up,       // face 1
        Vector3.down,     // face 2
        Vector3.left,     // face 3
        Vector3.right,    // face 4
        Vector3.forward,  // face 5
        Vector3.back      // face 6
    };

    private void Update()
    {
        //Debug.Log("Update method called");
        if (!hasStopped && rb.IsSleeping())
        {
            hasStopped = true;
            int topFace = GetTopFace();
            Debug.Log("Face superieure : " + topFace);
        }
    }

    private int GetTopFace()
    {
        Debug.Log("GetTopFace method called");
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
}
