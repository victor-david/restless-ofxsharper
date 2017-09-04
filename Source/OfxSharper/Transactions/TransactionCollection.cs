using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a collection of transactions.
    /// </summary>
    public class TransactionCollection : OfxObjectBase, ICollection<Transaction>
    {
        #region Private
        private List<Transaction> list;
        #endregion

        /************************************************************************/

        #region Public properties
        /// <summary>
        /// Gets the count of items.
        /// </summary>
        public int Count => list.Count;

        /// <summary>
        /// Gets a boolean value that indicates if the collection is read only. Always returns false.
        /// </summary>
        public bool IsReadOnly => false;


        /// <summary>
        /// DTSTART. Start date for transaction data, date.
        /// </summary>
        [NodeInfo("DTSTART")]
        public DateTime Start
        {
            get;
            private set;
        }

        /// <summary>
        /// DTEND. Value that client should send in next DTSTART request to ensure that it does not miss any transactions, date
        /// </summary>
        [NodeInfo("DTEND")]
        public DateTime End
        {
            get;
            private set;
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionCollection"/> class.
        /// </summary>
        /// <param name="rootNode">The root node from which to find data for this class.</param>
        internal TransactionCollection(XmlNode rootNode, string defaultCurrency)
        {
            list = new List<Transaction>();
            if (rootNode != null)
            {
                XmlNode endNode = GetNestedNode(rootNode, GetNodeName(nameof(End)));
                Start = GetDateTimeValue(endNode);
                End = GetDateTimeValue(GetNestedNode(rootNode, GetNodeName(nameof(End))));
                foreach (XmlNode node in endNode.ChildNodes)
                {
                    if (node.Name == "STMTTRN")
                    {
                        Add(new Transaction(node, defaultCurrency));
                    }
                }

            }
        }
        #endregion

        /************************************************************************/

        #region Public methods (list implementation)
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(Transaction item)
        {
            ValidateNull(item, "Add.Item");
            list.Add(item);
        }

        /// <summary>
        /// Clears the collection.
        /// </summary>
        public void Clear()
        {
            list.Clear();
        }

        /// <summary>
        /// Gets a boolean value that indicates if the specified item exists in the collection.
        /// </summary>
        /// <param name="item">The item to check.</param>
        /// <returns>true if the item exists in the collection; otherwise, false.</returns>
        public bool Contains(Transaction item)
        {
            foreach (var listItem in list)
            {
                if (listItem.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Copies the collection to the specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="arrayIndex">The array index to begin copying.</param>
        public void CopyTo(Transaction[] array, int arrayIndex)
        {
            ValidateNull(array, "CopyTo.Array");
            ValidateOfxOperation(arrayIndex < 0, "Index out of bounds");
            ValidateOfxOperation(Count > array.Length - arrayIndex + 1, "Destination array too small");
            for (int k = 0; k < list.Count; k++)
            {
                array[k + arrayIndex] = list[k];
            }
        }

        /// <summary>
        /// Gets the enumerator for the collection.
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<Transaction> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Removes the specified item form the collection if it exists.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>true if the item was removed, false if the item doesn't exist.</returns>
        public bool Remove(Transaction item)
        {
            if (Contains(item))
            {
                list.Remove(item);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
        #endregion

        /************************************************************************/

        #region Public methods
        #endregion
    }
}
