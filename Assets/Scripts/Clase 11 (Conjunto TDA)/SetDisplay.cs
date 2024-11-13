using UnityEngine;
using TMPro;

public class SetDisplay : MonoBehaviour
{
    public TMP_Text setDisplayText;
    private ISetTDA<int> dynamicSet;
    private ISetTDA<int> staticSet;

    private void Start()
    {

        dynamicSet = new DynamicSet<int>();
        staticSet = new StaticSet<int>(10);

        dynamicSet.Add(1);
        dynamicSet.Add(2);
        dynamicSet.Add(3);

        staticSet.Add(2);
        staticSet.Add(3);
        staticSet.Add(4);

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {

        string dynamicSetText = "Dynamic Set: " + dynamicSet.Show();
        string staticSetText = "Static Set: " + staticSet.Show();
        string unionSetText = "Union: " + dynamicSet.Union(staticSet).Show();
        string intersectSetText = "Intersect: " + dynamicSet.Intersect(staticSet).Show();
        string differenceSetText = "Difference: " + dynamicSet.Difference(staticSet).Show();

        setDisplayText.text = $"{dynamicSetText}\n{staticSetText}\n{unionSetText}\n{intersectSetText}\n{differenceSetText}";
    }
}

