using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Search_Engine
{
    class TokenizerTable<TRowKey, TColumnKey, TCellValue>
    {
        private Dictionary<TRowKey, Dictionary<TColumnKey, TCellValue>> table;

        public TokenizerTable()
        {
            table = new Dictionary<TRowKey, Dictionary<TColumnKey, TCellValue>>();
        }

        public void AddRow(TRowKey rowKey)
        {
            if (!table.ContainsKey(rowKey))
            {
                table[rowKey] = new Dictionary<TColumnKey, TCellValue>();
            }
        }

        public void AddColumn(TColumnKey columnKey)
        {
            foreach (var row in table.Values)
            {
                if (!row.ContainsKey(columnKey))
                {
                    row[columnKey] = default(TCellValue);
                }
            }
        }

        public void SetValue(TRowKey rowKey, TColumnKey columnKey, TCellValue value)
        {
            if (!table.ContainsKey(rowKey))
            {
                AddRow(rowKey);
            }

            table[rowKey][columnKey] = value;
        }

        public TCellValue GetValue(TRowKey rowKey, TColumnKey columnKey)
        {
            if (table.ContainsKey(rowKey) && table[rowKey].ContainsKey(columnKey))
            {
                return table[rowKey][columnKey];
            }
            else
            {
                return default(TCellValue);
            }
        }
    }
}
