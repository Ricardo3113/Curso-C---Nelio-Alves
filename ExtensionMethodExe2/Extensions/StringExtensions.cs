//não precisa colocar using System, porque a classe que extende para o Main é do tipo string e faz parte do system
namespace System
{
    static class StringExtensions
    {
        //metodo que retorna um string recebendo como argumento objeto string do tipo obj com uma posição int (onde cortar)como parametro
        public static string Cut(this string thisObj, int count) 
        {
            //teste para ver se o string original for menor que o count não precisa cortar, então retorna o próprio thisobj
            if (thisObj.Length <= count)
            {
                return thisObj;
            }
            //senão recorta o string 
            else
            {
                return thisObj.Substring(0, count) + "...";
            }           
        }
    }
}
