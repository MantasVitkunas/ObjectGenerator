using System;
using System.Collections.Generic;

namespace ObjectGenerator.Models
{
    public class GeneratorModel
    {
        public class ObjectEntity
        {
            public string ObjectName { get; set; }
            public List<ObjectElement> ObjectElements { get; set; }
        }

        public class ObjectElement
        {
            public string ElementName { get; set; }
            public string ElementType { get; set; }
        }
    }
}
