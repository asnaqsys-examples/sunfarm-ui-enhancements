﻿// Translated from Encore to C# on 9/7/2023 at 9:29:34 AM by ASNA Encore Translator® version 4.0.17.0
// ASNA Monarch(R) version 11.4.12.0 at 8/25/2023
// Migrated source location: library ERCAP, file QRPGSRC, member ORDHINQ

using ASNA.QSys.Runtime;
using ASNA.DataGate.Common;
using ACME.SunFarmCustomers_Job;

using System;
using ASNA.QSys.Runtime.JobSupport;


namespace ACME.SunFarm
{
    [ActivationGroup("*DFTACTGRP"), System.ComponentModel.Description("Order Header Inquiry and Maintenance")]
    [ProgramEntry("_ENTRY")]
    public partial class ORDHINQ : Program
    {
        protected dynamic _DynamicCaller;

        WorkstationFile ORDHDSPF;
        DatabaseFile OrderHdrL2;
        DatabaseFile OrderHdrL1;
        DatabaseFile OrderHdrL1_ReadOnly;
        DatabaseFile CustomerL1;
        //********************************************************************
        DataStructure _DS8 = new (3);
        FixedDecimal<_3, _0> hpNbrs { get => _DS8.GetZoned(0, 3, 0); set => _DS8.SetZoned(value, 0, 3, 0); } 

        FixedDecimalArray<_20, _9, _0> pNumbers;
        FixedString<_7> MID;
        FixedString<_30> MTX;
        FixedString<_1> LockRec;
        FixedDecimal<_5, _0> X;
        FixedDecimal<_9, _0> SVOrdnum;
        FixedDecimal<_13, _2> TempWgt;
        // Order      DS
        DataStructure OrdhDS;

        //********************************************************************

        // Fields defined in main C-Specs declared now as Global fields (Monarch generated)
        FixedString<_1> AddUpd;
        FixedDecimal<_8, _0> CKorddate;
        FixedDecimal<_9, _0> CustNo;
        FixedString<_1> Delall;
        FixedString<_10> pCsrFld;
        FixedString<_10> pResult;
        FixedDecimal<_4, _0> savrrn;
        FixedDecimal<_4, _0> sflrrn;
        FixedDecimal<_9, _0> TEMPNO;
        FixedString<_1> WorkTemp1;

        // PLIST(s) relocated by Monarch
        
        // KLIST(s) relocated by Monarch
        
#region Constructor and Dispose 
        public ORDHINQ()
        {
            _instanceInit();
            // Initialization of Data Structure fields (Monarch generated)
            Reset_hpNbrs();

            CustomerL1.Open(CurrentJob.Database, AccessMode.Read, false, false, ServerCursors.Default);
            OrderHdrL1.Open(CurrentJob.Database, AccessMode.RWCD, false, false, ServerCursors.Default);
            OrderHdrL1_ReadOnly.Open(CurrentJob.Database, AccessMode.Read, false, false, ServerCursors.Default);
            OrderHdrL2.Open(CurrentJob.Database, AccessMode.Read, false, false, ServerCursors.Default);
        }

