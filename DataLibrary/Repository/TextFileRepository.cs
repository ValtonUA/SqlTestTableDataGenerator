using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.DataLibrary
{
    public class TextFileRepository : ITextFileRepository
    {
        public List<string> GenerateList(
            string filename,
            Func<char, bool> handleCondition,
            Func<string, bool> addCondition,
            bool isUnique = false)
        {
            List<string> result = new List<string>();
            string property;
            char symbol;

            using (StreamReader reader = new StreamReader(filename))
            {
                while (reader.EndOfStream == false)
                {
                    property = "";
                    // Skip other symbols
                    while (handleCondition(symbol = (char)reader.Read()) == false &&
                           reader.EndOfStream == false) { }
                    if (reader.EndOfStream)
                    {
                        break;
                    }
                    // Add letters and digits
                    property += symbol;
                    while (handleCondition(symbol = (char)reader.Read()) &&
                           reader.EndOfStream == false)
                    { 
                        property += symbol;
                    }
                    // Decide whether should we add a property to a result list
                    if (isUnique)
                    {
                        if (addCondition(property) && result.Count(i => i.Equals(property)) == 0)
                        {
                            result.Add(property);
                        }

                    }
                    else if (addCondition(property))
                    {
                        result.Add(property);
                    }
                }

                return result;
            }
        }
    }
}
