
using UnityEngine;

[System.Serializable]
public class ECard
{
    [SerializeField] private string name;
    public int number;
    public int score;
    public PublicMethod.Symbol symbol;

    public ECard(int number,int score, PublicMethod.Symbol symbol)
    {
        this.number = number;
        this.score = score;
        this.symbol = symbol;
    }
    public ECard(string name,int number,int score, PublicMethod.Symbol symbol)
    {
        this.name = name;
        this.score = score;
        this.number = number;
        this.symbol = symbol;
    }
}
