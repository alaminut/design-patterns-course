#region Namespace Imports

using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Prototype
{
    public enum SortOrder
    {
        Ascending,
        Descending
    }

    [Serializable]
    public class AnnualReport
    {
        private SortOrder _order;
        private List<decimal> _expenses;
        
        public IEnumerable<decimal> Expenses => _expenses;
        public SortOrder Order
        {
            get => _order;
            set
            {
                _order = value;
                Sort();
            }
        }

        public AnnualReport(params decimal[] expenses)
        {
            _expenses = new List<decimal>(expenses);
            Order = SortOrder.Ascending; // default sort order
        }

        private void Sort()
        {
            _expenses = _order == SortOrder.Ascending
                            ? Expenses.OrderBy(e => e).ToList()
                            : Expenses.OrderByDescending(e => e).ToList();
        }
    }
}