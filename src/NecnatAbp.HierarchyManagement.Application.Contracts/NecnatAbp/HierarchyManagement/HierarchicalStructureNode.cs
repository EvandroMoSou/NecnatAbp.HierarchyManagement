using System;
using System.Collections.Generic;
using System.Linq;

namespace NecnatAbp.HierarchyManagement
{
    public class HierarchicalStructureNode
    {
        public HierarchicalStructureNode(ICollection<HierarchicalStructureDto> hierarchicalStructureList, Guid? id)
        {
            var hierarchicalStructure = hierarchicalStructureList.Where(x => x.Id == id).First();

            Id = hierarchicalStructure.Id;
            ParentId = hierarchicalStructure.ParentId;
            HierarchyId = hierarchicalStructure.HierarchyId;
            HierarchyComponentType = hierarchicalStructure.HierarchyComponentType;
            HierarchyComponentId = hierarchicalStructure.HierarchyComponentId;
            Children = new List<HierarchicalStructureNode>();

            foreach (var iHierarchicalStructure in hierarchicalStructureList.Where(x => x.ParentId == Id))
                Children.Add(new HierarchicalStructureNode(hierarchicalStructureList, iHierarchicalStructure.Id));
        }

        public Guid Id { get; set; } = default!;
        public Guid? ParentId { get; set; }
        public Guid? HierarchyId { get; set; }
        public int? HierarchyComponentType { get; set; }
        public Guid? HierarchyComponentId { get; set; }
        public ICollection<HierarchicalStructureNode> Children { get; set; }
    }
}