// using UnityEngine;

// [ExecuteInEditMode]
// public class CurvedCanvas : MonoBehaviour
// {
//     public float curvature = 0.5f;
//     public float radius = 5f;
//     public float height = 2f;

//     private void Update()
//     {
//         float z = radius / curvature;
//         float circumference = 2f * Mathf.PI * radius;
//         float degreesPerSegment = 360f / (circumference / 10f);
//         float angle = degreesPerSegment / 2f;

//         for (int i = 0; i < transform.childCount; i++)
//         {
//             Transform child = transform.GetChild(i);
//             RectTransform childRect = child.GetComponent<RectTransform>();

//             float x = Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
//             float y = Mathf.Cos(angle * Mathf.Deg2Rad) * radius - radius / curvature;
//             float zOffset = height / 2f;

//             childRect.localPosition = new Vector3(x, y, -zOffset);
//             childRect.localRotation = Quaternion.Euler(0f, 0f, -angle);

//             angle += degreesPerSegment;
//         }

//         RectTransform parentRect = GetComponent<RectTransform>();
//         parentRect.sizeDelta = new Vector2(circumference, height);
//     }
// }
