namespace MoogleEngine;

public class Text                                            //2 contructores
{
Dictionary<string,int> diccionario;

public Text()                                             
{
    diccionario=new Dictionary<string, int>();             //nuevo diccionario
}
public Text(string texto)
{
    diccionario=new Dictionary<string, int>();           //nuevo diccionario
    intoarray(texto);
}

protected string[] Tokenizar(string texto)
{
    string saux = texto.ToLower()
                .Replace('\n', ' ')
                .Replace('_', ' ')
                .Replace(',', ' ')
                .Replace('.', ' ')
                .Replace(';', ' ')
                .Replace('-', ' ')
                .Replace('/', ' ')
                .Replace('\\', ' ').Trim();

        return saux.Split(" ");
}
protected void intoarray(string texto){
    var aux =Tokenizar(texto);

        for (int i = 0; i < aux.Length; i++)               //comprobar si la palabra ya existe
        {
            if (aux[i].Trim() != "")            //A pesar de que ya en Tokenizar quite los " ", vuelvo a comprobar que no exista
            {
             if (this.diccionario.ContainsKey(aux[i]))      //si existe le sumo 1 a su TF
             {

                this.diccionario[aux[i]]++;

             }
             else
             {

                this.diccionario.Add(aux[i], 1);          // Sino, la agrego al diccionario y la inicio con TF == 1

             }
            }
        }
}

}