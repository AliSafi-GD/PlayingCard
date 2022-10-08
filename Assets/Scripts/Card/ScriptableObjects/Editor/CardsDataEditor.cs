using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardsData))]
public class CardsDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var trg = ((CardsData)target);
        if (GUILayout.Button("Create New Cards"))
        {
            trg.cards.Clear();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 13; j++)
                {
                    var localSymbol = (PublicMethod.Symbol)(i + 1);
                    trg.cards.Add(new ECard(localSymbol.ToString()+" "+(j+1),j + 1,j,localSymbol));
                }
            }
            
            trg.cards.Add(new ECard(PublicMethod.Symbol.Joker.ToString()+" 14", 14,14, (PublicMethod.Symbol.Joker)));
            trg.cards.Add(new ECard(PublicMethod.Symbol.Joker.ToString()+" 15",15,15, (PublicMethod.Symbol.Joker)));
        }
    }
}
