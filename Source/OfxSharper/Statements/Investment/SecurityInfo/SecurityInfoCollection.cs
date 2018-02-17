using Restless.OfxSharper.Core;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Restless.OfxSharper.Statement
{
    /// <summary>
    /// Represents a collection of <see cref="SecurityInfoBase"/> objects
    /// </summary>
    public class SecurityInfoCollection : OfxObjectBase, ICollection<SecurityInfoBase>
    {
        #region Private
        private const string NodeName = "SECLIST";
        private List<SecurityInfoBase> list;
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
        /// Gets the <see cref="SecurityInfoBase"/> object indexed by position.
        /// </summary>
        /// <param name="index">The index position</param>
        /// <returns>The statement</returns>
        public SecurityInfoBase this[int index] 
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
        /// Initializes a new instance of the <see cref="SecurityInfoCollection"/> class.
        /// </summary>
        /// <param name="messageSetNode">The xml document</param>
        internal SecurityInfoCollection(XmlNode messageSetNode)
        {
            list = new List<SecurityInfoBase>();
            if (messageSetNode != null)
            {
                XmlNode secListNode = GetNestedNode(messageSetNode, NodeName);

                if (secListNode != null)
                {
                    foreach (XmlNode childNode in secListNode.ChildNodes)
                    {
                        switch (childNode.Name)
                        {
                            case MutualFundSecurityInfo.NodeName:
                                Add(new MutualFundSecurityInfo(childNode));
                                break;
                            case StockSecurityInfo.NodeName:
                                Add(new StockSecurityInfo(childNode));
                                break;
                            case OptionSecurityInfo.NodeName:
                                Add(new OptionSecurityInfo(childNode));
                                break;
                            case DebtSecurityInfo.NodeName:
                                Add(new DebtSecurityInfo(childNode));
                                break;
                            case OtherSecurityInfo.NodeName:
                                Add(new OtherSecurityInfo(childNode));
                                break;
                        }
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
        public void Add(SecurityInfoBase item)
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
        public bool Contains(SecurityInfoBase item)
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
        public void CopyTo(SecurityInfoBase[] array, int arrayIndex)
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
        public IEnumerator<SecurityInfoBase> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Removes the specified item form the collection if it exists.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>true if the item was removed, false if the item doesn't exist.</returns>
        public bool Remove(SecurityInfoBase item)
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
