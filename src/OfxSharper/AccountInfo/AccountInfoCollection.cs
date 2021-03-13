using Restless.OfxSharper.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml;

namespace Restless.OfxSharper.Account
{
    /// <summary>
    /// Represents a collection of <see cref="AccountInfoPrimitive"/> objects
    /// </summary>
    public class AccountInfoCollection : OfxObjectBase, ICollection<AccountInfoPrimitive>
    {
        #region Private
        private List<AccountInfoPrimitive> list;
        private const string AccountInfoResponseNodeName = "ACCTINFORS";
        private const string AccountInfoNodeName = "ACCTINFO";
        private const string BankAccountInfoNodeName = "BANKACCTINFO";
        private const string CreditCardAccountInfoNodeName = "CCACCTINFO";
        private const string BillPayAccountInfoNodeName = "BPACCTINFO";
        private const string InvestmentAccountInfoNodeName = "INVACCTINFO";
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
        /// Gets the <see cref="AccountInfoPrimitive"/> object indexed by position.
        /// </summary>
        /// <param name="index">The index position</param>
        /// <returns>The statement</returns>
        public AccountInfoPrimitive this[int index] 
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
        /// <param name="messageSetNode">The node for the message set</param>
        internal AccountInfoCollection(XmlNode messageSetNode)
        {
            list = new List<AccountInfoPrimitive>();
            if (messageSetNode != null)
            {
                XmlNode responseNode = GetNestedNode(messageSetNode, AccountInfoResponseNodeName);
                if (responseNode != null)
                {
                    // It's kinda funky, but all the ACCTINFO nodes are children of DTACCTUP
                    var updatedNode = GetNestedNode(responseNode, GetNodeName(nameof(Updated)));
                    if (updatedNode != null)
                    {
                        Updated = GetDateTimeValue(updatedNode);
                        foreach (XmlNode childNode in updatedNode.ChildNodes)
                        {
                            if (childNode.Name == AccountInfoNodeName)
                            {
                                var info = CreateAccountInfoObject(childNode);
                                if (info != null) Add(info);
                            }
                        }

                        // Get all bill pay info items and set their corresponding bank account info's IsBillPaySource property
                        foreach (var item in this.OfType<BillPayAccountInfo>())
                        {
                            var bankInfo = GetCorrespondingBankAccountInfo(item);
                            if (bankInfo != null)
                            {
                                bankInfo.IsBillPaySource = true;
                            }
                        }

                        // Then remove all bill pay items. Their usage is temporary.
                        foreach (var item in this.OfType<BillPayAccountInfo>().ToList())
                        {
                            Remove(item);
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
        public void Add(AccountInfoPrimitive item)
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
        public bool Contains(AccountInfoPrimitive item)
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
        public void CopyTo(AccountInfoPrimitive[] array, int arrayIndex)
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
        public IEnumerator<AccountInfoPrimitive> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        /// <summary>
        /// Removes the specified item form the collection if it exists.
        /// </summary>
        /// <param name="item">The item</param>
        /// <returns>true if the item was removed, false if the item doesn't exist.</returns>
        public bool Remove(AccountInfoPrimitive item)
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

        #region Private methods
        /// <summary>
        /// Creates the account info object as needed.
        /// </summary>
        /// <param name="accountInfoNode">The node <see cref="AccountInfoNodeName"/></param>
        /// <returns>An object derived from AccountInfoBase</returns>
        /// <remarks>
        /// Before we know which type of object to create, we need to drill down and find
        /// which flavor of XXXACCTINFO exists inside <paramref name="accountInfoNode"/>.
        /// </remarks>
        private AccountInfoPrimitive CreateAccountInfoObject(XmlNode accountInfoNode)
        {
            XmlNode child = GetNestedNode(accountInfoNode, BankAccountInfoNodeName);
            if (child != null)
            {
                return new BankAccountInfo(accountInfoNode);
            }

            child = GetNestedNode(accountInfoNode, CreditCardAccountInfoNodeName);
            if (child != null)
            {
                return new CreditCardAccountInfo(accountInfoNode);
            }

            child = GetNestedNode(accountInfoNode, BillPayAccountInfoNodeName);
            if (child != null)
            {
                return new BillPayAccountInfo(accountInfoNode);
            }

            child = GetNestedNode(accountInfoNode, InvestmentAccountInfoNodeName);
            if (child != null)
            {
                return new InvestmentAccountInfo(accountInfoNode);
            }
            return null;
        }

        /// <summary>
        /// Gets the corresponding bank account info for the specified bill pay account info
        /// </summary>
        /// <param name="info"></param>
        /// <returns>
        /// The corresponding bank account info item, or null if none.
        /// Null won't happen unless the bank returns the OFX account info incorrectly.
        /// </returns>
        private BankAccountInfo GetCorrespondingBankAccountInfo(BillPayAccountInfo info)
        {
            if (info.Account is BankAccount infoAccount)
            {
                foreach (var item in this.OfType<BankAccountInfo>().Where((i) => i.Status == AccountInfoStatus.Active))
                {
                    if (item.Account is BankAccount itemAccount &&
                        itemAccount.AccountId == infoAccount.AccountId &&
                        itemAccount.BankAccountType == infoAccount.BankAccountType)
                    {
                        return item;
                    }
                }
            }
            return null;
        }
        #endregion
    }
}
