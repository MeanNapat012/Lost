using System.Collections.Generic;
using UnityEngine;

public class VoronoiGenerator : MonoBehaviour
{
    public int pointCount = 10;
    public GameObject voronoiPrefab;
    public GameObject roomStartPrefab;
    public GameObject roomEndPrefab;
    public List<Vector2> points = new List<Vector2>();
    public GameObject bounds;

    void Start()
    {
        // สร้าง Prefab ของ roomstart และ roomend
        GameObject roomStart = Instantiate(roomStartPrefab, new Vector2(0, 0), Quaternion.identity);
        GameObject roomEnd = Instantiate(roomEndPrefab, new Vector2(0, 0), Quaternion.identity);

        // สุ่มจุด Voronoi
        GenerateVoronoiPoints(pointCount);

        // สร้าง Prefab ของ Voronoi
        InstantiateVoronoi();

        // เพิ่ม roomstart และ roomend เข้าไปใน List ของ points
        points.Insert(0, new Vector2(roomStart.transform.position.x, roomStart.transform.position.y));
        points.Add(new Vector2(roomEnd.transform.position.x, roomEnd.transform.position.y));
    }

    // ฟังก์ชันสุ่มจุด Voronoi
    void GenerateVoronoiPoints(int count)
    {
        for (int i = 0; i < count; i++)
        {
            bool valid = false;
            Vector2 point = Vector2.zero;

            while (!valid)
            {
                // สุ่มตำแหน่งใหม่ของจุด Voronoi
                float x = Random.Range(bounds.transform.position.x - bounds.transform.localScale.x / 2, bounds.transform.position.x + bounds.transform.localScale.x / 2);
                float y = Random.Range(bounds.transform.position.y - bounds.transform.localScale.y / 2, bounds.transform.position.y + bounds.transform.localScale.y / 2);
                point = new Vector2(x, y);

                valid = true;

                // ตรวจสอบระยะห่างระหว่างจุด
                foreach (Vector2 p in points)
                {
                    if (Vector2.Distance(point, p) < 30f)
                    {
                        valid = false;
                        break;
                    }
                }
            }

            points.Add(point);
        }
    }

    // ฟังก์ชันสร้าง Prefab ของ Voronoi
    void InstantiateVoronoi()
    {
        foreach (Vector2 point in points)
        {
            GameObject voronoi = Instantiate(voronoiPrefab, point, Quaternion.identity);
            voronoi.transform.parent = transform;
        }
    }
}
