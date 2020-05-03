using System;
using System.Linq;
using Realms;

namespace ToDoRealm.Models
{
    public class Assignee : RealmObject
    {

        public string Name { get; set; }
        public string Role { get; set; }

        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Backlink(nameof(ToDoItem.Employee))]
        public IQueryable<ToDoItem> ToDoItems { get; }
    }
}