        override public void Dispose(bool disposing)
        {
            if (disposing)
            {
                
                ORDHDSPF.Close();
                OrderHdrL2.Close();
                OrderHdrL1.Close();
                OrderHdrL1_ReadOnly.Close();
                CustomerL1.Close();
            }
            base.Dispose(disposing);
        }


#endregion
        void StarEntry(int cparms)
        {
            Indicator _LR = '0';
            int _RrnTmp = 0;
            FixedDecimal<_9, _0> _ORDNUMProxy = 0;
            do
            {
                // KLIST "KeyMastL2" moved by Monarch to global scope.
                //********************************************************************
                CustomerL1.Chain(true, CustNo);
                SCRCUST = EditCode.Apply(CMCUSTNO, 0, 9, EditCodes.Z, "").Trim() + " " + CMNAME;
                SCRPHONE = ((string)CMPHONE).Trim();
                if (CMFAX != 0m)
                {
                    SCRFAX = CMFAX.MoveLeft(SCRFAX);
                    SCRFAX = "(" + ((string)SCRFAX).Substring(0, 3) + ") " + ((string)SCRFAX).Substring(3, 3) + "-" + ((string)SCRFAX).Substring(6, 4);
                }
                //--------------------------------------------------------------------
                do
                {
                    _IN[90] = '0';
                    _IN[77] = '0';
                    ORDHDSPF.Write("MSGSFC", _IN.Array);
                    ORDHDSPF.Write("KEYS", _IN.Array);
                    ORDHDSPF.ExFmt("SFLC", _IN.Array);
                    SFFILESTAT = "";
                    //--------------------------------------------------------------------
                    if ((bool)_IN[12])
                    {
                        _INLR = '1';
                        break;
                        // PageUp-RollDown
                    }
                    else if ((bool)_IN[50])
                    {
                        OrderHdrL2.Seek(SeekMode.SetLL, CustNo, ORDNUM);
                        LoadSfl();
                        // PageDown-RollUp
                    }
                    else if ((bool)_IN[51])
                    {
                        ReadBack();
                        LoadSfl();
                    }
                    else if (SETORDNUM != 0)
                    {
                        ORDNUM = SETORDNUM;
                        OrderHdrL2.Seek(SeekMode.SetLL, CustNo, ORDNUM);
                        LoadSfl();
                    }
                    else if ((bool)_IN[6])
                    {
                        SVOrdnum = ORDNUM;
                        OrderHdrL1_ReadOnly.Seek(SeekMode.SetGT, 999999999m);
                        OrderHdrL1_ReadOnly.ReadPrevious(true); // Removed Access(*NoLock)
                        OrderHdrL1.StatusCode = OrderHdrL1_ReadOnly.StatusCode;
                        TEMPNO = ORDNUM + 10;
                        ORDNUM = TEMPNO;
                        ORDCUST = CustNo;
                        ORDDATE = DateTime.Now.TimestampToDate();
                        ORDSHPDATE = DateTime.Now.TimestampToDate();
                        ORDDELDATE = 0;
                        ORDSHPVIA = 0;
                        ORDAMOUNT = 0;
                        OrderHdrL1.Write();
                        AddUpd = "A";
                        DTORDNUM = TEMPNO;
                        SFORDNUM = TEMPNO;
                        DTORDDATE = ORDDATE;
                        DTSHPDATE = ORDSHPDATE;
                        DTDELDATE = ORDDELDATE;
                        DTSHPVIA = ORDSHPVIA;
                        _IN[30] = '1';
                        RcdUpdate();
                    }
                    else
                    {
                        _IN[30] = '0';
                        _IN[66] = '0';
                        savrrn = sflrrn;
                        pNumbers.Initialize(0m);
                        hpNbrs = 0m;
                        do
                        {
                            _RrnTmp = (int)sflrrn;
                            _IN[66] = ORDHDSPF.ReadNextChanged("SFL1", ref _RrnTmp, _IN.Array) ? '0' : '1';
                            sflrrn = _RrnTmp;
                            if (!(bool)_IN[66])
                            {
                                if (SFSEL == 6)
                                {
                                    ORDNUM = SFORDNUM;
                                    _ORDNUMProxy = ORDNUM;
                                    // Print the order.
                                    _DynamicCaller.CallD("ACME.SunFarm.ORDPRINT", out _LR, ref CustNo, ref _ORDNUMProxy);
                                    ORDNUM = _ORDNUMProxy;
                                    LockRec = "N";
                                    OrdChk();
                                    ClearSel();
                                }
                                else if (SFSEL == 3)
                                {
                                    ORDNUM = SFORDNUM;
                                    Delall = "";
                                    _ORDNUMProxy = ORDNUM;
                                    // Maintainance.
                                    _DynamicCaller.CallD("ACME.SunFarm.ORDDTLINQ", out _LR, ref CustNo, ref _ORDNUMProxy, ref Delall);
                                    ORDNUM = _ORDNUMProxy;
                                    LockRec = "N";
                                    OrdChk();
                                    SFORDAMT = ORDAMOUNT;
                                    ClearSel();
                                }
                                else if (SFSEL == 2)
                                {
                                    // Maintainance.
                                    ORDHDSPF.ChainByRRN("SFL1", (int)sflrrn, _IN.Array);
                                    AddUpd = "U";
                                    RcdUpdate();
                                }
                            }
                        } while (!((bool)_IN[66]));
                        sflrrn = savrrn;
                    }
                } while (!((bool)_IN[12]));
                ///SPACE 3
                //*********************************************************************
                // UPDATE THE ORDER RECORD
                //*********************************************************************
            } while (!(bool)_INLR);
        }
        void RcdUpdate()
        {
            Indicator _LR = '0';
            FixedDecimal<_9, _0> _ORDNUMProxy = 0;
            if (!(bool)_IN[6])
            {
                // If not a new order.
                ClearSel();
            }
            ORDNUM = SFORDNUM;
            LockRec = "N";
            OrdChk();
            DTORDNUM = ORDNUM;
            DTORDDATE = ORDDATE;
            DTSHPDATE = ORDSHPDATE;
            DTDELDATE = ORDDELDATE;
            DTSHPVIA = ORDSHPVIA;
            TempWgt = ORDWEIGHT / 16;
            DTWEIGHT = EditCode.Apply(TempWgt, 2, 13, EditCodes.One, "").Trim() + " Lbs";
            _IN[40] = '1';
            _IN[41] = '0';
            _IN[42] = '0';
            _IN[43] = '0';
            _IN[44] = '0';
            _IN[99] = '0';
            //-------------------------------------------------------
            do
            {
                ORDHDSPF.Write("MSGSFC", _IN.Array);
                ORDHDSPF.Write("MYWINDOW", _IN.Array);
                ORDHDSPF.ExFmt("ORDHREC", _IN.Array);
                _IN[40] = '0';
                _IN[41] = '0';
                _IN[42] = '0';
                _IN[43] = '0';
                _IN[44] = '0';
                ClearMsgs();
                _IN[30] = '0';
                if ((bool)_IN[12])
                    break;
                else if ((bool)_IN[4])
                {
                    pCsrFld = "SHIPVIA";
                    _DynamicCaller.CallD("ACME.SunFarm.CUSTPRMPT", out _LR, ref pCsrFld, ref pResult);
                    WorkTemp1 = (string)pResult;
                    DTSHPVIA = WorkTemp1.MoveRight(DTSHPVIA);
                    // Delete  Order
                    // Delete  The order line items first
                }
                else if ((bool)_IN[11])
                {
                    ORDNUM = SFORDNUM;
                    Delall = "Y";
                    _ORDNUMProxy = ORDNUM;
                    _DynamicCaller.CallD("ACME.SunFarm.ORDDTLINQ", out _LR, ref CustNo, ref _ORDNUMProxy, ref Delall);
                    ORDNUM = _ORDNUMProxy;
                    LockRec = "Y";
                    OrdChk();
                    if (!(bool)_IN[80])
                        OrderHdrL1.Delete();
                    ORDHDSPF.ChainByRRN("SFL1", (int)sflrrn, _IN.Array);
                    SFORDDATE = DateTime.MinValue;
                    SFSHPDATE = DateTime.MinValue;
                    SFDELDATE = 0;
                    SFORDAMT = 0;
                    SFSHPVIA = 0m;
                    SFFILESTAT = "*Del";
                    // Set the color
                    _IN[60] = '1';
                    ORDHDSPF.Update("SFL1", _IN.Array);
                    _IN[60] = '0';
                    // Delete msg
                    MID = "ORD0003";
                    MTX = ORDNUM.MoveRight(MTX);
                    _DynamicCaller.CallD("ACME.SunFarm.MSGLOD", out _LR, ref MID, ref MTX);
                    break;
                    // Add/update on the Enter key
                }
                else
                {
                    if (AddUpd == "A")
                    {
                        EditFlds();
                        if ((bool)_IN[99])
                        {
                            // Any errors?
                            continue;
                        }
                        OrderHdrL1.Chain(true, TEMPNO);
                        UpdDbFlds();
                        OrderHdrL1.Update();
                        OrderHdrL2.Seek(SeekMode.SetLL, CustNo);
                        LoadSfl();
                        // Added message
                        MID = "ORD0001";
                        MTX = ORDNUM.MoveLeft(MTX);
                        _DynamicCaller.CallD("ACME.SunFarm.MSGLOD", out _LR, ref MID, ref MTX);
                        break;
                        // Update the database
                    }
                    else
                    {
                        EditFlds();
                        if ((bool)_IN[99])
                        {
                            // Any errors?
                            continue;
                        }
                        LockRec = "Y";
                        OrdChk(); //Reread the record.
                        UpdDbFlds();
                        OrderHdrL1.Update();
                        ORDHDSPF.ChainByRRN("SFL1", (int)sflrrn, _IN.Array);
                        SFORDNUM = ORDNUM;
                        SFORDDATE = ORDDATE;
                        SFSHPDATE = ORDSHPDATE;
                        SFDELDATE = ORDDELDATE;
                        SFORDAMT = ORDAMOUNT;
                        SFSHPVIA = ORDSHPVIA;
                        SFFILESTAT = "";
                        ORDHDSPF.Update("SFL1", _IN.Array);
                        _IN[12] = '1';
                        // Updated message
                        MID = "ORD0002";
                        MTX = ORDNUM.MoveLeft(MTX);
                        _DynamicCaller.CallD("ACME.SunFarm.MSGLOD", out _LR, ref MID, ref MTX);
                    }
                    // Re-open for the next update
                    LockRec = "N";
                    OrdChk();
                }
            } while (!((bool)_IN[12]));
        }
        //*********************************************************************
        //  EDIT THE SCREEN FIELDS
        //*********************************************************************
        void EditFlds()
        {
            Indicator _LR = '0';
            _IN[40] = '0';
            _IN[41] = '0';
            _IN[42] = '0';
            _IN[43] = '0';
            _IN[44] = '0';
            _IN[99] = '0';
            CKorddate = DTORDDATE.MoveRight(CKorddate);
            if (CKorddate == 0)
            {
                _IN[40] = '1';
                _IN[99] = '1';
                MID = "ORD0004";
                MTX = "Order Date";
            }
            else if (DTSHPVIA == 0)
            {
                _IN[42] = '1';
                _IN[99] = '1';
                MID = "Ord0005";
                MTX = "Ship Via";
            }
            if ((bool)_IN[99])
            {
                _DynamicCaller.CallD("ACME.SunFarm.MSGLOD", out _LR, ref MID, ref MTX);
            }
        }
        //*********************************************************************
        //  UPDATE THE DATABASE FIELDS
        //*********************************************************************
        void UpdDbFlds()
        {
            ORDNUM = DTORDNUM;
            ORDDATE = DTORDDATE;
            ORDSHPDATE = DTSHPDATE;
            ORDDELDATE = DTDELDATE;
            ORDSHPVIA = DTSHPVIA;
        }
        //********************************************************************
        //   CHECK THE ORDER NUMBER
        //********************************************************************
        void OrdChk()
        {
            if (LockRec == "N")
            {
                _IN[80] = OrderHdrL1_ReadOnly.Chain(true, ORDNUM) ? '0' : '1'; // Removed Access(*NoLock)
                OrderHdrL1.StatusCode = OrderHdrL1_ReadOnly.StatusCode;
            }
            else
            {
                _IN[80] = OrderHdrL1.Chain(true, ORDNUM) ? '0' : '1';
            }
        }
        //*********************************************************************
        //  Load Sfl Subroutine
        //*********************************************************************
        void LoadSfl()
        {
            _IN[61] = '0';
            _IN[90] = '1';
            ORDHDSPF.Write("SFLC", _IN.Array);
            _IN[76] = '0';
            _IN[90] = '0';
            SFFILESTAT = "";
            sflrrn = 0m;
            _IN[77] = OrderHdrL2.ReadNextEqual(true, CustNo) ? '0' : '1';
            //----------------------------------------------------------
            while (!(bool)_IN[77] && (sflrrn < 9999))
            {
                /* EOF or full s/f. */
                SFORDNUM = ORDNUM;
                SFORDDATE = ORDDATE;
                SFSHPDATE = ORDSHPDATE;
                SFDELDATE = ORDDELDATE;
                SFORDAMT = ORDAMOUNT;
                SFSHPVIA = ORDSHPVIA;
                if ((bool)_IN[61])
                {
                    //Save the color of
                    SFCOLOR = "W";
                }
                else
                {
                    SFCOLOR = "G";
                }
                sflrrn = sflrrn + 1;
                ORDHDSPF.WriteSubfile("SFL1", (int)sflrrn, _IN.Array);
                _IN[61] = (!(bool)_IN[61]);
                _IN[77] = OrderHdrL2.ReadNextEqual(true, CustNo) ? '0' : '1';
            }
            // Any records found?
            if (sflrrn == 0m)
            {
                sflrrn = 1;
                SFORDNUM = 0;
                ORDNUM = 0m;
                SFORDDATE = DateTime.MinValue;
                SFSHPDATE = DateTime.MinValue;
                SFDELDATE = 0;
                SFFILESTAT = "NoOr";
                SFORDAMT = 0;
                SFSHPVIA = 0;
                ORDHDSPF.WriteSubfile("SFL1", (int)sflrrn, _IN.Array);
                SFFILESTAT = "";
            }
        }
        //*********************************************************************
        //  Read Backwards for a PageDown
        //*********************************************************************
        void ReadBack()
        {
            _IN[76] = '0';
            _IN[77] = '0';
            X = 0m;
            ORDHDSPF.ChainByRRN("SFL1", 1, _IN.Array); //Get the top ord nbr
            ORDNUM = SFORDNUM;
            OrderHdrL2.Chain(true, CustNo, ORDNUM);
            _IN[76] = OrderHdrL2.ReadPreviousEqual(true, CustNo) ? '0' : '1';
            while (!(bool)_IN[76] && (X < 10))
            {
                /* EOF or full s/f. */
                X = X + 1;
                _IN[76] = OrderHdrL2.ReadPreviousEqual(true, CustNo) ? '0' : '1';
            }
            if ((bool)_IN[76])
            {
                //Top of file or diff
                ORDNUM = 0m;
                OrderHdrL2.Seek(SeekMode.SetLL, CustNo, ORDNUM);
            }
        }
        //*********************************************************************
        // CLEAR THE SELECTION NUMBER
        //*********************************************************************
        void ClearSel()
        {
            SFSEL = 0m;
            _IN[61] = (SFCOLOR == "W");
            ORDHDSPF.Update("SFL1", _IN.Array);
        }
        //*********************************************************************
        // CLEAR THE MESSAGE QUEUE
        //*********************************************************************
        void ClearMsgs()
        {
            Indicator _LR = '0';
            _DynamicCaller.CallD("ACME.SunFarm.MSGCLR", out _LR);
            MID = "";
        }
        //*********************************************************************
        //     * Init Subroutine
        //*********************************************************************
        void PROCESS_STAR_INZSR()
        {
            Indicator _LR = '0';
            OrderHdrL2.Seek(SeekMode.SetLL, CustNo);
            LoadSfl();
            _IN[75] = '1';
            MID = "";
            aPGMQ = "*";
            _DynamicCaller.CallD("ACME.SunFarm.MSGCLR", out _LR);
        }

