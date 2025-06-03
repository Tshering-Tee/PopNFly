using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketManager : MonoBehaviour
{
    // when ball enters a ring
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the BasketParent (parent of this object) is the 3rd child of BasketHolder
        if (transform.parent.GetSiblingIndex() == 2)
        {
            var parent = transform.parent.transform.parent;
            MoveAndRepeat(parent, 2);
        }
    }

    // shift the position of first and second child to end.
    void MoveAndRepeat(Transform parent, int times)
    {
        for (int i = 0; i < times; i++)
        {
            Transform first = parent.GetChild(0);
            Transform last = parent.GetChild(parent.childCount - 1);

            float newY = Random.Range(0.0f, 2.0f);
            Vector3 newPos = new Vector3(last.position.x + 4f, newY, transform.position.z);

            first.position = newPos;

            var boxCollider = first.GetComponent<BoxCollider2D>();
            if (boxCollider != null && !boxCollider.enabled)
            {
                boxCollider.enabled = true;
            }

            var childColliders = first.GetComponentsInChildren<Collider2D>(includeInactive: true);
            foreach (var col in childColliders)
            {
                if (!col.enabled)
                    col.enabled = true;
            }

            first.SetAsLastSibling();
        }
    }
}