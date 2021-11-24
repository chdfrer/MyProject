using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlog.Areas.Database.Models
{
    public class DbInfoModel
    {
        public string DbName { get; set; }

        public string DataSource { get; set; }

        public bool CanConnect { get; set; }

        public List<String> AppliedMigrations { get; set; }

        public List<String> PendingMigrations { get; set; }

        public System.Data.DataRowCollection DataTableName { get; set; }
    }
}
