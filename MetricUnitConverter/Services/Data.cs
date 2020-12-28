using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using MetricUnitConverter.Models;

namespace MetricUnitConverter.Services
{
    public class Data
    {
        private List<UnitGroup> _group;
        public List<UnitGroup> Group
        {
            get
            {
                if (_group == null || _group.Count==0)
                    _group = GenerateData();
                return _group;
            }
        }

        public List<UnitGroup> GenerateData()
        {
            List<UnitGroup> localgroup = new List<UnitGroup>()
            {
                new UnitGroup("Weight")
                {
                    new Unit("t", "ton", 1000),
                    new Unit("kg", "centigram", 1),
                    new Unit("dg", "decigram", 0.1),
                    new Unit("cg", "centigram", 0.01),
                    new Unit("mg", "milligram", 0.001)
                },
                new UnitGroup("Length")
                {
                    new Unit("km", "kilometers", 1000),
                    new Unit("m", "meters", 1),
                    new Unit("dm", "decimeters", 0.1),
                    new Unit("cm", "centimeters", 0.01),
                    new Unit("mm", "millimeters", 0.001)
                },
                new UnitGroup("Area"),
                new UnitGroup("Volume")
            };
            timesLength(localgroup);
            return localgroup;         
        }

        private void timesLength(List<UnitGroup> localgroup)
        {
            foreach (var element in localgroup.SingleOrDefault(g => g.GroupName == "Length"))
            {
                localgroup.SingleOrDefault(g => g.GroupName == "Area")?
                    .Add(new Unit(element.ShortName, $"square {element.LongName}",
                        Math.Pow(element.ConvertionToBasicUnit, 2), 2));

                localgroup.SingleOrDefault(g => g.GroupName == "Volume")?
                    .Add(new Unit(element.ShortName, $"volume {element.LongName}",
                        Math.Pow(element.ConvertionToBasicUnit, 3), 3));
            }
        }
    }
}