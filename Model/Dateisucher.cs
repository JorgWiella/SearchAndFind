using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ausbildungsprojekt_SW_01.Model
{
    public class Dateisucher
    {
        public string[] Suchen(string verzeichnis, string dateiendung)
        {
            return Directory.GetFiles(verzeichnis, $"*.{dateiendung}", SearchOption.AllDirectories);
        }
    }
}
