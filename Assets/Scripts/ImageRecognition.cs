using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour
{
    public GameObject gameObjectToInstantiate;
    public ARTrackedImageManager _aRTrackedImageManager;
    public int nbMob;
    private bool hasSpawned = false;

    void OnEnable()
    {
        _aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
        Debug.Log("ok");
    }

    private void OnDisable()
    {
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
        Debug.Log("nok");
    }

    void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        // Debug.Log("test");
        foreach (var trackedImage in args.added)
        {
            Debug.Log($"Image added: {trackedImage.referenceImage.name}");
            // Handle the added image
            
        }

        foreach (var trackedImage in args.updated)
        {
            Debug.Log($"Image updated: {trackedImage.referenceImage.name}");
            // Handle the updated image
            if (!hasSpawned && trackedImage.trackingState == TrackingState.Tracking)
            {
                SpawnObjectsOnImage(trackedImage);
                hasSpawned = true;
            }
        }

        foreach (var trackedImage in args.removed)
        {
            Debug.Log($"Image removed: {trackedImage.referenceImage.name}");
            // Handle the removed image
        }
    }

    private void SpawnObjectsOnImage(ARTrackedImage trackedImage)
    {
        Transform imageTransform = trackedImage.transform;

        // Calcul du placement centré sur l'image
        float spacing = 0.5f; // espacement en mètres
        float totalWidth = (nbMob - 1) * spacing;
        Vector3 startLocalPos = -Vector3.right * (totalWidth / 2f); // alignement horizontal local

        for (int i = 0; i < nbMob; i++)
        {
            Vector3 localOffset = startLocalPos + Vector3.right * (i * spacing);
            Vector3 worldPosition = imageTransform.TransformPoint(localOffset); // convertit en monde

            // Tourner les objets de 180° sur Y par rapport à l'image
            Quaternion worldRotation = imageTransform.rotation;

            GameObject obj = Instantiate(gameObjectToInstantiate, worldPosition, worldRotation);
            // obj.transform.SetParent(trackedImage.transform);
        }

        Debug.Log($"{nbMob} objets instanciés sur l’image '{trackedImage.referenceImage.name}'.");
    }
}
