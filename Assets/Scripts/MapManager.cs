using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public Transform player;          // Reference to the player in the 3D world
    public RectTransform playerPanel; // The 2D panel representing the player
    public Transform shipInterior;    // The ship's interior GameObject

    private Bounds shipBounds;        // Bounds of the ship



    private RawImage map;

    private void Start()
    {
        map = GetComponent<RawImage>();

        map.gameObject.SetActive(false);


        shipBounds = new Bounds(shipInterior.position, Vector3.zero);

        foreach (Renderer renderer in shipInterior.GetComponentsInChildren<Renderer>())
        {
            shipBounds.Encapsulate(renderer.bounds);
        }
    }


    private void Update()
    {
        UpdatePlayerPanelPosition();
    }

    //the math is off but the idea is the 2d panel would be the player
    private void UpdatePlayerPanelPosition()
    {
        // Get the player's position
        Vector3 playerPosition = player.position;

        // Normalize the player's position within the ship bounds
        float normalizedX = Mathf.Clamp01((playerPosition.x - shipBounds.min.x) / shipBounds.size.x);
        float normalizedY = Mathf.Clamp01((playerPosition.z - shipBounds.min.z) / shipBounds.size.z);

        // Convert normalized coordinates to map coordinates
        float mapX = normalizedX * map.rectTransform.rect.width - (map.rectTransform.rect.width / 2f);
        float mapY = normalizedY * map.rectTransform.rect.height - (map.rectTransform.rect.height / 2f);

        // Update the position of the player panel without affecting rotation
        Vector2 mapPosition = new Vector2(mapX, mapY);

        // Directly set anchoredPosition to ignore rotation (will only update position, not rotation)
        playerPanel.anchoredPosition = mapPosition;

        // Optional: if you want to make sure rotation is reset, you can explicitly set it to zero
        playerPanel.rotation = Quaternion.identity; // This will reset any rotation applied to the player panel
    }

    public void ToggleMap()
    {

        if (map.gameObject.activeSelf)
        {
            map.gameObject.SetActive(false); // If currently active, deactivate it
        }
        else
        {
            map.gameObject.SetActive(true); // If currently inactive, activate it
        }
    }

}
