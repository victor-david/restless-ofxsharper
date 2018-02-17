using Restless.OfxSharper.Core;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents a collection of <see cref="BankStatementBase"/> objects.
    /// These objects represent both bank (checking, savings) and credit card statements.
    /// </summary>
    public class BankStatementCollection : OfxObjectBase, ICollection<BankStatementBase>
    {
        #region Private
        private List<BankStatementBase> list;
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
        /// Gets the <see cref="BankStatement"/> object indexed by position.
        /// </summary>
        /// <param name="index">The index position</param>
        /// <returns>The statement</returns>
        public BankStatementBase this[int index] 
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return list[index];
                }
                throw new KeyNotFoundException("StatementCollection[index]");
            }
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="BankStatementCollection"/> class.
        /// </summary>
        /// <param name="bankMessageSetNode">The node for the bank message set</param>
        /// <param name="creditCardMessageSetNode">The node for the credit card message set</param>
        internal BankStatementCollection(XmlNode bankMessageSetNode, XmlNode creditCardMessageSetNode)
        {
            list = new List<BankStatementBase>();
            if (bankMessageSetNode != null)
            {
                foreach (XmlNode childNode in bankMessageSetNode.ChildNodes)
                {
                    if (childNode.Name == BankStatement.TransactionNodeName)
                    {
                        Add(new BankStatement(childNode));
                    }
                }
            }

            if (creditCardMessageSetNode != null)
            {
                foreach (XmlNode childNode in creditCardMessageSetNode.ChildNodes)
                {
                    if (childNode.Name == CreditCardStatement.TransactionNodeName)
                    {
                        Add(new CreditCardStatement(childNode));
                    }
                }
            }
        }
        #endregion

        /************************************************************************/

        #region Public methods
        #endregion

        /************************************************************************/

        #region Public methods (list implementation)
        /// <summary>
        /// Adds an item to the collection.
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(BankStatementBase item)
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
        public bool Contains(BankStatementBase item)
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
        public void CopyTo(BankStatementBase[] array, int arrayIndex)
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
        public IEnumerator<BankStatementBase> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Removes the specified item form the collection if it exists.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>true if the item was removed, false if the item doesn't exist.</returns>
        public bool Remove(BankStatementBase item)
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
    }
}
