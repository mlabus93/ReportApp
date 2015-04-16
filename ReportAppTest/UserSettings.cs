using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportAppTest
{
    class UserSettings : ApplicationSettingsBase
    {
        const int MAX_SERVERS = 15;


        public UserSettings()
        {
            this.ServerName = new String[MAX_SERVERS];
            this.SettingsFlag = false;
        }

        [UserScopedSetting()]
        [DefaultSettingValue(null)]
        public String[] ServerName
        {
            get
            {
                return (String[])this["ServerName"];
            }
            set
            {
                this["ServerName"] = (String[])value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("1")]
        public int ServerCount
        {
            get
            {
                return (int)this["ServerCount"];
            }
            set
            {
                this["ServerCount"] = (int)value;
            }
        }

        [UserScopedSetting()]
        [DefaultSettingValue("")]
        public String Database
        {
            get
            {
                return (String)this["Database"];
            }
            set
            {
                this["Database"] = (String)value;
            }
        }

        [UserScopedSetting()]
        public Boolean SettingsFlag
        {
            get
            {
                return (Boolean)this["SettingsFlag"];
            }
            set
            {
                this["SettingsFlag"] = (Boolean)value;
            }
        }
    }
}