        // Message handling parm list
        // PLIST "#PLMSG" moved by Monarch to global scope.
        void Reset_hpNbrs()
        {
            hpNbrs = 0;
        }

#region Entry and activation methods for *ENTRY

        int _parms;

        bool _isInitialized;
        void __ENTRY(ref FixedDecimal<_9, _0> _CustNo)
        {
            int cparms = 1;
            bool _cleanup = true;
            CustNo = _CustNo;
            try
            {
                _parms = cparms;
                if (!_isInitialized)
                {
                    PROCESS_STAR_INZSR();
                    _isInitialized = true;
                }
                StarEntry(cparms);
            }
            catch(Return)
            {
            }
            catch(System.Threading.ThreadAbortException)
            {
                _cleanup = false;
                _INLR = '1';
            }
            finally
            {
                if (_cleanup)
                    _CustNo = CustNo;
            }
        }

        public static void _ENTRY(ICaller _caller, out Indicator __inLR, ref FixedDecimal<_9, _0> CustNo)
        {
            FixedDecimal<_9, _0> _pCustNo = CustNo;
            __inLR = RunProgram<ORDHINQ>(_caller, (ORDHINQ _instance) => _instance.__ENTRY(ref _pCustNo));
            CustNo = _pCustNo;
        }
#endregion

