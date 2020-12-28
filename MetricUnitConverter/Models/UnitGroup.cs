using System;
using System.Collections.Generic;

namespace MetricUnitConverter.Models
{
    public class UnitGroup : List<Unit>
    {
        public UnitGroup(string groupName)
        {
            GroupName = groupName ?? throw new ArgumentNullException(nameof(groupName));
        }
        public string GroupName { get; set; }
    }
}