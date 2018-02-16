using Restless.OfxSharper.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Restless.OfxSharper.Accounts
{
    /// <summary>
    /// Represents a collection of <see cref="AccountInfo"/> objects
    /// </summary>
    public class AccountInfoCollection : OfxObjectBase, ICollection<AccountInfo>
    {
        #region Private
        private List<AccountInfo> list;
        private const string AccountInfoResponse = "ACCTINFORS";
        private const string AccountInfo = "ACCTINFO";

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
        /// Gets the date/time that the the account list was updated
        /// </summary>
        [NodeInfo("DTACCTUP")]
        public DateTime Updated
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the <see cref="AccountInfo"/> object indexed by position.
        /// </summary>
        /// <param name="index">The index position</param>
        /// <returns>The statement</returns>
        public AccountInfo this[int index] 
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return list[index];
                }
                throw new KeyNotFoundException("AccountInfoCollection[index]");
            }
        }
        #endregion

        /************************************************************************/

        #region Constructor (internal)
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountInfoCollection"/> class.
        /// </summary>
        /// <param name="xmlDoc">The xml document</param>
        internal AccountInfoCollection(XmlDocument xmlDoc)
        {
            list = new List<AccountInfo>();
            XmlNode responseNode = GetNestedNode(xmlDoc.FirstChild, AccountInfoResponse);

            if (responseNode != null)
            {
                var updatedNode = GetNestedNode(responseNode, GetNodeName(nameof(Updated)));
                if (updatedNode != null)
                {
                    Updated = GetDateTimeValue(updatedNode);
                    foreach (XmlNode childNode in updatedNode.ChildNodes)
                    {
                        if (childNode.Name == AccountInfo)
                        {
                            Add(new AccountInfo(childNode));
                        }
                    }
                }
                foreach (AccountInfo bps in this.Where((info) => info.IsBillPaySourceInternal))
                {
                    // get all not flagged internal bill pay and of account type Bank
                    foreach (AccountInfo acct in this.Where((info) => !info.IsBillPaySourceInternal && info.Account.AccountType == AccountType.Bank))
                    {
                        // if match id and bank account type, flag as bill pay source.
                        if (acct.Account.AccountId == bps.Account.AccountId && ((BankAccount)acct.Account).BankAccountType == ((BankAccount)bps.Account).BankAccountType)
                        {
                            acct.IsBillPaySource = true;
                        }
                    }
                }
                // Remove internally flagged entries. Their usage is temporary
                foreach (AccountInfo bps in this.Where((i) => i.IsBillPaySourceInternal).ToList())
                {
                    Remove(bps);
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
        public void Add(AccountInfo item)
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
        public bool Contains(AccountInfo item)
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
        public void CopyTo(AccountInfo[] array, int arrayIndex)
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
        public IEnumerator<AccountInfo> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Removes the specified item form the collection if it exists.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>true if the item was removed, false if the item doesn't exist.</returns>
        public bool Remove(AccountInfo item)
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
