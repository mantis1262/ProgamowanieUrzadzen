/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua;

namespace ObjectTypeTest
{
    #region ObjectType Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypes
    {
        /// <summary>
        /// The identifier for the CoustumerModel ObjectType.
        /// </summary>
        public const uint CoustumerModel = 61;

        /// <summary>
        /// The identifier for the DiscountData ObjectType.
        /// </summary>
        public const uint DiscountData = 63;

        /// <summary>
        /// The identifier for the EntryModel ObjectType.
        /// </summary>
        public const uint EntryModel = 65;

        /// <summary>
        /// The identifier for the MerchandiseModel ObjectType.
        /// </summary>
        public const uint MerchandiseModel = 66;

        /// <summary>
        /// The identifier for the OrderModel ObjectType.
        /// </summary>
        public const uint OrderModel = 67;

        /// <summary>
        /// The identifier for the WebMessageBase ObjectType.
        /// </summary>
        public const uint WebMessageBase = 68;
    }
    #endregion

    #region Variable Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class Variables
    {
        /// <summary>
        /// The identifier for the CoustumerModel_Id Variable.
        /// </summary>
        public const uint CoustumerModel_Id = 62;

        /// <summary>
        /// The identifier for the CoustumerModel_Name Variable.
        /// </summary>
        public const uint CoustumerModel_Name = 70;

        /// <summary>
        /// The identifier for the CoustumerModel_Address Variable.
        /// </summary>
        public const uint CoustumerModel_Address = 71;

        /// <summary>
        /// The identifier for the CoustumerModel_PhoneNumber Variable.
        /// </summary>
        public const uint CoustumerModel_PhoneNumber = 72;

        /// <summary>
        /// The identifier for the CoustumerModel_Nip Variable.
        /// </summary>
        public const uint CoustumerModel_Nip = 73;

        /// <summary>
        /// The identifier for the CoustumerModel_Pesel Variable.
        /// </summary>
        public const uint CoustumerModel_Pesel = 74;

        /// <summary>
        /// The identifier for the DiscountData_Time Variable.
        /// </summary>
        public const uint DiscountData_Time = 91;

        /// <summary>
        /// The identifier for the DiscountData_Discount Variable.
        /// </summary>
        public const uint DiscountData_Discount = 92;

        /// <summary>
        /// The identifier for the DiscountData_Merchandises Variable.
        /// </summary>
        public const uint DiscountData_Merchandises = 93;

        /// <summary>
        /// The identifier for the EntryModel_Id Variable.
        /// </summary>
        public const uint EntryModel_Id = 94;

        /// <summary>
        /// The identifier for the EntryModel_BruttoPrice Variable.
        /// </summary>
        public const uint EntryModel_BruttoPrice = 95;

        /// <summary>
        /// The identifier for the EntryModel_MerchandiseModel Variable.
        /// </summary>
        public const uint EntryModel_MerchandiseModel = 96;

        /// <summary>
        /// The identifier for the EntryModel_Amount Variable.
        /// </summary>
        public const uint EntryModel_Amount = 97;

        /// <summary>
        /// The identifier for the MerchandiseModel_Id Variable.
        /// </summary>
        public const uint MerchandiseModel_Id = 83;

        /// <summary>
        /// The identifier for the MerchandiseModel_Name Variable.
        /// </summary>
        public const uint MerchandiseModel_Name = 84;

        /// <summary>
        /// The identifier for the MerchandiseModel_Description Variable.
        /// </summary>
        public const uint MerchandiseModel_Description = 85;

        /// <summary>
        /// The identifier for the MerchandiseModel_Type Variable.
        /// </summary>
        public const uint MerchandiseModel_Type = 86;

        /// <summary>
        /// The identifier for the MerchandiseModel_Unit Variable.
        /// </summary>
        public const uint MerchandiseModel_Unit = 87;

        /// <summary>
        /// The identifier for the MerchandiseModel_NettoPrice Variable.
        /// </summary>
        public const uint MerchandiseModel_NettoPrice = 88;

        /// <summary>
        /// The identifier for the MerchandiseModel_Vat Variable.
        /// </summary>
        public const uint MerchandiseModel_Vat = 89;

        /// <summary>
        /// The identifier for the OrderModel_Entries Variable.
        /// </summary>
        public const uint OrderModel_Entries = 75;

        /// <summary>
        /// The identifier for the OrderModel_Id Variable.
        /// </summary>
        public const uint OrderModel_Id = 76;

        /// <summary>
        /// The identifier for the OrderModel_ClientInfo Variable.
        /// </summary>
        public const uint OrderModel_ClientInfo = 77;

        /// <summary>
        /// The identifier for the OrderModel_Status Variable.
        /// </summary>
        public const uint OrderModel_Status = 78;

        /// <summary>
        /// The identifier for the OrderModel_AcceptanceDate Variable.
        /// </summary>
        public const uint OrderModel_AcceptanceDate = 79;

        /// <summary>
        /// The identifier for the OrderModel_DeliveryData Variable.
        /// </summary>
        public const uint OrderModel_DeliveryData = 80;

        /// <summary>
        /// The identifier for the WebMessageBase_Tag Variable.
        /// </summary>
        public const uint WebMessageBase_Tag = 81;

        /// <summary>
        /// The identifier for the WebMessageBase_Status Variable.
        /// </summary>
        public const uint WebMessageBase_Status = 82;

        /// <summary>
        /// The identifier for the WebMessageBase_Message Variable.
        /// </summary>
        public const uint WebMessageBase_Message = 90;
    }
    #endregion

