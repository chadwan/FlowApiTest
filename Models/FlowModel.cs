using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FlowApi.LINQ;

namespace FlowApi.Models
{
    public class FlowModel
    {
        public static List<Flow> getFlow()
        {
            FlowDBDataContext linq = new FlowDBDataContext();
            return linq.Flows.OrderBy(a => a.Name).ToList();
        }

        public static List<Flow> getFlow(string q)
        {
            FlowDBDataContext linq = new FlowDBDataContext();
            return linq.Flows.Where(a => a.Name.Contains(q) || a.FullName.Contains(q)).OrderBy(a => a.Name).ToList();
        }

        public static List<Flow> getFlow(string q, int page, int pageSize)
        {
            FlowDBDataContext linq = new FlowDBDataContext();
            return linq.Flows.Where(a => a.Name.Contains(q) || a.FullName.Contains(q)).Skip(page * pageSize).Take(pageSize).OrderBy(a => a.Name).ToList();
        }
    }
}