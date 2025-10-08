using System;
using System.Globalization;

namespace ExtensionMethod.Extensions
{
    //classe que extende para o program semelhante à herança
    static class DateTimeExtensions
    {
        //função criada para calcular duração de tempo a partir do momento atual
        public static string ElapsedTime(this DateTime thisObj)
        {
            //Objeto auxiliar para logica de ElapsedTime(duração do tempo)
            TimeSpan duration = DateTime.Now - thisObj;

            if (duration.TotalHours < 24.0)
            {
                return duration.TotalHours.ToString("F1", CultureInfo.InvariantCulture) + " hours";
            }
            else 
            {
                return duration.TotalDays.ToString("F1", CultureInfo.InvariantCulture) + " days";
            }
        }
    }
}
