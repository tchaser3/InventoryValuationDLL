/* Title:           Inventory Valuation Class
 * Date:            12-27-17
 * Author:          Terry Holmes
 * 
 * Description:     This will run the stored procedure */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace InventoryValuationDLL
{
    public class InventoryValuationClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        FindWarehouseValueDataSet aFindWarehouseValueDataSet;
        FindWarehouseValueDataSetTableAdapters.FindWarehouseValueTableAdapter aFindWarehouseValueTableAdapter;

        public FindWarehouseValueDataSet FindWarehouseValue(int intWarehouseID)
        {
            try
            {
                aFindWarehouseValueDataSet = new FindWarehouseValueDataSet();
                aFindWarehouseValueTableAdapter = new FindWarehouseValueDataSetTableAdapters.FindWarehouseValueTableAdapter();
                aFindWarehouseValueTableAdapter.Fill(aFindWarehouseValueDataSet.FindWarehouseValue, intWarehouseID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Inventory Valuation Class // Find Warehouse Value " + Ex.Message);
            }

            return aFindWarehouseValueDataSet;
        }
    }
}
