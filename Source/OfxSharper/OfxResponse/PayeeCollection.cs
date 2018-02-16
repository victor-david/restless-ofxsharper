using Restless.OfxSharper.Core;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace Restless.OfxSharper
{
    /// <summary>
    /// Represents a collection of <see cref="Payee"/> objects
    /// </summary>
    public class PayeeCollection : OfxObjectBase, ICollection<Payee>
    {
        #region Private
        private List<Payee> list;
        private const string PayeeSyncResponse = "PAYEESYNCRS";
        private const string PayeeTransaction = "PAYEETRNRS";
        private const string PayeeResponse = "PAYEERS";
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
        /// Gets the token associated with the payee list.
        /// </summary>
        [NodeInfo("TOKEN")]
        public string Token
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets a boolean value that indicates if the server lost synchronization.
        /// </summary>
        [NodeInfo("LOSTSYNC")]
        public bool LostSync
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets the <see cref="Payee"/> object indexed by position.
        /// </summary>
        /// <param name="index">The index position</param>
        /// <returns>The statement</returns>
        public Payee this[int index] 
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return list[index];
                }
                throw new KeyNotFoundException("PayeeCollection[index]");
            }
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="PayeeCollection"/> class.
        /// </summary>
        /// <param name="xmlDoc">The xml document</param>
        internal PayeeCollection(XmlDocument xmlDoc)
        {
            list = new List<Payee>();
            XmlNode payeeSyncNode = GetNestedNode(xmlDoc.FirstChild, PayeeSyncResponse);

            if (payeeSyncNode != null)
            {
                Token = GetNodeValue(payeeSyncNode, nameof(Token));
                LostSync = GetBooleanValue(payeeSyncNode, nameof(LostSync));

                var lostSyncNode = GetNestedNode(payeeSyncNode, GetNodeName(nameof(LostSync)));
                if (lostSyncNode != null)
                {
                    foreach (XmlNode childNode in lostSyncNode.ChildNodes)
                    {
                        if (childNode.Name == PayeeTransaction)
                        {
                            var payeeRespNode = GetNestedNode(childNode, PayeeResponse);
                            Add(new Payee(payeeRespNode));
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
        public void Add(Payee item)
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
        public bool Contains(Payee item)
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
        public void CopyTo(Payee[] array, int arrayIndex)
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
        public IEnumerator<Payee> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Removes the specified item form the collection if it exists.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>true if the item was removed, false if the item doesn't exist.</returns>
        public bool Remove(Payee item)
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
