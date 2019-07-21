using System;
using PropertyChanged;
using Realms;

namespace ToDoRealm.Models
{
    [DoNotNotify]
    public class ToDoItem : RealmObject
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}