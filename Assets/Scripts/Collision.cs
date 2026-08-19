using UnityEngine;

public class UICollision : MonoBehaviour
{
    public Damaging damaging;

    private RectTransform myRect;
    private bool isHandled = false;

    void Awake()
    {
        myRect = GetComponent<RectTransform>();
    }

    void OnEnable()
    {
        isHandled = false;
    }

    void Update()
    {
        if (isHandled) return;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            RectTransform enemyRect = enemy.GetComponent<RectTransform>();
            Animator enemyAnimator = enemy.GetComponent<Animator>();

            if (enemyRect != null && IsOverlapping(myRect, enemyRect))
            {
                isHandled = true;

                if (damaging != null)
                {
                    damaging.Damage();
                    Debug.Log("Damage");
                }

                gameObject.SetActive(false);
                return;
            }
        }
    }

    private bool IsOverlapping(RectTransform rect1, RectTransform rect2)
    {
        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];

        rect1.GetWorldCorners(corners1);
        rect2.GetWorldCorners(corners2);

        float minX1 = Mathf.Min(corners1[0].x, corners1[1].x, corners1[2].x, corners1[3].x);
        float maxX1 = Mathf.Max(corners1[0].x, corners1[1].x, corners1[2].x, corners1[3].x);
        float minY1 = Mathf.Min(corners1[0].y, corners1[1].y, corners1[2].y, corners1[3].y);
        float maxY1 = Mathf.Max(corners1[0].y, corners1[1].y, corners1[2].y, corners1[3].y);

        float minX2 = Mathf.Min(corners2[0].x, corners2[1].x, corners2[2].x, corners2[3].x);
        float maxX2 = Mathf.Max(corners2[0].x, corners2[1].x, corners2[2].x, corners2[3].x);
        float minY2 = Mathf.Min(corners2[0].y, corners2[1].y, corners2[2].y, corners2[3].y);
        float maxY2 = Mathf.Max(corners2[0].y, corners2[1].y, corners2[2].y, corners2[3].y);

        Rect r1 = Rect.MinMaxRect(minX1, minY1, maxX1, maxY1);
        Rect r2 = Rect.MinMaxRect(minX2, minY2, maxX2, maxY2);

        return r1.Overlaps(r2);
    }
}