    #region VariableType Identifiers
    /// <summary>
    /// A class that declares constants for all VariableTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableTypes
    {
        /// <summary>
        /// The identifier for the MessageStatus VariableType.
        /// </summary>
        public const uint MessageStatus = 69;
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <summary>
    /// A class that declares constants for all ObjectTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class ObjectTypeIds
    {
        /// <summary>
        /// The identifier for the CoustumerModel ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId CoustumerModel = new ExpandedNodeId(ObjectTypeTest.ObjectTypes.CoustumerModel, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the DiscountData ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId DiscountData = new ExpandedNodeId(ObjectTypeTest.ObjectTypes.DiscountData, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the EntryModel ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId EntryModel = new ExpandedNodeId(ObjectTypeTest.ObjectTypes.EntryModel, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel = new ExpandedNodeId(ObjectTypeTest.ObjectTypes.MerchandiseModel, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the OrderModel ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId OrderModel = new ExpandedNodeId(ObjectTypeTest.ObjectTypes.OrderModel, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the WebMessageBase ObjectType.
        /// </summary>
        public static readonly ExpandedNodeId WebMessageBase = new ExpandedNodeId(ObjectTypeTest.ObjectTypes.WebMessageBase, ObjectTypeTest.Namespaces.cas);
    }
    #endregion

    #region Variable Node Identifiers
    /// <summary>
    /// A class that declares constants for all Variables in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableIds
    {
        /// <summary>
        /// The identifier for the CoustumerModel_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoustumerModel_Id = new ExpandedNodeId(ObjectTypeTest.Variables.CoustumerModel_Id, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the CoustumerModel_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoustumerModel_Name = new ExpandedNodeId(ObjectTypeTest.Variables.CoustumerModel_Name, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the CoustumerModel_Address Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoustumerModel_Address = new ExpandedNodeId(ObjectTypeTest.Variables.CoustumerModel_Address, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the CoustumerModel_PhoneNumber Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoustumerModel_PhoneNumber = new ExpandedNodeId(ObjectTypeTest.Variables.CoustumerModel_PhoneNumber, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the CoustumerModel_Nip Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoustumerModel_Nip = new ExpandedNodeId(ObjectTypeTest.Variables.CoustumerModel_Nip, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the CoustumerModel_Pesel Variable.
        /// </summary>
        public static readonly ExpandedNodeId CoustumerModel_Pesel = new ExpandedNodeId(ObjectTypeTest.Variables.CoustumerModel_Pesel, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the DiscountData_Time Variable.
        /// </summary>
        public static readonly ExpandedNodeId DiscountData_Time = new ExpandedNodeId(ObjectTypeTest.Variables.DiscountData_Time, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the DiscountData_Discount Variable.
        /// </summary>
        public static readonly ExpandedNodeId DiscountData_Discount = new ExpandedNodeId(ObjectTypeTest.Variables.DiscountData_Discount, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the DiscountData_Merchandises Variable.
        /// </summary>
        public static readonly ExpandedNodeId DiscountData_Merchandises = new ExpandedNodeId(ObjectTypeTest.Variables.DiscountData_Merchandises, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the EntryModel_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId EntryModel_Id = new ExpandedNodeId(ObjectTypeTest.Variables.EntryModel_Id, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the EntryModel_BruttoPrice Variable.
        /// </summary>
        public static readonly ExpandedNodeId EntryModel_BruttoPrice = new ExpandedNodeId(ObjectTypeTest.Variables.EntryModel_BruttoPrice, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the EntryModel_MerchandiseModel Variable.
        /// </summary>
        public static readonly ExpandedNodeId EntryModel_MerchandiseModel = new ExpandedNodeId(ObjectTypeTest.Variables.EntryModel_MerchandiseModel, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the EntryModel_Amount Variable.
        /// </summary>
        public static readonly ExpandedNodeId EntryModel_Amount = new ExpandedNodeId(ObjectTypeTest.Variables.EntryModel_Amount, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel_Id = new ExpandedNodeId(ObjectTypeTest.Variables.MerchandiseModel_Id, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel_Name Variable.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel_Name = new ExpandedNodeId(ObjectTypeTest.Variables.MerchandiseModel_Name, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel_Description Variable.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel_Description = new ExpandedNodeId(ObjectTypeTest.Variables.MerchandiseModel_Description, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel_Type Variable.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel_Type = new ExpandedNodeId(ObjectTypeTest.Variables.MerchandiseModel_Type, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel_Unit Variable.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel_Unit = new ExpandedNodeId(ObjectTypeTest.Variables.MerchandiseModel_Unit, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel_NettoPrice Variable.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel_NettoPrice = new ExpandedNodeId(ObjectTypeTest.Variables.MerchandiseModel_NettoPrice, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the MerchandiseModel_Vat Variable.
        /// </summary>
        public static readonly ExpandedNodeId MerchandiseModel_Vat = new ExpandedNodeId(ObjectTypeTest.Variables.MerchandiseModel_Vat, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the OrderModel_Entries Variable.
        /// </summary>
        public static readonly ExpandedNodeId OrderModel_Entries = new ExpandedNodeId(ObjectTypeTest.Variables.OrderModel_Entries, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the OrderModel_Id Variable.
        /// </summary>
        public static readonly ExpandedNodeId OrderModel_Id = new ExpandedNodeId(ObjectTypeTest.Variables.OrderModel_Id, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the OrderModel_ClientInfo Variable.
        /// </summary>
        public static readonly ExpandedNodeId OrderModel_ClientInfo = new ExpandedNodeId(ObjectTypeTest.Variables.OrderModel_ClientInfo, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the OrderModel_Status Variable.
        /// </summary>
        public static readonly ExpandedNodeId OrderModel_Status = new ExpandedNodeId(ObjectTypeTest.Variables.OrderModel_Status, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the OrderModel_AcceptanceDate Variable.
        /// </summary>
        public static readonly ExpandedNodeId OrderModel_AcceptanceDate = new ExpandedNodeId(ObjectTypeTest.Variables.OrderModel_AcceptanceDate, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the OrderModel_DeliveryData Variable.
        /// </summary>
        public static readonly ExpandedNodeId OrderModel_DeliveryData = new ExpandedNodeId(ObjectTypeTest.Variables.OrderModel_DeliveryData, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the WebMessageBase_Tag Variable.
        /// </summary>
        public static readonly ExpandedNodeId WebMessageBase_Tag = new ExpandedNodeId(ObjectTypeTest.Variables.WebMessageBase_Tag, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the WebMessageBase_Status Variable.
        /// </summary>
        public static readonly ExpandedNodeId WebMessageBase_Status = new ExpandedNodeId(ObjectTypeTest.Variables.WebMessageBase_Status, ObjectTypeTest.Namespaces.cas);

        /// <summary>
        /// The identifier for the WebMessageBase_Message Variable.
        /// </summary>
        public static readonly ExpandedNodeId WebMessageBase_Message = new ExpandedNodeId(ObjectTypeTest.Variables.WebMessageBase_Message, ObjectTypeTest.Namespaces.cas);
    }
    #endregion

    #region VariableType Node Identifiers
    /// <summary>
    /// A class that declares constants for all VariableTypes in the Model Design.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public static partial class VariableTypeIds
    {
        /// <summary>
        /// The identifier for the MessageStatus VariableType.
        /// </summary>
        public static readonly ExpandedNodeId MessageStatus = new ExpandedNodeId(ObjectTypeTest.VariableTypes.MessageStatus, ObjectTypeTest.Namespaces.cas);
    }
    #endregion

    #region BrowseName Declarations
    /// <summary>
    /// Declares all of the BrowseNames used in the Model Design.
    /// </summary>
    public static partial class BrowseNames
    {
        /// <summary>
        /// The BrowseName for the AcceptanceDate component.
        /// </summary>
        public const string AcceptanceDate = "AcceptanceDate";

        /// <summary>
        /// The BrowseName for the Address component.
        /// </summary>
        public const string Address = "Address";

        /// <summary>
        /// The BrowseName for the Amount component.
        /// </summary>
        public const string Amount = "Amount";

        /// <summary>
        /// The BrowseName for the BruttoPrice component.
        /// </summary>
        public const string BruttoPrice = "BruttoPrice";

        /// <summary>
        /// The BrowseName for the ClientInfo component.
        /// </summary>
        public const string ClientInfo = "ClientInfo";

        /// <summary>
        /// The BrowseName for the CoustumerModel component.
        /// </summary>
        public const string CoustumerModel = "CoustumerModel";

        /// <summary>
        /// The BrowseName for the DeliveryData component.
        /// </summary>
        public const string DeliveryData = "DeliveryData";

        /// <summary>
        /// The BrowseName for the Description component.
        /// </summary>
        public const string Description = "Description";

        /// <summary>
        /// The BrowseName for the Discount component.
        /// </summary>
        public const string Discount = "Discount";

        /// <summary>
        /// The BrowseName for the DiscountData component.
        /// </summary>
        public const string DiscountData = "DiscountData";

        /// <summary>
        /// The BrowseName for the Entries component.
        /// </summary>
        public const string Entries = "Entries";

        /// <summary>
        /// The BrowseName for the EntryModel component.
        /// </summary>
        public const string EntryModel = "EntryModel";

        /// <summary>
        /// The BrowseName for the Id component.
        /// </summary>
        public const string Id = "Id";

        /// <summary>
        /// The BrowseName for the MerchandiseModel component.
        /// </summary>
        public const string MerchandiseModel = "MerchandiseModel";

        /// <summary>
        /// The BrowseName for the Merchandises component.
        /// </summary>
        public const string Merchandises = "Merchandises";

        /// <summary>
        /// The BrowseName for the Message component.
        /// </summary>
        public const string Message = "Message";

        /// <summary>
        /// The BrowseName for the MessageStatus component.
        /// </summary>
        public const string MessageStatus = "MessageStatus";

        /// <summary>
        /// The BrowseName for the Name component.
        /// </summary>
        public const string Name = "Name";

        /// <summary>
        /// The BrowseName for the NettoPrice component.
        /// </summary>
        public const string NettoPrice = "NettoPrice";

        /// <summary>
        /// The BrowseName for the Nip component.
        /// </summary>
        public const string Nip = "Nip";

        /// <summary>
        /// The BrowseName for the OrderModel component.
        /// </summary>
        public const string OrderModel = "OrderModel";

        /// <summary>
        /// The BrowseName for the Pesel component.
        /// </summary>
        public const string Pesel = "Pesel";

        /// <summary>
        /// The BrowseName for the PhoneNumber component.
        /// </summary>
        public const string PhoneNumber = "PhoneNumber";

        /// <summary>
        /// The BrowseName for the Status component.
        /// </summary>
        public const string Status = "Status";

        /// <summary>
        /// The BrowseName for the Tag component.
        /// </summary>
        public const string Tag = "Tag";

        /// <summary>
        /// The BrowseName for the Time component.
        /// </summary>
        public const string Time = "Time";

        /// <summary>
        /// The BrowseName for the Type component.
        /// </summary>
        public const string Type = "Type";

        /// <summary>
        /// The BrowseName for the Unit component.
        /// </summary>
        public const string Unit = "Unit";

        /// <summary>
        /// The BrowseName for the Vat component.
        /// </summary>
        public const string Vat = "Vat";

        /// <summary>
        /// The BrowseName for the WebMessageBase component.
        /// </summary>
        public const string WebMessageBase = "WebMessageBase";
    }
    #endregion

    #region Namespace Declarations
    /// <summary>
    /// Defines constants for all namespaces referenced by the model design.
    /// </summary>
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the cas namespace (.NET code namespace is 'ObjectTypeTest').
        /// </summary>
        public const string cas = "http://cas.eu/UA/CommServer/UnitTests/ObjectTypeTest";

        /// <summary>
        /// The URI for the ua namespace (.NET code namespace is '').
        /// </summary>
        public const string ua = "http://opcfoundation.org/UA/";
    }
    #endregion

    #region CoustumerModelState Class
    #if (!OPCUA_EXCLUDE_CoustumerModelState)
    /// <summary>
    /// Stores an instance of the CoustumerModel ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class CoustumerModelState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public CoustumerModelState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(ObjectTypeTest.ObjectTypes.CoustumerModel, ObjectTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADQAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL09iamVjdFR5cGVUZXN0" +
           "/////wRggAABAAAAAQAWAAAAQ291c3R1bWVyTW9kZWxJbnN0YW5jZQEBPQABAT0A/////wYAAAAVYIkK" +
           "AgAAAAEAAgAAAElkAQE+AAAuAEQ+AAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAEAAAATmFtZQEB" +
           "RgAALgBERgAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEABwAAAEFkZHJlc3MBAUcAAC4AREcAAAAA" +
           "DP////8BAf////8AAAAAFWCJCgIAAAABAAsAAABQaG9uZU51bWJlcgEBSAAALgBESAAAAAAG/////wEB" +
           "/////wAAAAAVYIkKAgAAAAEAAwAAAE5pcAEBSQAALgBESQAAAAAM/////wEB/////wAAAAAVYIkKAgAA" +
           "AAEABQAAAFBlc2VsAQFKAAAuAERKAAAAAAz/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Property.
        /// </summary>
        public PropertyState<string> Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the Name Property.
        /// </summary>
        public PropertyState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the Address Property.
        /// </summary>
        public PropertyState<string> Address
        {
            get
            {
                return m_address;
            }

            set
            {
                if (!Object.ReferenceEquals(m_address, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_address = value;
            }
        }

        /// <summary>
        /// A description for the PhoneNumber Property.
        /// </summary>
        public PropertyState<int> PhoneNumber
        {
            get
            {
                return m_phoneNumber;
            }

            set
            {
                if (!Object.ReferenceEquals(m_phoneNumber, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_phoneNumber = value;
            }
        }

        /// <summary>
        /// A description for the Nip Property.
        /// </summary>
        public PropertyState<string> Nip
        {
            get
            {
                return m_nip;
            }

            set
            {
                if (!Object.ReferenceEquals(m_nip, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_nip = value;
            }
        }

        /// <summary>
        /// A description for the Pesel Property.
        /// </summary>
        public PropertyState<string> Pesel
        {
            get
            {
                return m_pesel;
            }

            set
            {
                if (!Object.ReferenceEquals(m_pesel, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_pesel = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_address != null)
            {
                children.Add(m_address);
            }

            if (m_phoneNumber != null)
            {
                children.Add(m_phoneNumber);
            }

            if (m_nip != null)
            {
                children.Add(m_nip);
            }

            if (m_pesel != null)
            {
                children.Add(m_pesel);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case ObjectTypeTest.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new PropertyState<string>(this);
                            }
                            else
                            {
                                Id = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new PropertyState<string>(this);
                            }
                            else
                            {
                                Name = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Address:
                {
                    if (createOrReplace)
                    {
                        if (Address == null)
                        {
                            if (replacement == null)
                            {
                                Address = new PropertyState<string>(this);
                            }
                            else
                            {
                                Address = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Address;
                    break;
                }

                case ObjectTypeTest.BrowseNames.PhoneNumber:
                {
                    if (createOrReplace)
                    {
                        if (PhoneNumber == null)
                        {
                            if (replacement == null)
                            {
                                PhoneNumber = new PropertyState<int>(this);
                            }
                            else
                            {
                                PhoneNumber = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = PhoneNumber;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Nip:
                {
                    if (createOrReplace)
                    {
                        if (Nip == null)
                        {
                            if (replacement == null)
                            {
                                Nip = new PropertyState<string>(this);
                            }
                            else
                            {
                                Nip = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Nip;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Pesel:
                {
                    if (createOrReplace)
                    {
                        if (Pesel == null)
                        {
                            if (replacement == null)
                            {
                                Pesel = new PropertyState<string>(this);
                            }
                            else
                            {
                                Pesel = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Pesel;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_id;
        private PropertyState<string> m_name;
        private PropertyState<string> m_address;
        private PropertyState<int> m_phoneNumber;
        private PropertyState<string> m_nip;
        private PropertyState<string> m_pesel;
        #endregion
    }
    #endif
    #endregion

    #region DiscountDataState Class
    #if (!OPCUA_EXCLUDE_DiscountDataState)
    /// <summary>
    /// Stores an instance of the DiscountData ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class DiscountDataState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public DiscountDataState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(ObjectTypeTest.ObjectTypes.DiscountData, ObjectTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADQAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL09iamVjdFR5cGVUZXN0" +
           "/////wRggAABAAAAAQAUAAAARGlzY291bnREYXRhSW5zdGFuY2UBAT8AAQE/AP////8DAAAAFWCJCgIA" +
           "AAABAAQAAABUaW1lAQFbAAAuAERbAAAAAA3/////AQH/////AAAAABVgiQoCAAAAAQAIAAAARGlzY291" +
           "bnQBAVwAAC4ARFwAAAAAC/////8BAf////8AAAAAFWCJCgIAAAABAAwAAABNZXJjaGFuZGlzZXMBAV0A" +
           "AC4ARF0AAAAAGP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Time Property.
        /// </summary>
        public PropertyState<DateTime> Time
        {
            get
            {
                return m_time;
            }

            set
            {
                if (!Object.ReferenceEquals(m_time, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_time = value;
            }
        }

        /// <summary>
        /// A description for the Discount Property.
        /// </summary>
        public PropertyState<double> Discount
        {
            get
            {
                return m_discount;
            }

            set
            {
                if (!Object.ReferenceEquals(m_discount, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_discount = value;
            }
        }

        /// <summary>
        /// A description for the Merchandises Property.
        /// </summary>
        public PropertyState Merchandises
        {
            get
            {
                return m_merchandises;
            }

            set
            {
                if (!Object.ReferenceEquals(m_merchandises, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_merchandises = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_time != null)
            {
                children.Add(m_time);
            }

            if (m_discount != null)
            {
                children.Add(m_discount);
            }

            if (m_merchandises != null)
            {
                children.Add(m_merchandises);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case ObjectTypeTest.BrowseNames.Time:
                {
                    if (createOrReplace)
                    {
                        if (Time == null)
                        {
                            if (replacement == null)
                            {
                                Time = new PropertyState<DateTime>(this);
                            }
                            else
                            {
                                Time = (PropertyState<DateTime>)replacement;
                            }
                        }
                    }

                    instance = Time;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Discount:
                {
                    if (createOrReplace)
                    {
                        if (Discount == null)
                        {
                            if (replacement == null)
                            {
                                Discount = new PropertyState<double>(this);
                            }
                            else
                            {
                                Discount = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Discount;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Merchandises:
                {
                    if (createOrReplace)
                    {
                        if (Merchandises == null)
                        {
                            if (replacement == null)
                            {
                                Merchandises = new PropertyState(this);
                            }
                            else
                            {
                                Merchandises = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = Merchandises;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<DateTime> m_time;
        private PropertyState<double> m_discount;
        private PropertyState m_merchandises;
        #endregion
    }
    #endif
    #endregion

    #region EntryModelState Class
    #if (!OPCUA_EXCLUDE_EntryModelState)
    /// <summary>
    /// Stores an instance of the EntryModel ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class EntryModelState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public EntryModelState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(ObjectTypeTest.ObjectTypes.EntryModel, ObjectTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADQAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL09iamVjdFR5cGVUZXN0" +
           "/////wRggAABAAAAAQASAAAARW50cnlNb2RlbEluc3RhbmNlAQFBAAEBQQD/////BAAAABVgiQoCAAAA" +
           "AQACAAAASWQBAV4AAC4ARF4AAAAABv////8BAf////8AAAAAFWCJCgIAAAABAAsAAABCcnV0dG9Qcmlj" +
           "ZQEBXwAALgBEXwAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAEAEAAAAE1lcmNoYW5kaXNlTW9kZWwB" +
           "AWAAAC4ARGAAAAAAGP////8BAf////8AAAAAFWCJCgIAAAABAAYAAABBbW91bnQBAWEAAC4ARGEAAAAA" +
           "Bv////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Property.
        /// </summary>
        public PropertyState<int> Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the BruttoPrice Property.
        /// </summary>
        public PropertyState<double> BruttoPrice
        {
            get
            {
                return m_bruttoPrice;
            }

            set
            {
                if (!Object.ReferenceEquals(m_bruttoPrice, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_bruttoPrice = value;
            }
        }

        /// <summary>
        /// A description for the MerchandiseModel Property.
        /// </summary>
        public PropertyState MerchandiseModel
        {
            get
            {
                return m_merchandiseModel;
            }

            set
            {
                if (!Object.ReferenceEquals(m_merchandiseModel, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_merchandiseModel = value;
            }
        }

        /// <summary>
        /// A description for the Amount Property.
        /// </summary>
        public PropertyState<int> Amount
        {
            get
            {
                return m_amount;
            }

            set
            {
                if (!Object.ReferenceEquals(m_amount, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_amount = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_bruttoPrice != null)
            {
                children.Add(m_bruttoPrice);
            }

            if (m_merchandiseModel != null)
            {
                children.Add(m_merchandiseModel);
            }

            if (m_amount != null)
            {
                children.Add(m_amount);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case ObjectTypeTest.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new PropertyState<int>(this);
                            }
                            else
                            {
                                Id = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case ObjectTypeTest.BrowseNames.BruttoPrice:
                {
                    if (createOrReplace)
                    {
                        if (BruttoPrice == null)
                        {
                            if (replacement == null)
                            {
                                BruttoPrice = new PropertyState<double>(this);
                            }
                            else
                            {
                                BruttoPrice = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = BruttoPrice;
                    break;
                }

                case ObjectTypeTest.BrowseNames.MerchandiseModel:
                {
                    if (createOrReplace)
                    {
                        if (MerchandiseModel == null)
                        {
                            if (replacement == null)
                            {
                                MerchandiseModel = new PropertyState(this);
                            }
                            else
                            {
                                MerchandiseModel = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = MerchandiseModel;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Amount:
                {
                    if (createOrReplace)
                    {
                        if (Amount == null)
                        {
                            if (replacement == null)
                            {
                                Amount = new PropertyState<int>(this);
                            }
                            else
                            {
                                Amount = (PropertyState<int>)replacement;
                            }
                        }
                    }

                    instance = Amount;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<int> m_id;
        private PropertyState<double> m_bruttoPrice;
        private PropertyState m_merchandiseModel;
        private PropertyState<int> m_amount;
        #endregion
    }
    #endif
    #endregion

    #region MerchandiseModelState Class
    #if (!OPCUA_EXCLUDE_MerchandiseModelState)
    /// <summary>
    /// Stores an instance of the MerchandiseModel ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MerchandiseModelState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MerchandiseModelState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(ObjectTypeTest.ObjectTypes.MerchandiseModel, ObjectTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADQAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL09iamVjdFR5cGVUZXN0" +
           "/////wRggAABAAAAAQAYAAAATWVyY2hhbmRpc2VNb2RlbEluc3RhbmNlAQFCAAEBQgD/////BwAAABVg" +
           "iQoCAAAAAQACAAAASWQBAVMAAC4ARFMAAAAADP////8BAf////8AAAAAFWCJCgIAAAABAAQAAABOYW1l" +
           "AQFUAAAuAERUAAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQALAAAARGVzY3JpcHRpb24BAVUAAC4A" +
           "RFUAAAAADP////8BAf////8AAAAAFWCJCgIAAAABAAQAAABUeXBlAQFWAAAuAERWAAAAAAz/////AQH/" +
           "////AAAAABVgiQoCAAAAAQAEAAAAVW5pdAEBVwAALgBEVwAAAAAM/////wEB/////wAAAAAVYIkKAgAA" +
           "AAEACgAAAE5ldHRvUHJpY2UBAVgAAC4ARFgAAAAAC/////8BAf////8AAAAAFWCJCgIAAAABAAMAAABW" +
           "YXQBAVkAAC4ARFkAAAAAC/////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Id Property.
        /// </summary>
        public PropertyState<string> Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the Name Property.
        /// </summary>
        public PropertyState<string> Name
        {
            get
            {
                return m_name;
            }

            set
            {
                if (!Object.ReferenceEquals(m_name, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_name = value;
            }
        }

        /// <summary>
        /// A description for the Description Property.
        /// </summary>
        public PropertyState<string> Description
        {
            get
            {
                return m_description;
            }

            set
            {
                if (!Object.ReferenceEquals(m_description, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_description = value;
            }
        }

        /// <summary>
        /// A description for the Type Property.
        /// </summary>
        public PropertyState<string> Type
        {
            get
            {
                return m_type;
            }

            set
            {
                if (!Object.ReferenceEquals(m_type, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_type = value;
            }
        }

        /// <summary>
        /// A description for the Unit Property.
        /// </summary>
        public PropertyState<string> Unit
        {
            get
            {
                return m_unit;
            }

            set
            {
                if (!Object.ReferenceEquals(m_unit, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_unit = value;
            }
        }

        /// <summary>
        /// A description for the NettoPrice Property.
        /// </summary>
        public PropertyState<double> NettoPrice
        {
            get
            {
                return m_nettoPrice;
            }

            set
            {
                if (!Object.ReferenceEquals(m_nettoPrice, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_nettoPrice = value;
            }
        }

        /// <summary>
        /// A description for the Vat Property.
        /// </summary>
        public PropertyState<double> Vat
        {
            get
            {
                return m_vat;
            }

            set
            {
                if (!Object.ReferenceEquals(m_vat, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_vat = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_name != null)
            {
                children.Add(m_name);
            }

            if (m_description != null)
            {
                children.Add(m_description);
            }

            if (m_type != null)
            {
                children.Add(m_type);
            }

            if (m_unit != null)
            {
                children.Add(m_unit);
            }

            if (m_nettoPrice != null)
            {
                children.Add(m_nettoPrice);
            }

            if (m_vat != null)
            {
                children.Add(m_vat);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case ObjectTypeTest.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new PropertyState<string>(this);
                            }
                            else
                            {
                                Id = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Name:
                {
                    if (createOrReplace)
                    {
                        if (Name == null)
                        {
                            if (replacement == null)
                            {
                                Name = new PropertyState<string>(this);
                            }
                            else
                            {
                                Name = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Name;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Description:
                {
                    if (createOrReplace)
                    {
                        if (Description == null)
                        {
                            if (replacement == null)
                            {
                                Description = new PropertyState<string>(this);
                            }
                            else
                            {
                                Description = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Description;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Type:
                {
                    if (createOrReplace)
                    {
                        if (Type == null)
                        {
                            if (replacement == null)
                            {
                                Type = new PropertyState<string>(this);
                            }
                            else
                            {
                                Type = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Type;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Unit:
                {
                    if (createOrReplace)
                    {
                        if (Unit == null)
                        {
                            if (replacement == null)
                            {
                                Unit = new PropertyState<string>(this);
                            }
                            else
                            {
                                Unit = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Unit;
                    break;
                }

                case ObjectTypeTest.BrowseNames.NettoPrice:
                {
                    if (createOrReplace)
                    {
                        if (NettoPrice == null)
                        {
                            if (replacement == null)
                            {
                                NettoPrice = new PropertyState<double>(this);
                            }
                            else
                            {
                                NettoPrice = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = NettoPrice;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Vat:
                {
                    if (createOrReplace)
                    {
                        if (Vat == null)
                        {
                            if (replacement == null)
                            {
                                Vat = new PropertyState<double>(this);
                            }
                            else
                            {
                                Vat = (PropertyState<double>)replacement;
                            }
                        }
                    }

                    instance = Vat;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_id;
        private PropertyState<string> m_name;
        private PropertyState<string> m_description;
        private PropertyState<string> m_type;
        private PropertyState<string> m_unit;
        private PropertyState<double> m_nettoPrice;
        private PropertyState<double> m_vat;
        #endregion
    }
    #endif
    #endregion

    #region OrderModelState Class
    #if (!OPCUA_EXCLUDE_OrderModelState)
    /// <summary>
    /// Stores an instance of the OrderModel ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class OrderModelState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public OrderModelState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(ObjectTypeTest.ObjectTypes.OrderModel, ObjectTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADQAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL09iamVjdFR5cGVUZXN0" +
           "/////wRggAABAAAAAQASAAAAT3JkZXJNb2RlbEluc3RhbmNlAQFDAAEBQwD/////BgAAABVgiQoCAAAA" +
           "AQAHAAAARW50cmllcwEBSwAALgBESwAAAAAY/////wEB/////wAAAAAVYIkKAgAAAAEAAgAAAElkAQFM" +
           "AAAuAERMAAAAAAz/////AQH/////AAAAABVgiQoCAAAAAQAKAAAAQ2xpZW50SW5mbwEBTQAALgBETQAA" +
           "AAAY/////wEB/////wAAAAAVYIkKAgAAAAEABgAAAFN0YXR1cwEBTgAALgBETgAAAAAM/////wEB////" +
           "/wAAAAAVYIkKAgAAAAEADgAAAEFjY2VwdGFuY2VEYXRlAQFPAAAuAERPAAAAAAj/////AQH/////AAAA" +
           "ABVgiQoCAAAAAQAMAAAARGVsaXZlcnlEYXRhAQFQAAAuAERQAAAAAAj/////AQH/////AAAAAA==";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Entries Property.
        /// </summary>
        public PropertyState Entries
        {
            get
            {
                return m_entries;
            }

            set
            {
                if (!Object.ReferenceEquals(m_entries, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_entries = value;
            }
        }

        /// <summary>
        /// A description for the Id Property.
        /// </summary>
        public PropertyState<string> Id
        {
            get
            {
                return m_id;
            }

            set
            {
                if (!Object.ReferenceEquals(m_id, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_id = value;
            }
        }

        /// <summary>
        /// A description for the ClientInfo Property.
        /// </summary>
        public PropertyState ClientInfo
        {
            get
            {
                return m_clientInfo;
            }

            set
            {
                if (!Object.ReferenceEquals(m_clientInfo, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_clientInfo = value;
            }
        }

        /// <summary>
        /// A description for the Status Property.
        /// </summary>
        public PropertyState<string> Status
        {
            get
            {
                return m_status;
            }

            set
            {
                if (!Object.ReferenceEquals(m_status, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_status = value;
            }
        }

        /// <summary>
        /// A description for the AcceptanceDate Property.
        /// </summary>
        public PropertyState<long> AcceptanceDate
        {
            get
            {
                return m_acceptanceDate;
            }

            set
            {
                if (!Object.ReferenceEquals(m_acceptanceDate, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_acceptanceDate = value;
            }
        }

        /// <summary>
        /// A description for the DeliveryData Property.
        /// </summary>
        public PropertyState<long> DeliveryData
        {
            get
            {
                return m_deliveryData;
            }

            set
            {
                if (!Object.ReferenceEquals(m_deliveryData, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_deliveryData = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_entries != null)
            {
                children.Add(m_entries);
            }

            if (m_id != null)
            {
                children.Add(m_id);
            }

            if (m_clientInfo != null)
            {
                children.Add(m_clientInfo);
            }

            if (m_status != null)
            {
                children.Add(m_status);
            }

            if (m_acceptanceDate != null)
            {
                children.Add(m_acceptanceDate);
            }

            if (m_deliveryData != null)
            {
                children.Add(m_deliveryData);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case ObjectTypeTest.BrowseNames.Entries:
                {
                    if (createOrReplace)
                    {
                        if (Entries == null)
                        {
                            if (replacement == null)
                            {
                                Entries = new PropertyState(this);
                            }
                            else
                            {
                                Entries = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = Entries;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Id:
                {
                    if (createOrReplace)
                    {
                        if (Id == null)
                        {
                            if (replacement == null)
                            {
                                Id = new PropertyState<string>(this);
                            }
                            else
                            {
                                Id = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Id;
                    break;
                }

                case ObjectTypeTest.BrowseNames.ClientInfo:
                {
                    if (createOrReplace)
                    {
                        if (ClientInfo == null)
                        {
                            if (replacement == null)
                            {
                                ClientInfo = new PropertyState(this);
                            }
                            else
                            {
                                ClientInfo = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = ClientInfo;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Status:
                {
                    if (createOrReplace)
                    {
                        if (Status == null)
                        {
                            if (replacement == null)
                            {
                                Status = new PropertyState<string>(this);
                            }
                            else
                            {
                                Status = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Status;
                    break;
                }

                case ObjectTypeTest.BrowseNames.AcceptanceDate:
                {
                    if (createOrReplace)
                    {
                        if (AcceptanceDate == null)
                        {
                            if (replacement == null)
                            {
                                AcceptanceDate = new PropertyState<long>(this);
                            }
                            else
                            {
                                AcceptanceDate = (PropertyState<long>)replacement;
                            }
                        }
                    }

                    instance = AcceptanceDate;
                    break;
                }

                case ObjectTypeTest.BrowseNames.DeliveryData:
                {
                    if (createOrReplace)
                    {
                        if (DeliveryData == null)
                        {
                            if (replacement == null)
                            {
                                DeliveryData = new PropertyState<long>(this);
                            }
                            else
                            {
                                DeliveryData = (PropertyState<long>)replacement;
                            }
                        }
                    }

                    instance = DeliveryData;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState m_entries;
        private PropertyState<string> m_id;
        private PropertyState m_clientInfo;
        private PropertyState<string> m_status;
        private PropertyState<long> m_acceptanceDate;
        private PropertyState<long> m_deliveryData;
        #endregion
    }
    #endif
    #endregion

    #region WebMessageBaseState Class
    #if (!OPCUA_EXCLUDE_WebMessageBaseState)
    /// <summary>
    /// Stores an instance of the WebMessageBase ObjectType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class WebMessageBaseState : BaseObjectState
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public WebMessageBaseState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(ObjectTypeTest.ObjectTypes.WebMessageBase, ObjectTypeTest.Namespaces.cas, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADQAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL09iamVjdFR5cGVUZXN0" +
           "/////wRggAABAAAAAQAWAAAAV2ViTWVzc2FnZUJhc2VJbnN0YW5jZQEBRAABAUQA/////wMAAAAVYIkK" +
           "AgAAAAEAAwAAAFRhZwEBUQAALgBEUQAAAAAM/////wEB/////wAAAAAVYIkKAgAAAAEABgAAAFN0YXR1" +
           "cwEBUgAALgBEUgAAAAAY/////wEB/////wAAAAAVYIkKAgAAAAEABwAAAE1lc3NhZ2UBAVoAAC4ARFoA" +
           "AAAADP////8BAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        /// <summary>
        /// A description for the Tag Property.
        /// </summary>
        public PropertyState<string> Tag
        {
            get
            {
                return m_tag;
            }

            set
            {
                if (!Object.ReferenceEquals(m_tag, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_tag = value;
            }
        }

        /// <summary>
        /// A description for the Status Property.
        /// </summary>
        public PropertyState Status
        {
            get
            {
                return m_status;
            }

            set
            {
                if (!Object.ReferenceEquals(m_status, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_status = value;
            }
        }

        /// <summary>
        /// A description for the Message Property.
        /// </summary>
        public PropertyState<string> Message
        {
            get
            {
                return m_message;
            }

            set
            {
                if (!Object.ReferenceEquals(m_message, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_message = value;
            }
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Populates a list with the children that belong to the node.
        /// </summary>
        /// <param name="context">The context for the system being accessed.</param>
        /// <param name="children">The list of children to populate.</param>
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_tag != null)
            {
                children.Add(m_tag);
            }

            if (m_status != null)
            {
                children.Add(m_status);
            }

            if (m_message != null)
            {
                children.Add(m_message);
            }

            base.GetChildren(context, children);
        }

        /// <summary>
        /// Finds the child with the specified browse name.
        /// </summary>
        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case ObjectTypeTest.BrowseNames.Tag:
                {
                    if (createOrReplace)
                    {
                        if (Tag == null)
                        {
                            if (replacement == null)
                            {
                                Tag = new PropertyState<string>(this);
                            }
                            else
                            {
                                Tag = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Tag;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Status:
                {
                    if (createOrReplace)
                    {
                        if (Status == null)
                        {
                            if (replacement == null)
                            {
                                Status = new PropertyState(this);
                            }
                            else
                            {
                                Status = (PropertyState)replacement;
                            }
                        }
                    }

                    instance = Status;
                    break;
                }

                case ObjectTypeTest.BrowseNames.Message:
                {
                    if (createOrReplace)
                    {
                        if (Message == null)
                        {
                            if (replacement == null)
                            {
                                Message = new PropertyState<string>(this);
                            }
                            else
                            {
                                Message = (PropertyState<string>)replacement;
                            }
                        }
                    }

                    instance = Message;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private PropertyState<string> m_tag;
        private PropertyState m_status;
        private PropertyState<string> m_message;
        #endregion
    }
    #endif
    #endregion

    #region MessageStatusState Class
    #if (!OPCUA_EXCLUDE_MessageStatusState)
    /// <summary>
    /// Stores an instance of the MessageStatus VariableType.
    /// </summary>
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    public partial class MessageStatusState : BaseDataVariableState<string>
    {
        #region Constructors
        /// <summary>
        /// Initializes the type with its default attribute values.
        /// </summary>
        public MessageStatusState(NodeState parent) : base(parent)
        {
        }

        /// <summary>
        /// Returns the id of the default type definition node for the instance.
        /// </summary>
        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(ObjectTypeTest.VariableTypes.MessageStatus, ObjectTypeTest.Namespaces.cas, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default data type node for the instance.
        /// </summary>
        protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(DataTypes.String, Namespaces.ua, namespaceUris);
        }

        /// <summary>
        /// Returns the id of the default value rank for the instance.
        /// </summary>
        protected override int GetDefaultValueRank()
        {
            return ValueRanks.Scalar;
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        /// <summary>
        /// Initializes the instance.
        /// </summary>
        protected override void Initialize(ISystemContext context)
        {
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        /// <summary>
        /// Initializes the any option children defined for the instance.
        /// </summary>
        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AQAAADQAAABodHRwOi8vY2FzLmV1L1VBL0NvbW1TZXJ2ZXIvVW5pdFRlc3RzL09iamVjdFR5cGVUZXN0" +
           "/////xVggQACAAAAAQAVAAAATWVzc2FnZVN0YXR1c0luc3RhbmNlAQFFAAEBRQAADAEB/////wAAAAA=";
        #endregion
        #endif
        #endregion

        #region Public Properties
        #endregion

        #region Overridden Methods
        #endregion

        #region Private Fields
        #endregion
    }
    #endif
    #endregion
}