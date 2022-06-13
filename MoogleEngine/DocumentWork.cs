namespace MoogleEngine;
public class Document
{
   private Dictionary<string, int> docsdictionary = new Dictionary<string, int>();
    private string textTittle;
    private string textSnippet;
    private string textRuta;


    public Document (string Ruta){
        StreamReader read= new StreamReader(Ruta);
        string texto;
try
 {
    texto=read.ReadToEnd().ToLower();   //Guarda el contenido del documento en un sting
    read.Close();

}
  catch (EndOfStreamException error)
        {

            throw new Exception("Error");

        }

FillDictionary(texto);

        this.textTittle = Ruta.Substring(Ruta.LastIndexOf("/")+1);                   //le da a las rutas la forma ../Content/arch1.txt
        this.textSnippet = texto.Length >= 100 ? texto.Substring(0, 100) : texto;            //si el texto tiene mas de 100 terminos devuelve solo esta cantidad sino me devuelve los que tengan
        this.textRuta = Ruta;
}

protected string[] Tokenizar(string texto)
{
    string aux = texto.ToLower()
                .Replace('\n', ' ')
                .Replace('_', ' ')
                .Replace(',', ' ')
                .Replace('.', ' ')
                .Replace(';', ' ')
                .Replace('-', ' ')
                .Replace('/', ' ')
                .Replace('\\', ' ').Trim();

        return aux.Split(" ",StringSplitOptions.RemoveEmptyEntries);
}
protected void FillDictionary(string texto){
    var aux =Tokenizar(texto);

        for (int i = 0; i < aux.Length; i++)               //comprobar si la palabra ya existe
        {
            
             if (this.docsdictionary.ContainsKey(aux[i]))      //si existe le sumo 1 a su TF
             {

                this.docsdictionary[aux[i]]++;

             }
             else
             {

                this.docsdictionary.Add(aux[i], 1);          // Sino, la agrego al diccionario y la inicio con TF == 1

             }
            
        }
}
   public Dictionary<string, int> Docsdictionary          
    {
        get
        {
            return docsdictionary ;
        }
    }

    public float GetTF(string palabra)                 //devuelve la frecuencia de un termino en especific`o
    {
        if (this.docsdictionary.ContainsKey(palabra))      //si lo tiene
        {

            return (float)this.docsdictionary[palabra]/(float)this.docsdictionary.Count;           //develvo su TF. ****Esta division no estaba , solo devolvia la cant de veces de la palabra en el documento
        

        }
        return 0f;                                       //en otro caso devuelvo 0

    }
      public string TextTittle
    {
      get
        {
            return this.TextTittle ;
        }
    }
     
public string TextSnippet
    {
      get
        {
            return this.textSnippet ;
        }
    }
    public string TextRuta
    {
      get
        {
            return this.TextRuta ;
        }
    }
    }
