using UnityEngine;

public class MonsterZoneHighlighter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var highlightable = other.GetComponent<IHighlightable>();
            highlightable.TurnOnHighlight();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var highlightable = other.GetComponent<IHighlightable>();
            highlightable.TurnOffHighlight();
        }
    }
}