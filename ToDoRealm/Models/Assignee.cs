using System;
using System.Linq;
using Realms;

namespace ToDoRealm.Models
{
    public class Assignee : RealmObject
    {
        public Assignee()
        {
            ToDoItems = Enumerable.Empty<ToDoItem>().AsQueryable();
        }

        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Role { get; set; }


        [Backlink(nameof(ToDoItem.Employee))]
        public IQueryable<ToDoItem> ToDoItems { get; }
    }
}