        void _instanceInit()
        {
            X = 0m;
            pNumbers = new FixedDecimalArray<_20, _9, _0>((FixedDecimal<_9, _0>[])null);

            _DynamicCaller = new DynamicCaller(this);
            ORDHDSPF = new WorkstationFile(PopulateBufferORDHDSPF, PopulateFieldsORDHDSPF, null, "ORDHDSPF", "/SunFarmViews/ORDHDSPF");
            ORDHDSPF.Open();
            OrderHdrL2 = new DatabaseFile(PopulateBufferOrderHdrL2, PopulateFieldsOrderHdrL2, null, "OrderHdrL2", "*LIBL/OrderHdrL2", OrderHdrL2FormatIDs)
            { IsDefaultRFN = true };
            OrderHdrL1 = new DatabaseFile(PopulateBufferOrderHdrL1, PopulateFieldsOrderHdrL1, null, "OrderHdrL1", "*LIBL/OrderHdrL1", OrderHdrL1FormatIDs, blockingFactor : 0)
            { IsDefaultRFN = true };
            OrderHdrL1_ReadOnly = new DatabaseFile(PopulateBufferOrderHdrL1_ReadOnly, PopulateFieldsOrderHdrL1_ReadOnly, null, "OrderHdrL1_ReadOnly", "*LIBL/OrderHdrL1", OrderHdrL1_ReadOnlyFormatIDs)
            { IsDefaultRFN = true };
            CustomerL1 = new DatabaseFile(PopulateBufferCustomerL1, PopulateFieldsCustomerL1, null, "CustomerL1", "*LIBL/CustomerL1", CustomerL1FormatIDs)
            { IsDefaultRFN = true };
            OrdhDS = new (extSizeOrdhDS, OrdhDS_000, OrdhDS_001, OrdhDS_002, OrdhDS_003, OrdhDS_004, OrdhDS_005, OrdhDS_006, OrdhDS_007, 
                OrdhDS_008);
        }
    }

    // /Error There are 1 NoLock Sequential Read operations. Using *NoLock on a file opened for *Update is not supported with DSS .NET
    // /Error There are 1 NoLock CHAIN operations. Using *NoLock on a file opened for *Update is not supported with DSS .NET
}
