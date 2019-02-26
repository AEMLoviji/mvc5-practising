using System.Collections.Generic;

namespace SchoolProject.Models
{
    public class TreeItem
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int? Order { get; set; }
        public int? ParentId { get; set; }
        public TreeItem Parent { get; set; }

        public virtual ICollection<TreeItem> Children { get; set; }

        public TreeItem()
        {
            Children = new List<TreeItem>();
        }
    }
}