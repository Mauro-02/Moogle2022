namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query) {
        Text text = new Text(query);          //Coge las palabras del query y las guarda
        string[] archivos = Directory.GetFiles("../Content", "*.txt");      //Guarda la ruta de cada archivo
        Document[] documentos= new Document[archivos.Length];
        for (int i = 0; i < archivos.Length; i++) 
        {
            documentos[i]=new Document(archivos[i]);
        }
        SearchItem[] items = new SearchItem[3] {
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.9f),
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.5f),
            new SearchItem("Hello World", "Lorem ipsum dolor sit amet", 0.1f),
        };

        return new SearchResult(items, query);
    }
}
