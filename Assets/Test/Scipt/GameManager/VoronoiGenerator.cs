using System.Collections.Generic;
using UnityEngine;

public class VoronoiGenerator : MonoBehaviour
{
    public int pointCount = 10;
    public float distanceThreshold = 50f;
    public GameObject roomStartPrefab;
    public GameObject roomPrefab;
    public GameObject roomEndPrefab;
    public GameObject area;
    public GameObject player;
    public int VoronoiCount = 0;
    private int RoomCount = 0;
    //private PlayerWin playerWin;

    private List<Vector2> points = new List<Vector2>();

    private void Start()
    {
        GenerateVoronoiPoints(pointCount, distanceThreshold);
        Vector2 roomStart = points[0];
        Vector2 roomEnd = FindFarthestPoint(roomStart);
        SpawnRooms(roomStart, roomEnd);
        Vector3 playerStartPosition = new Vector3(roomStart.x, roomStart.y, 0);
        player.transform.position = playerStartPosition;
        //playerWin = player.GetComponent<PlayerWin>();
        /*if (playerWin == null)
        {
            Debug.LogError("PlayerWin component not found.");
        }*/
        

    }

    private void GenerateVoronoiPoints(int count, float threshold)
    {
        for (int i = 0; i < count; i++)
        {
            Vector2 newPoint = new Vector2(
                Random.Range(area.transform.position.x - area.transform.localScale.x / 2, area.transform.position.x + area.transform.localScale.x / 2),
                Random.Range(area.transform.position.y - area.transform.localScale.y / 2, area.transform.position.y + area.transform.localScale.y / 2)
            );
            bool validPoint = true;
            foreach (Vector2 existingPoint in points)
            {
                if (Vector2.Distance(newPoint, existingPoint) < threshold)
                {
                    validPoint = false;
                    break;
                }
            }
            if (validPoint)
            {
                points.Add(newPoint);
                VoronoiCount++;
            }
        }
    }

    private Vector2 FindFarthestPoint(Vector2 referencePoint)
    {
        Vector2 farthestPoint = Vector2.zero;
        float farthestDistance = 0f;
        foreach (Vector2 point in points)
        {
            float distance = Vector2.Distance(point, referencePoint);
            if (distance > farthestDistance)
            {
                farthestDistance = distance;
                farthestPoint = point;
            }
        }
        return farthestPoint;
    }

    private void SpawnRooms(Vector2 roomStart, Vector2 roomEnd)
    {
        for (int i = 0; i < points.Count; i++)
        {
            if (points[i] == roomStart)
            {
                Instantiate(roomStartPrefab, new Vector3(points[i].x, points[i].y, 0), Quaternion.identity);
            }
            else if (points[i] == roomEnd)
            {
                Instantiate(roomEndPrefab, new Vector3(points[i].x, points[i].y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(roomPrefab, new Vector3(points[i].x, points[i].y, 0), Quaternion.identity);
            }
        }
    }
    
    void Update()
    {
        /*RoomCount = VoronoiCount;
        if (playerWin != null)
        {
            playerWin.Numroom(RoomCount);
            playerWin.AllroomInScene(RoomCount);
        }*/
    }

}