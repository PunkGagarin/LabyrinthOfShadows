using System.Collections.Generic;
using UnityEngine;

public class EnemyPartsHighligher : MonoBehaviour, IHighlightable
{
    [SerializeField]
    private List<GameObject> _highlightElements;

    public void TurnOnHighlight()
    {
        foreach (var highlighGO in _highlightElements)
        {
            highlighGO.SetActive(true);
        }
    }

    public void TurnOffHighlight()
    {
        foreach (var highlighGO in _highlightElements)
        {
            highlighGO.SetActive(false);
        }
    }
}