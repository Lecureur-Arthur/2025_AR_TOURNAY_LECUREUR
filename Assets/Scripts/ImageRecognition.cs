using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ImageRecognitionExample : MonoBehaviour
{
    private ARTrackedImageManager _aRTrackedImageManager;

    private void Awake()
    {
        _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        _aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            Debug.Log($"Image added: {trackedImage.referenceImage.name}");
            // Handle the added image
        }

        foreach (var trackedImage in args.updated)
        {
            Debug.Log($"Image updated: {trackedImage.referenceImage.name}");
            // Handle the updated image
        }

        foreach (var trackedImage in args.removed)
        {
            Debug.Log($"Image removed: {trackedImage.referenceImage.name}");
            // Handle the removed image
        }
    }

}
