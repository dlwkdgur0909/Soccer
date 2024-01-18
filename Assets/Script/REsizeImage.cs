using UnityEngine;
using UnityEngine.UI;

public class ResizeImage : MonoBehaviour
{
    public Image imageToResize;
    public float maxSize = 2f; // �ִ� ũ��
    public float minSize = 0.5f; // �ּ� ũ��
    public float resizeSpeed = 1f; // ũ�� ��ȯ �ӵ�

    private bool isGrowing = true;

    void Update()
    {
        Resize();
    }

    void Resize()
    {
        float newSize = imageToResize.transform.localScale.x;

        if (isGrowing)
        {
            newSize += Time.deltaTime * resizeSpeed;
            if (newSize >= maxSize)
            {
                newSize = maxSize;
                isGrowing = false;
            }
        }
        else
        {
            newSize -= Time.deltaTime * resizeSpeed;
            if (newSize <= minSize)
            {
                newSize = minSize;
                isGrowing = true;
            }
        }

        imageToResize.transform.localScale = new Vector3(newSize, newSize, 1f);
    }
}
