using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomComponent.Models
{
    public class ComponentM
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        
        public bool BoolValue { get { return Convert.ToBoolean(Value); } set { Value = value.ToString(); } }
        
        
    }
}
