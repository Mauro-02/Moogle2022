namespace MoogleEngine;
public class Document: Text
{
    private string Tittle;
    private string Snippet;
    private string Ruta;


    public Document (string Ruta) : base(){
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

        this.Tittle = Ruta.Split("/")[2]; //("/")[2];                   //le da a las rutas la forma ../Content/arch1.txt
        this.Snippet = texto.Length >= 100 ? texto.Substring(0, 100) : texto;            //si el texto tiene mas de 100 terminos devuelve solo esta cantidad sino me devuelve los que tengan
        this.Ruta = Ruta;
}
    }
