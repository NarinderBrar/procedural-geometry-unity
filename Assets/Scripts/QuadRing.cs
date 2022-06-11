using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadRing : MonoBehaviour
{
    [Range(0.01f, 2)]
    [SerializeField] float radiusInner;

    [Range(0.01f, 2)]
    [SerializeField] float thickness;

    float RadiusOuter => radiusInner + thickness;

    [Range(3, 256)]
    [SerializeField] int angularSegments = 3;

	private void OnDrawGizmos()
	{
        Gizmos.DrawWireSphere(transform.position, radiusInner);
        Gizmos.DrawWireSphere(transform.position, RadiusOuter);
    }

    const float TAU = 6.28318530718f;
    public static void DrawWireCircle(Vector3 pos, Quaternion rot, float radius, int detail = 32)
    {
        Vector2[] points3D = new Vector2[detail];

        for (int i = 0; i < detail; i++)
        {
            float t = i / (float) detail;
            float angleRad = t * TAU;

            Vector2 point2D = new Vector2(
                Mathf.Cos(angleRad) * radius,
                Mathf.Sin(angleRad) * radius
                );

            points3D[i] = pos+ rot * point2D;
        }

		for (int i = 0; i < detail; i++)
		{
            Gizmos.DrawSphere(points3D[i], 0.02f);
		}
       

    }

	void Start()
    {
        
    }


    void Update()
    {
        
    }
}
