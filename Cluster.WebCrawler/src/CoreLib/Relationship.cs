//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using QuickGraph;
//using System.Diagnostics;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace CoreLib
//{
//    [DebuggerDisplay("{Source}->{Target}")]
//    public class Relationship : IEdge<Category>, IEquatable<IEdge<Category>>
//    {
//        public Relationship() { }
//        public Relationship(Category source, Category target)
//        {
//            this.Source = source;
//            this.Target = target;
//        }

//        [ForeignKey("Source")]
//        [Required]
//        [Column(Order=1)]
//        public long SourceId { get; set; }
//                {
//                    value.Edges.Count();

//        private Category _source;
//        public Category Source {
//            get
//            {
//                return _source;
//            }
//            set 
//            {
//                _source = value;
//                if (value != null)
//                {                    
//                    value._edges.Add(this);
//                    this.SourceId = value.Id;
//                }
//                else
//                {
//                    this.SourceId = 0;
//                }
//            }
//        }

//        [ForeignKey("Target")]
//        [Required]
//        [Column(Order = 2)]
//        public long TargetId { get; set; }

//        private Category _target;
//        public Category Target {
//            get 
//            {
//                return _target;
//            }
//            set 
//            {
//                _target = value;
//                if (value != null)
//                {
//                      value.Edges.Count();
//                      value._edges.Add(this);
//                    this.TargetId = value.Id;
//                }
//                else
//                {
//                    this.TargetId = 0;
//                }
//            }
//        }

//        public bool Equals(IEdge<Category> other)
//        {
//            if (other == null)
//            {
//                return false;
//            }

//            if (this.SourceId == other.Source.Id && this.TargetId == other.Target.Id)
//            {
//                return true;
//            }
//            else
//            {
//                return false;
//            }
//        }

//        public override bool Equals(object obj)
//        {
//            if (obj is IEdge<Category>)
//            {
//                return this.Equals((IEdge<Category>)obj);
//            }else{
//                return false;
//            }
//        }

//        public override int GetHashCode()
//        {
//            return (this.SourceId.ToString() + this.TargetId.ToString()).GetHashCode();
//        }

//        public static bool operator ==(Relationship x, Relationship y)
//        {
//            // If both are null, or both are same instance, return true.
//            if (System.Object.ReferenceEquals(x, y))
//            {
//                return true;
//            }

//            // If one is null, but not both, return false.
//            if (((object)x == null) || ((object)y == null))
//            {
//                return false;
//            }

//            // Return true if the fields match:
//            return x.Equals(y);
//        }

//        public static bool operator !=(Relationship x, Relationship y)
//        {
//            return !(x == y);
//        }
//    }
//}
