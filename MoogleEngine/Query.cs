namespace MoogleEngine;

public class Query
{
    private Dictionary<string,int> querydictionary= new Dictionary<string, int>();

    public Query (string query){
        FillQueryDictionary(query);
    }
    
    protected void FillQueryDictionary(string query)
    {
        var Token=query.ToLower()
                .Replace('\n', ' ')
                .Replace('_', ' ')
                .Replace(',', ' ')
                .Replace('.', ' ')
                .Replace(';', ' ')
                .Replace('-', ' ')
                .Replace('/', ' ')
                .Replace('\\', ' ').Trim().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                for (int i=0;i<Token.Length;i++)
                {
                    if (this.querydictionary.ContainsKey(Token[i]))      //si la tiene le sumo 1 a su TF(frecuencia absoluta)
            {
                this.querydictionary[Token[i]]++;
            }
         else
            {
                this.querydictionary.Add(Token[i], 1);          // agrego una intancia de la palabra con TF == 1
            }
                }
    }

    public float QueryTf(string word)
    {
        if (this.querydictionary.ContainsKey(word))
        {
            return (float)this.querydictionary[word]/(float)this.querydictionary.Count;
        }
        return 0f;
    }

    public Dictionary<string, int> Querydictionary          
    {
      get
        {
            return querydictionary ;
        }
    }
}