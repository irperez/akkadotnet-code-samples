using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickGraph;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace CoreLib
{
    [DebuggerDisplay("{Name}({EdgeCount})")]
    public class Category : Entity, IEdgeSet<Category, IEdge<Category>>, IEquatable<Category>
    {
        public Category():base() { }

        public Category(string name):base() 
        {
            this.Name = name;
        }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public string TagData { get; set; }

        protected IList<string> _tags;
        
        public IList<string> Tags
        {
            get
            {
                if (_tags == null && string.IsNullOrWhiteSpace(TagData) == false)
                {
                    _tags = new List<string>(TagData.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries));
                }

                return _tags;
            }
            set
            {
                _tags = value;

                var sb = new StringBuilder();
                var isFirst = true;
                foreach(string itm in _tags){
                    if (!isFirst)
                    {
                        sb.Append(",");
                    }
                    sb.Append(itm);                    
                }
            }
        }
        public CategoryType CategoryType { get; set; }



        public bool ContainsEdge(IEdge<Category> edge)
        {
            return this._edges.Contains(edge);
        }

        public IList<Category> Relationships { get; set; }

        [NotMapped]
        public int EdgeCount
        {
            get 
            {
                if (_edges == null || (_edges != null && _edges.Count() == 0))
                {
                    return 0;
                }
                else
                {
                    return _edges.Count();
                }
            }
        }


                internal List<IEdge<Category>> _edges;

        [NotMapped]
        public IEnumerable<IEdge<Category>> Edges
        {
            get
            {
                if (_edges == null)
                {
                    _edges = new List<IEdge<Category>>();
                }

                return _edges;
            }
            set
            {
                _edges = value.ToList();
            }
        }

        [NotMapped]
        public bool IsEdgesEmpty
        {
            get 
            {
                if (_edges == null || (_edges != null && _edges.Count() == 0))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        public bool Equals(Category other)
        {
            if (other == null)
            {
                return false;
            }

            if ((this.Id == 0 || other.Id == 0) && this.Name == other.Name)
            {
                return true;
            }
            else if (this.Id == other.Id)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Category) {
                return this.Equals((Category)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Id.ToString().GetHashCode();
        }

        public static bool operator ==(Category x, Category y)
        {
            // If both are null, or both are same instance, return true.
            if (System.Object.ReferenceEquals(x, y))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            // Return true if the fields match:
            return x.Equals(y);
        }

        public static bool operator !=(Category x, Category y)
        {
            return !(x == y);
        }
    }
}
