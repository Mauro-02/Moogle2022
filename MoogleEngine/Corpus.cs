namespace MoogleEngine;

public class Corpus
{
    private Document[] docs;
    private string[] files;
    private float[,] tfidfmatrix;
    private Query query;

    private string inputquery;
    private Dictionary<string, int> vocabulary = new Dictionary<string, int>(); 

    public Corpus(string path, string filext, string inputquery)
    {
        this.files=Directory.GetFiles(path,filext);
        this.docs= new Document[files.Length];
        this.inputquery=inputquery;
    }

    public void ProcessDocs()
    {
        for (int i = 0;i<files.Length; i++)
        {
            this.docs[i]=new Document(files[i]);
        }
    }

    public void ProcessQuery()
    {
        query=new Query(this.inputquery);
    }

    public void FillVocabulary()
    {
for(int i = 0; i<docs.Length; i++)
{
    foreach(var item in docs[i].Docsdictionary.Keys)
    {
        if(vocabulary.ContainsKey(item))
        {
            vocabulary[item]++;
        }
        else
        {
            vocabulary.Add(item,1);
        }
    }
}
    }
     public float GetScore(int docnumber)         // da el peso de cada palabra de la Query en los documentos(score)
    {

        float peso = 0f;
        float[] vector = new float[vocabulary.Count]; 
        int index = 0;

        foreach (var aux in vocabulary.Keys)                                       // calcula TF-IDF de la query
        {
            vector[index++] = query.QueryTf(aux) * (float)Math.Log10((float)docs.Length / (float)vocabulary[aux]);
        }

        for (int i = 0; i < vocabulary.Count; i++)                                // distancia coseno
        {
            peso += tfidfmatrix[docnumber, i] * vector[i];
        }
        return peso;
    }


    public List<SearchItem> ProcessScore(){
         List<SearchItem> si = new List<SearchItem>();
        float score=0f;

        for(int i=0; i<docs.Length;i++)
        {
            score=GetScore(i);
            if(score>0) si.Add(new SearchItem(docs[i].TextTittle,docs[i].TextSnippet, score));
        }
        return si;
    }
    public void FillTFIDFMatrix()
    {

        tfidfmatrix = new float[docs.Length, vocabulary.Count];  // filas=Docs, Col= Palabras

        for (int i = 0; i < docs.Length; i++)
        {
            int index = 0;
            foreach (var aux in vocabulary.Keys)                    // calcula TF-IDF dcada palabra en el vocabulario
            {
                tfidfmatrix [i, index++] = Docs[i].GetTF(aux) * (float)Math.Log10((float)docs.Length / (float)vocabulary[aux]);
                
            }
        }
      
    }

    public Document[] Docs           
    {
        get
        {
            return docs;
        }
    }

} 