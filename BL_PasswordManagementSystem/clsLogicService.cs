using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using DL_PasswordManagementSystem;
namespace BL_PasswordManagementSystem
{
    public enum enServiceMode { Update = 0, AddNew = 1 };

    public class clsLogicService
    {

        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string Url { get; set; }
        
        public enServiceMode Mode { get; set; }
        private clsLogicService(int ServiceID, string ServiceName, string Url)
        {
            this.ServiceID = ServiceID;
            this.ServiceName = ServiceName;
            this.Url = Url;
            Mode = enServiceMode.Update;

        }

        public clsLogicService()
        {
            this.ServiceID = -1;
            this.ServiceName = "";
            this.Url = "";
            
            Mode = enServiceMode.AddNew;
        }

        static public clsLogicService Find(int ServiceID)
        {
            string ServiceName = "", Url = "";

            if(DL_PasswordManagementSystem.clsService.GetServiceInfoByID(ServiceID, ref ServiceName,ref Url))
            {
                return new clsLogicService(ServiceID, ServiceName, Url);
            }
            return null;
        }
        static public clsLogicService Find(string ServiceName)
        {
            int ServiceID = -1;
            string Url = "";
            if (DL_PasswordManagementSystem.clsService.GetServiceInfoByServiceName(ref ServiceID, ServiceName, ref Url))
            {
                return new clsLogicService(ServiceID, ServiceName,Url);
            }
            return null;
        }

        private bool _AddService()
        {
            this.ServiceID = DL_PasswordManagementSystem.clsService.CreateService(this.ServiceID, this.ServiceName,this.Url);
            return this.ServiceID != -1;
        }
        private bool _UpdateService()
        {
            return DL_PasswordManagementSystem.clsService.UpdateService(this.ServiceID, this.ServiceName,this.Url);
        }
        static public bool DeleteService(int ServiceID)
        {
            return DL_PasswordManagementSystem.clsService.DeleteService(ServiceID);
        }
        static public bool IsExist(int ServiceID)
        {
            return DL_PasswordManagementSystem.clsService.IsExist(ServiceID);
        }
        static public bool IsExist(string ServiceName)
        {
            return DL_PasswordManagementSystem.clsService.IsExist(ServiceName);
        }
        static public DataTable GetListService()
        {
            return DL_PasswordManagementSystem.clsService.GetListServices();
        }
        static public DataTable GetServiceByType(string ServiceType)
        {
            return DL_PasswordManagementSystem.clsService.GetServiceByType(ServiceType);
        }
        public bool Save()
        {

            switch (Mode)
            {
                case enServiceMode.AddNew:
                    if (_AddService())
                    {
                        this.Mode = enServiceMode.Update;
                        return true;
                    }
                    break;
                case enServiceMode.Update:
                    return _UpdateService();
            }
            return false;
        }
    }
}
