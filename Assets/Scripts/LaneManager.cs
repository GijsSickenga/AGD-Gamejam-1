using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneManager : MonoBehaviour
{
    public GameObject _lanePrefab;

    public int _numberOfLanes = 3;
    private List<GameObject> _lanes = new List<GameObject>();

    public Vector3 LaneScale
    {
        get
        {
            Vector3 laneScale = new Vector3(PixelToUnit(Screen.currentResolution.width), 1, 1);
            laneScale.y = PixelToUnit(Screen.currentResolution.height) / _lanes.Count;
            return laneScale;
        }
    }

    private void Start()
    {
        // RegenerateLanes();
    }

    private void Update()
    {
        
    }

    /// <summary>
    /// Converts a given screen pixel count into unity scene units.
    /// </summary>
    /// <param name="pixelCount">The amount of pixels to get the unity scene unit size for.</param>
    /// <returns>The size in unity units the given screen pixel count represents.</returns>
    public float PixelToUnit(float pixelCount)
    {
        return Camera.main.GetComponent<Camera>().orthographicSize * 2f / (float)Screen.currentResolution.height * (float)pixelCount;
    }

    /// <summary>
    /// Regenerate all lanes with current settings.
    /// </summary>
    public void RegenerateLanes()
    {
        CreateLanes();
        ResizeLanes();
        AlignLanes();
    }

    /// <summary>
    /// Create new lanes.
    /// </summary>
    private void CreateLanes()
    {
        // Destroy old lanes.
        foreach (GameObject lane in _lanes)
        {
            Destroy(lane);
        }

        // Clear lanes list.
        _lanes.Clear();

        // Regenerate lanes.
        for (int i = 0; i < _numberOfLanes; i++)
        {
            _lanes.Add(Instantiate(_lanePrefab, transform));
        }
    }

    /// <summary>
    /// Resize the lanes so they divide up the full screen space together.
    /// </summary>
    private void ResizeLanes()
    {
        // Calculate new lane scale for each lane.
        foreach (GameObject lane in _lanes)
        {
            // Apply new scale to lane.
            lane.transform.localScale = Vector3.Scale(lane.transform.localScale, LaneScale);
        }
    }

    /// <summary>
    /// Move the lanes so they are aligned across the width of the screen.
    /// </summary>
    private void AlignLanes()
    {
        // Loop over all lanes and align them sequentially.
        for (int i = 0; i < _lanes.Count; i++)
        {
            // Calculate where the lane should be positioned.
            Vector3 newPosition = Vector3.zero;
            // Offset lane by half of screen width, and move to correct position in sequence of lanes.
            newPosition.y = i * _lanes[i].transform.lossyScale.y + (_lanes[i].transform.lossyScale.y / 2) - PixelToUnit(Screen.currentResolution.height / 2f);

            // Assign new position to lane.
            _lanes[i].transform.position = newPosition;

            // Generate lane color.
            float val = (i % 2 == 0) ? 1.0f : 0.6f;
            Color laneColor = Color.HSVToRGB(0, 1, val);
            laneColor.a = 0.2f;

            // Assign color to lane.
            _lanes[i].GetComponent<SpriteRenderer>().color = laneColor;
        }
    }
}
