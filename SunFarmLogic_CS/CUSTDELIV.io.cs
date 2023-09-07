#line hidden
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ASNA.DataGate.Client;
using ASNA.DataGate.Common;
using ASNA.QSys.Runtime;
using System;
using System.Collections.Generic;


namespace ACME.SunFarm
{
    
    public partial class CUSTDELIV
    {
        private FixedDecimal<_9, _0> CACUSTNO;
        private FixedDecimal<_3, _0> CAADDRh;
        private FixedString<_40> CANAME;
        private FixedString<_35> CAADDR1;
        private FixedString<_35> CAADDR2;
        private FixedString<_30> CACITY;
        private FixedString<_2> CASTATE;
        private FixedString<_10> CAZIP;
        private FixedString<_1> SFLSEL;
        private FixedDecimal<_9, _0> SFLCUSTh;
        private FixedString<_26> SFLCUST;
        private FixedString<_25> SFLCITY;
        private FixedString<_5> SFLZIP;
        static (ILayout layout, int position) CUSTDS_000 = (Layout.Packed(9, 0), 0);
        static (ILayout layout, int position) CUSTDS_001 = (Layout.FixedString(40), 5);
        static (ILayout layout, int position) CUSTDS_002 = (Layout.FixedString(35), 45);
        static (ILayout layout, int position) CUSTDS_003 = (Layout.FixedString(35), 80);
        static (ILayout layout, int position) CUSTDS_004 = (Layout.FixedString(30), 115);
        static (ILayout layout, int position) CUSTDS_005 = (Layout.FixedString(2), 145);
        static (ILayout layout, int position) CUSTDS_006 = (Layout.FixedString(10), 147);
        static (ILayout layout, int position) CUSTDS_007 = (Layout.FixedString(1), 157);
        static (ILayout layout, int position) CUSTDS_008 = (Layout.Packed(10, 0), 158);
        static (ILayout layout, int position) CUSTDS_009 = (Layout.FixedString(20), 164);
        static (ILayout layout, int position) CUSTDS_010 = (Layout.FixedString(5), 184);
        static (ILayout layout, int position) CUSTDS_011 = (Layout.FixedString(40), 189);
        static (ILayout layout, int position) CUSTDS_012 = (Layout.FixedString(40), 229);
        static (ILayout layout, int position) CUSTDS_013 = (Layout.FixedString(1), 269);
        static (ILayout layout, int position) CUSTDS_014 = (Layout.FixedString(1), 270);
        static (ILayout layout, int position) CUSTDS_015 = (Layout.FixedString(1), 271);
        const int extSizeCUSTDS = 272;
        private static Dictionary<string, string> CUSTOMERL1FormatIDs = new Dictionary<string, string>()
        {
            { "RCUSTOMERL1", "6su4S42+ard0ZHitdjHOFT1WPw0=" }
        };
        private static Dictionary<string, string> CAMASTERFormatIDs = new Dictionary<string, string>()
        {
            { "RCAMASTER", "7y3L1V0XJPKlqy8Kb8uq1R1kmq0=" }
        };

