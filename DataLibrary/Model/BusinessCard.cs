using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlTestTableDataGenerator.DataLibrary
{
    /// <summary>
    /// The <c>BusinessCard</c> class is a POCO. It simulates some table in database (dbo.BusinessCard).
    /// </summary>
    public class BusinessCard
    {
        /// <value>Required, unique</value>
        public int CardId { get; set; }
        ///<value>Required, min length is 6, max length is 30, contains only Eng letters and digits</value>
        public string Title { get; set; }
        /// <value>Required, min length is 10, max length is 12, contains only digits</value>
        public string PhoneNumber { get; set; }
    }
}
