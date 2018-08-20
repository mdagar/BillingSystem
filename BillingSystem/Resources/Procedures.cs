namespace BillingSystem.Resources
{
    using System;
    using System.CodeDom.Compiler;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Globalization;
    using System.Resources;
    using System.Runtime.CompilerServices;

    [DebuggerNonUserCode, GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0"), CompilerGenerated]
    internal class Procedures
    {
        private static CultureInfo resourceCulture;
        private static System.Resources.ResourceManager resourceMan;

        internal Procedures()
        {
        }

        internal static string BillingDetailsGetByAll
        {
            get
            {
                return ResourceManager.GetString("BillingDetailsGetByAll", resourceCulture);
            }
        }

        internal static string BillingDetailsInsertUpdateDelete
        {
            get
            {
                return ResourceManager.GetString("BillingDetailsInsertUpdateDelete", resourceCulture);
            }
        }

        internal static string BillingLineDetailsGetByAll
        {
            get
            {
                return ResourceManager.GetString("BillingLineDetailsGetByAll", resourceCulture);
            }
        }

        internal static string BillingLineDetailsInsertUpdateDelete
        {
            get
            {
                return ResourceManager.GetString("BillingLineDetailsInsertUpdateDelete", resourceCulture);
            }
        }

        internal static string ClientInformationDetailsGetByAll_USP
        {
            get
            {
                return ResourceManager.GetString("ClientInformationDetailsGetByAll_USP", resourceCulture);
            }
        }

        internal static string ClientInformationDetailsInsertUpdateDelete_USP
        {
            get
            {
                return ResourceManager.GetString("ClientInformationDetailsInsertUpdateDelete_USP", resourceCulture);
            }
        }

        internal static string CompanyInformationDetailsGetByAll_USP
        {
            get
            {
                return ResourceManager.GetString("CompanyInformationDetailsGetByAll_USP", resourceCulture);
            }
        }

        internal static string CompanyInformationDetailsInsertUpdateDelete_USP
        {
            get
            {
                return ResourceManager.GetString("CompanyInformationDetailsInsertUpdateDelete_USP", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static CultureInfo Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        internal static string GetBillLineTextDetailsByUniqueID
        {
            get
            {
                return ResourceManager.GetString("GetBillLineTextDetailsByUniqueID", resourceCulture);
            }
        }

        internal static string GetBillTextDetailsByUniqueID
        {
            get
            {
                return ResourceManager.GetString("GetBillTextDetailsByUniqueID", resourceCulture);
            }
        }

        internal static string GetClientDetailsByAll
        {
            get
            {
                return ResourceManager.GetString("GetClientDetailsByAll", resourceCulture);
            }
        }

        internal static string GetCompanyDetailsByAll
        {
            get
            {
                return ResourceManager.GetString("GetCompanyDetailsByAll", resourceCulture);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        internal static System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    System.Resources.ResourceManager manager = new System.Resources.ResourceManager("BillingSystem.Resources.Procedures", typeof(Procedures).Assembly);
                    resourceMan = manager;
                }
                return resourceMan;
            }
        }

        internal static string UserInformationDetailsGetByAll_USP
        {
            get
            {
                return ResourceManager.GetString("UserInformationDetailsGetByAll_USP", resourceCulture);
            }
        }

        internal static string UserInformationInsertUpdateDelete_USP
        {
            get
            {
                return ResourceManager.GetString("UserInformationInsertUpdateDelete_USP", resourceCulture);
            }
        }

        internal static string ValidUserLoginCheck_USP
        {
            get
            {
                return ResourceManager.GetString("ValidUserLoginCheck_USP", resourceCulture);
            }
        }
    }
}