        private FixedDecimal<_9, _0> CMCUSTNO
        {
            get
            {
                return this.CUSTDS.GetPacked(0, 9, 0);
            }
            set
            {
                this.CUSTDS.SetPacked(value, 0, 9, 0);
            }
        }
        private FixedString<_40> CMNAME
        {
            get
            {
                return this.CUSTDS.GetString(5, 40);
            }
            set
            {
                this.CUSTDS.SetString(value, 5, 40);
            }
        }
        private FixedString<_35> CMADDR1
        {
            get
            {
                return this.CUSTDS.GetString(45, 35);
            }
            set
            {
                this.CUSTDS.SetString(value, 45, 35);
            }
        }
        private FixedString<_35> CMADDR2
        {
            get
            {
                return this.CUSTDS.GetString(80, 35);
            }
            set
            {
                this.CUSTDS.SetString(value, 80, 35);
            }
        }
        private FixedString<_30> CMCITY
        {
            get
            {
                return this.CUSTDS.GetString(115, 30);
            }
            set
            {
                this.CUSTDS.SetString(value, 115, 30);
            }
        }
        private FixedString<_2> CMSTATE
        {
            get
            {
                return this.CUSTDS.GetString(145, 2);
            }
            set
            {
                this.CUSTDS.SetString(value, 145, 2);
            }
        }
        private FixedString<_10> CMPOSTCODE
        {
            get
            {
                return this.CUSTDS.GetString(147, 10);
            }
            set
            {
                this.CUSTDS.SetString(value, 147, 10);
            }
        }
        private FixedString<_1> CMACTIVE
        {
            get
            {
                return this.CUSTDS.GetString(157, 1);
            }
            set
            {
                this.CUSTDS.SetString(value, 157, 1);
            }
        }
        private FixedDecimal<_10, _0> CMFAX
        {
            get
            {
                return this.CUSTDS.GetPacked(158, 10, 0);
            }
            set
            {
                this.CUSTDS.SetPacked(value, 158, 10, 0);
            }
        }
        private FixedString<_20> CMPHONE
        {
            get
            {
                return this.CUSTDS.GetString(164, 20);
            }
            set
            {
                this.CUSTDS.SetString(value, 164, 20);
            }
        }
        private FixedString<_5> CMUSRFLGS
        {
            get
            {
                return this.CUSTDS.GetString(184, 5);
            }
            set
            {
                this.CUSTDS.SetString(value, 184, 5);
            }
        }
        private FixedString<_40> CMCONTACT
        {
            get
            {
                return this.CUSTDS.GetString(189, 40);
            }
            set
            {
                this.CUSTDS.SetString(value, 189, 40);
            }
        }
        private FixedString<_40> CMCONEMAL
        {
            get
            {
                return this.CUSTDS.GetString(229, 40);
            }
            set
            {
                this.CUSTDS.SetString(value, 229, 40);
            }
        }
        private FixedString<_1> CMYN01
        {
            get
            {
                return this.CUSTDS.GetString(269, 1);
            }
            set
            {
                this.CUSTDS.SetString(value, 269, 1);
            }
        }
        private FixedString<_1> CMYN02
        {
            get
            {
                return this.CUSTDS.GetString(270, 1);
            }
            set
            {
                this.CUSTDS.SetString(value, 270, 1);
            }
        }
        private FixedString<_1> CMYN03
        {
            get
            {
                return this.CUSTDS.GetString(271, 1);
            }
            set
            {
                this.CUSTDS.SetString(value, 271, 1);
            }
        }
        private void PopulateBufferCUSTOMERL1(string _, AdgDataSet _dataSet)
        {
            var _table = _dataSet.GetAdgTable("*FILE");
            System.Data.DataRow _row = _table.Row;
            _row["CMCUSTNO"] = ((decimal)(CMCUSTNO));
            _row["CMNAME"] = ((string)(CMNAME));
            _row["CMADDR1"] = ((string)(CMADDR1));
            _row["CMADDR2"] = ((string)(CMADDR2));
            _row["CMCITY"] = ((string)(CMCITY));
            _row["CMSTATE"] = ((string)(CMSTATE));
            _row["CMPOSTCODE"] = ((string)(CMPOSTCODE));
            _row["CMACTIVE"] = ((string)(CMACTIVE));
            _row["CMFAX"] = ((decimal)(CMFAX));
            _row["CMPHONE"] = ((string)(CMPHONE));
            _row["CMUSRFLGS"] = ((string)(CMUSRFLGS));
            _row["CMCONTACT"] = ((string)(CMCONTACT));
            _row["CMCONEMAL"] = ((string)(CMCONEMAL));
            _row["CMYN01"] = ((string)(CMYN01));
            _row["CMYN02"] = ((string)(CMYN02));
            _row["CMYN03"] = ((string)(CMYN03));
        }
        private void PopulateFieldsCUSTOMERL1(string _, AdgDataSet _dataSet)
        {
            var _table = _dataSet.SetActive("*FILE");
            System.Data.DataRow _row = _table.Row;
            CMCUSTNO = ((decimal)(_row["CMCUSTNO"]));
            CMNAME = ((string)(_row["CMNAME"]));
            CMADDR1 = ((string)(_row["CMADDR1"]));
            CMADDR2 = ((string)(_row["CMADDR2"]));
            CMCITY = ((string)(_row["CMCITY"]));
            CMSTATE = ((string)(_row["CMSTATE"]));
            CMPOSTCODE = ((string)(_row["CMPOSTCODE"]));
            CMACTIVE = ((string)(_row["CMACTIVE"]));
            CMFAX = ((decimal)(_row["CMFAX"]));
            CMPHONE = ((string)(_row["CMPHONE"]));
            CMUSRFLGS = ((string)(_row["CMUSRFLGS"]));
            CMCONTACT = ((string)(_row["CMCONTACT"]));
            CMCONEMAL = ((string)(_row["CMCONEMAL"]));
            CMYN01 = ((string)(_row["CMYN01"]));
            CMYN02 = ((string)(_row["CMYN02"]));
            CMYN03 = ((string)(_row["CMYN03"]));
        }
        private void PopulateBufferCAMASTER(string _, AdgDataSet _dataSet)
        {
            var _table = _dataSet.GetAdgTable("*FILE");
            System.Data.DataRow _row = _table.Row;
            _row["CACUSTNO"] = ((decimal)(CACUSTNO));
            _row["CAADDR#"] = ((decimal)(CAADDRh));
            _row["CANAME"] = ((string)(CANAME));
            _row["CAADDR1"] = ((string)(CAADDR1));
            _row["CAADDR2"] = ((string)(CAADDR2));
            _row["CACITY"] = ((string)(CACITY));
            _row["CASTATE"] = ((string)(CASTATE));
            _row["CAZIP"] = ((string)(CAZIP));
        }
        private void PopulateFieldsCAMASTER(string _, AdgDataSet _dataSet)
        {
            var _table = _dataSet.SetActive("*FILE");
            System.Data.DataRow _row = _table.Row;
            CACUSTNO = ((decimal)(_row["CACUSTNO"]));
            CAADDRh = ((decimal)(_row["CAADDR#"]));
            CANAME = ((string)(_row["CANAME"]));
            CAADDR1 = ((string)(_row["CAADDR1"]));
            CAADDR2 = ((string)(_row["CAADDR2"]));
            CACITY = ((string)(_row["CACITY"]));
            CASTATE = ((string)(_row["CASTATE"]));
            CAZIP = ((string)(_row["CAZIP"]));
        }
        private void PopulateBufferCUSTDELIV_FileSFLC(AdgDataSet _dataSet)
        {
        }
        private void PopulateFieldsCUSTDELIV_FileSFLC(AdgDataSet _dataSet)
        {
        }
        private void PopulateBufferCUSTDELIV_FileSFL1(AdgDataSet _dataSet)
        {
            var _table = _dataSet.GetAdgTable("SFL1");
            System.Data.DataRow _row = _table.Row;
            _row["SFLSEL"] = ((string)(SFLSEL));
            _row["SFLCUST#"] = ((decimal)(SFLCUSTh));
            _row["SFLCUST"] = ((string)(SFLCUST));
            _row["SFLCITY"] = ((string)(SFLCITY));
            _row["SFLZIP"] = ((string)(SFLZIP));
        }
        private void PopulateFieldsCUSTDELIV_FileSFL1(AdgDataSet _dataSet)
        {
            var _table = _dataSet.GetAdgTable("SFL1");
            System.Data.DataRow _row = _table.Row;
            SFLSEL = ((string)(_row["SFLSEL"]));
            SFLCUSTh = ((decimal)(_row["SFLCUST#"]));
            SFLCUST = ((string)(_row["SFLCUST"]));
            SFLCITY = ((string)(_row["SFLCITY"]));
            SFLZIP = ((string)(_row["SFLZIP"]));
        }
        private void PopulateBufferCUSTDELIV_FileKEYS(AdgDataSet _dataSet)
        {
        }
        private void PopulateFieldsCUSTDELIV_FileKEYS(AdgDataSet _dataSet)
        {
        }
        private void PopulateBufferCUSTDELIV_File(string _recordFormatName, AdgDataSet _dataSet)
        {
            if (string.Equals(_recordFormatName, "SFLC", System.StringComparison.CurrentCultureIgnoreCase))
            {
                this.PopulateBufferCUSTDELIV_FileSFLC(_dataSet);
            }
            else
            {
                if (string.Equals(_recordFormatName, "SFL1", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.PopulateBufferCUSTDELIV_FileSFL1(_dataSet);
                }
                else
                {
                    if (string.Equals(_recordFormatName, "KEYS", System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        this.PopulateBufferCUSTDELIV_FileKEYS(_dataSet);
                    }
                    else
                    {
                        throw new System.InvalidOperationException($"Invalid record format {_recordFormatName} while writing file CUSTDELIV_File.");
                    }
                }
            }
        }
        private void PopulateFieldsCUSTDELIV_File(string _recordFormatName, AdgDataSet _dataSet)
        {
            if (string.Equals(_recordFormatName, "SFLC", System.StringComparison.CurrentCultureIgnoreCase))
            {
                this.PopulateFieldsCUSTDELIV_FileSFLC(_dataSet);
            }
            else
            {
                if (string.Equals(_recordFormatName, "SFL1", System.StringComparison.CurrentCultureIgnoreCase))
                {
                    this.PopulateFieldsCUSTDELIV_FileSFL1(_dataSet);
                }
                else
                {
                    if (string.Equals(_recordFormatName, "KEYS", System.StringComparison.CurrentCultureIgnoreCase))
                    {
                        this.PopulateFieldsCUSTDELIV_FileKEYS(_dataSet);
                    }
                    else
                    {
                        throw new System.InvalidOperationException($"Invalid record format {_recordFormatName} while reading file CUSTDELIV_File.");
                    }
                }
            }
        }
    }
}