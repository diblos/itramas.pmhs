﻿Imports DataExchangeClass.Common
'Imports System.Net
Imports System.Xml
Imports System.IO

Public Class MainForm

    Public Const AgencyName As String = "FSQD"
    Public Const WINDOWS_TEXT_TITLE As String = "PMHS Data Post"
    Dim nSize As Size

    Dim dummyDataCA As DataExchangeClass.ConsigmentApprovalResponse
    Dim dummyDataFC As DataExchangeClass.FoodCodeMaster

    Dim tmpData As DataTable 'for flag update

#Region "Form Action"
    Public Delegate Sub AddItemsToListBoxDelegate( _
           ByVal ToListBox As ListBox, _
           ByVal AddText As String)

    Private Sub AddItemsToListBox(ByVal ToListBox As ListBox, _
                                 ByVal AddText As String)
        If ToListBox.Items.Count > 1000 Then
            ToListBox.Items.Clear()
        End If

        ToListBox.Items.Add(AddText)
        ToListBox.SetSelected(ListBox1.Items.Count - 1, True)
        ToListBox.SetSelected(ListBox1.Items.Count - 1, False)
    End Sub

    Public Sub lstMsgs(ByVal item As Object)

        If (ListBox1.InvokeRequired) Then
            ListBox1.Invoke( _
                    New AddItemsToListBoxDelegate(AddressOf AddItemsToListBox), _
                    New Object() {ListBox1, CStr(item)})

        Else
            If Me.ListBox1.Items.Count > 1000 Then
                ListBox1.Items.Clear()
            End If

            Me.ListBox1.Items.Add(CStr(item))
            Me.ListBox1.SetSelected(ListBox1.Items.Count - 1, True)
            Me.ListBox1.SetSelected(ListBox1.Items.Count - 1, False)
        End If

    End Sub

    Private Sub ListBox1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Dim listbox As ListBox = DirectCast(sender, ListBox)
        If listbox.Items.Count > 0 Then
            MsgBox(listbox.SelectedItem.ToString)
        End If
    End Sub

    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        InitializeDummyData()

        lstMsgs("Started at " & Now)
        ButtonSend.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        If RadioWS.Checked Then
            '=================================================================================================
            'SOAP
            '=================================================================================================
            If RadioCA.Checked Then
                lstMsgs("Sending Consigment Approval Response Data to uCustom Webservice")
                If CheckBoxDB.Checked Then
                    tmpData = Nothing
                    For Each item As DataExchangeClass.ConsigmentApprovalResponse In LoadCAData()
                        SOAPCall("CADATA", GetCA(item)) 'from DB
                    Next
                    'UPDATE HERE
                    If Not IsNothing(tmpData) Then
                        lstMsgs("Updating flags...")
                        Dim k As New DataExchangeClass.Data
                        For Each x As DataRow In tmpData.Rows
                            k.UpdateSMKCFlag(x("IMG_ID"), x("flag")) 'Should be moved to SOAP CallBack for Accurate Result
                            Application.DoEvents()
                        Next
                    End If
                Else
                    SOAPCall("CADATA", GetCA(dummyDataCA)) '1 dummy
                End If
            Else
                lstMsgs("This service isn't available!")
                'lstMsgs("Sending Food Code Master File Data to uCustom Webservice")
                'SOAPCall("FCDATA", GetFC)
            End If
        Else
            '=================================================================================================
            'BATCH
            '=================================================================================================
            Dim fileName As String
            If RadioCA.Checked Then
                'CONSIGNMENT APPROVAL RESPONSE [FOSIM TO UCUSTOM]
                '=================================================================================================
                'The batch file will pick up every 5 minutes by uCustoms Integration Server. 
                'The batch file will then upload into uCustoms sFTP Server for the use of the system.
                '-------------------------------------------------------------------------------------------------
                lstMsgs("Sending Consigment Approval Response Data to uCustom FTP Folder")
                If CheckBoxDB.Checked Then
                    tmpData = Nothing
                    fileName = GenerateCVS(LoadCAData, "RESCA", True) 'from DB
                Else
                    fileName = GenerateCVS(dummyDataCA, "RESCA", True) '1 dummy
                End If

                If Not fileName = Nothing Then
                    Try
                        lstMsgs("Created: " & fileName)
                        'UploadFtpFile("FoSIM_CA_OUTBOUND", fileName)
                        MoveAfile(fileName, PerfectPath(CA_FTP_FOLDER_PATH) & Path.GetFileName(fileName))
                        lstMsgs("Uploaded: " & fileName & " to " & Path.GetFileName(CA_FTP_FOLDER_PATH))
                        If Not IsNothing(tmpData) Then
                            lstMsgs("Updating flags...")
                            Dim k As New DataExchangeClass.Data
                            For Each x As DataRow In tmpData.Rows
                                k.UpdateSMKCFlag(x("IMG_ID"), x("flag"))
                                Application.DoEvents()
                            Next
                        End If
                    Catch ex As Exception
                        lstMsgs(ex.Message)
                    End Try
                End If
            Else
                'FOOD CODE MASTER FILE [FOSIM TO UCUSTOM]
                '=================================================================================================
                'The batch file will generate by uCustoms System once a month if there have new/updated food code. 
                'The batch file will then upload into sFTP Server for the use of the system.
                '-------------------------------------------------------------------------------------------------
                tmpData = Nothing
                lstMsgs("Sending Food Master File Data to uCustom FTP Folder")
                If CheckBoxDB.Checked Then
                    fileName = GenerateCVS(LoadFCData, "FC") 'from DB
                Else
                    fileName = GenerateCVS(dummyDataFC, "FC") '1 dummy
                End If

                If Not fileName = Nothing Then
                    Try
                        lstMsgs("Created: " & fileName)
                        'UploadFtpFile("UC_CD_INBOUND", fileName)
                        MoveAfile(fileName, PerfectPath(FC_FTP_FOLDER_PATH) & Path.GetFileName(fileName))
                        lstMsgs("Uploaded: " & fileName & " to " & Path.GetFileName(FC_FTP_FOLDER_PATH))
                        If Not IsNothing(tmpData) Then
                            lstMsgs("Updating flags...")
                            Dim k As New DataExchangeClass.Data
                            For Each x As DataRow In tmpData.Rows
                                k.UpdateFoodFlag(x("FCO_ID"))
                                Application.DoEvents()
                            Next
                        End If
                    Catch ex As Exception
                        lstMsgs(ex.Message)
                    End Try
                End If
                '=================================================================================================
            End If
            
        End If
        lstMsgs("Finished at " & Now)
        Me.Cursor = Cursors.Default
        ButtonSend.Enabled = True
        GC.Collect()
    End Sub

#End Region

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nSize = Me.Size
        Me.MaximumSize = nSize

        Me.Text = WINDOWS_TEXT_TITLE
        ReadConfiguration()

        TestObject2JSON()

    End Sub

    Private Sub TestObject2JSON()
        Dim s As New DataExchangeClass.TripUpdates
        With s
            .vehicle_reg_no = "WWW8080"
            .trip_id = 12231
            .stop_sequence = 200
            .exact_timestamp = Now
            .arrival = DateAdd(DateInterval.Hour, 1, Now)
            .security_key = "23a84a230f00"
        End With

        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(s, Formatting.Indented)

        MsgBox(json)

    End Sub

    Private Function LoadCAData() As List(Of DataExchangeClass.ConsigmentApprovalResponse)
        Dim k As New DataExchangeClass.Data

        Dim newlist As New List(Of DataExchangeClass.ConsigmentApprovalResponse)
        Dim dtCA As DataTable = k.GetResponseData()

        For Each row As DataRow In dtCA.Rows
            Dim tmpObj As New DataExchangeClass.ConsigmentApprovalResponse
            With tmpObj
                .Data_Header = row("DataHeader")
                .UCustomRegistrationID = IIf(IsDBNull(row("customreg")), "", row("customreg"))
                .FQC_Preassigned_control_no = row("FQC")
                .Item_number = row("IMGLine")
                .HS_code = IIf(IsDBNull(row("HScode")), "", row("HScode"))
                .Food_Code = row("IMGFoodCode")
                .exam_level = IIf(IsDBNull(row("IMGCurrLvl")), "", row("IMGCurrLvl"))
                .Process_date = CDate(row("LMDT")).ToString("yyyy-MM-dd")
                .Process_date_2 = ""
                .Process_time = CDate(row("LMDT")).ToString("HH:mm:ss")
                .Processing_officer_name = row("LMBY")
                .Processing_officer_name_2 = ""
                .Officer_Designation = IIf(IsDBNull(row("IMHReplyDesign")), "", row("IMHReplyDesign"))
                .Comment_from_FQC = row("IMGAGNotes")
                'HERE, CHECKING & UPDATE FLAG
                'A-Approved, R-Rejection, N-Not applicable,I-Request Inspection ( will update the status code after inspection done)
                'C- Conditional Release
                .Action_code = IIf(IsDBNull(row("IMGStatusPurpose")), "", row("IMGStatusPurpose"))

                Select Case IIf(IsDBNull(row("IMGpstatus")), "", row("IMGpstatus"))
                    Case "R"
                        .Approval_Status = "A"
                        row("flag") = "C"
                    Case "D"
                        If .Action_code = "CR" Then
                            .Approval_Status = "C"
                        Else
                            .Approval_Status = "I"
                        End If
                        row("flag") = "1"
                    Case "J"
                        .Approval_Status = "R"
                        row("flag") = "C"
                    Case Else
                        .Approval_Status = "N"
                        row("flag") = "C"
                End Select

                .Remarks = IIf(IsDBNull(row("IMHReplyRemarks")), "", row("IMHReplyRemarks"))
                .Approval_reference_no = ""
                .Approval_reference_no_2 = ""
            End With
            newlist.Add(tmpObj)
        Next

        tmpData = dtCA.Copy

        Return newlist

    End Function

    Private Function LoadFCData() As List(Of DataExchangeClass.FoodCodeMaster)
        Dim k As New DataExchangeClass.Data

        Dim newlist As New List(Of DataExchangeClass.FoodCodeMaster)
        Dim dtFC As DataTable = k.GetFoodCodeData()

        For Each row As DataRow In dtFC.Rows
            Dim tmpObj As New DataExchangeClass.FoodCodeMaster
            With tmpObj
                .FCOCode = row("FCOCode")
                .FCODescription = row("FCODescription")
                .HS_ID = row("HS_ID")
                .RStatus = row("RStatus")
                .LastModifiedBy = row("LMBY")
                .LastModifiedDate = row("LMDT")
            End With
            newlist.Add(tmpObj)
        Next

        tmpData = dtFC.Copy

        Return newlist

    End Function

    Private Sub InitializeDummyData()

        'DataHeader	customreg	FQC	IMGLine	HScode	IMGCurrLvl	IMGFoodCode	LMBY	LMDT	IMHReplyDesign	IMGAGNotes	IMGPStatus	IMGStatusPurpose	IMHReplyRemarks
        'FQC001	K122015101004808	0709.60.1000 	3	NULL	5	V0103523	MOHD SUHAIMIE B. NOH	2015-01-21 19:57:23.647			R	R	Konsaimen diperiksa dan dilepaskan
        dummyDataCA = New DataExchangeClass.ConsigmentApprovalResponse
        With dummyDataCA

            .Data_Header = "FQC001"
            .UCustomRegistrationID = "K122015101004808"
            .FQC_Preassigned_control_no = "" '"0709.60.1000"
            .Item_number = "1"
            .HS_code = "1902.19.900"
            .Food_Code = "V0103523"
            .exam_level = "5"
            .Process_date = "2015-01-21"
            .Process_date_2 = ""
            .Process_time = "19:57:23"
            .Processing_officer_name = "MOHD SUHAIMIE B. NOH"
            .Processing_officer_name_2 = ""
            .Officer_Designation = "PPKP U29"
            .Comment_from_FQC = ""
            .Approval_Status = "N"
            .Action_code = "R"
            .Remarks = "Konsaimen diperiksa dan dilepaskan"
            .Approval_reference_no = ""
            .Approval_reference_no_2 = ""

        End With

        'FCOCode	FCODescription	HS_ID	RStatus	LMBY	LMDT
        'A0301001	Food Colouring Substance - Allura Red Ac (16035)	2413	2	ADMIN	2005-11-17 13:15:04.000
        dummyDataFC = New DataExchangeClass.FoodCodeMaster
        With dummyDataFC
            .FCOCode = "A0301502"
            .FCODescription = "Food Colouring Substance - Amaranth (16185)"
            .HS_ID = "2412"
            .RStatus = 2
            .LastModifiedBy = "ADMIN"
            .LastModifiedDate = "2005-11-14 14:31:29.727"
        End With

    End Sub

    Private Function GenerateCVS(ByVal data As Object, ByVal ServiceCode As String, Optional isResponse As Boolean = False) As String

        Dim fileName As String = AgencyName & "_" & ServiceCode & "_" & Now.ToString("yyyyMMddTHHmmss") & IIf(isResponse, "_RES", "") & ".txt"

        Try
            Dim textWriter As StreamWriter = File.CreateText(fileName)
            Dim csv = New CsvHelper.CsvWriter(textWriter)
            Dim list As Object

            csv.Configuration.HasHeaderRecord = False
            csv.Configuration.QuoteAllFields = True

            If IsList(data) Then
                list = data
                If list.count = 0 Then Throw New Exception("No Data")
            Else
                list = New List(Of Object)
                list.Add(data)
            End If

            csv.WriteRecords(list)
            csv.Dispose()
            textWriter.Dispose()

            Return fileName
        Catch ex As Exception
            lstMsgs(ex.Message)
            Return Nothing
        Finally

        End Try
    End Function

#Region "Get XML Data"

    Public Function GetCA(ByVal CAData As DataExchangeClass.ConsigmentApprovalResponse, Optional ByVal AsXMLString As Boolean = True) As Object
        If AsXMLString = True Then
            Return SOAP_ENVELOPE.Replace("@DATA", CA_ENV.Replace("@DATA", CleanSerializedData(SerializeIT(CAData))))
        Else
            Return CAData
        End If
    End Function

    Public Function GetFC(Optional ByVal AsXMLString As Boolean = True) As Object
        If AsXMLString = True Then
            Return SOAP_ENVELOPE.Replace("@DATA", FC_ENV.Replace("@DATA", CleanSerializedData(SerializeIT(dummyDataFC))))
        Else
            Return dummyDataFC
        End If
    End Function

#End Region

    Sub SOAPCall(ByVal Type As String, ByVal XMLPath As String)
        Dim objHTTP As New MSXML2.XMLHTTP60
        Dim strEnvelope As String
        Dim strReturn As String
        Dim objReturn As New MSXML2.DOMDocument60
        'Dim dblTax As String
        Dim strQuery As String
        Dim cmn As New DataExchangeClass.Common

        If Microsoft.VisualBasic.Right(XMLPath, 3) = "xml" Then
            Dim k As New XmlDocument
            k.Load(XMLPath)
            strEnvelope = k.InnerXml
        Else
            strEnvelope = XMLPath
            'strEnvelope = strEnvelope.Replace("@LOGIN", LOGIN).Replace("@PWD", PWD)
            lstMsgs("Sending: " & vbCrLf & strEnvelope)
            cmn.log("Logs", "Sending: " & vbCrLf & strEnvelope)
        End If

        'Set up to post to our local server
        objHTTP.open("post", WEB_SERVICE_ASMX_URL, False)
        'objHTTP.open("post", WEB_SERVICE_ASMX_URL, False, LOGIN, PWD)

        'Set a standard SOAP/ XML header for the content-type
        objHTTP.setRequestHeader("Content-Type", "text/xml")

        'Set a header for the method to be called
        'objHTTP.setRequestHeader("SOAPAction", _
        '"urn:localhost/soap:ItramasTMCWS#MSG_AlarmData")

        'Make the SOAP call
        objHTTP.send(strEnvelope)

        'Get the return envelope
        strReturn = objHTTP.responseText

        'If TESTMODE = True Then
        '    MsgBox(strReturn)
        '    Exit Sub
        'End If

        'Load the return envelope into a DOM
        objReturn.loadXML(strReturn)

        'Query the return envelope
        Select Case Type
            Case "CADATA"
                strQuery = "soap:Envelope/soap:Body/MSG_AlarmDataResponse/MSG_AlarmDataResult"
            Case "FCDATA"
                strQuery = "soap:Envelope/soap:Body/getDataResponse/getDataResult"
            Case Else
                strQuery = Nothing
        End Select

        'lstMsgs(objReturn.text)
        lstMsgs("Response:" & vbCrLf & strReturn)
        cmn.log("Logs", "Response:" & vbCrLf & strReturn)

        'SUCCESS POST WILL BE UPDATED INTO DATABASE TABLE

        'Try
        '    If Not strQuery = Nothing Then
        '        'dblTax = objReturn.selectSingleNode(strQuery).text
        '        'Select Case dblTax
        '        '    Case ResponseStatus.AUTHOTHIZE_FAIL
        '        '        lstMsgs(Type & " process: AUTHORIZATION FAIL")
        '        '    Case ResponseStatus.VALIDATE_DATA_FAIL
        '        '        lstMsgs(Type & " process: DATA VALIDATION FAIL")
        '        '    Case ResponseStatus.PROCESS_DATA_FAIL
        '        '        lstMsgs(Type & " process: DATA PROCESSING FAIL")
        '        '    Case ResponseStatus.SUCCESS
        '        '        lstMsgs(Type & " process: SUCCESS")
        '        'End Select
        '    Else
        '        lstMsgs(Type & ": Error retrive result!")
        '    End If
        'Catch ex As Exception
        '    lstMsgs(ex.Message)
        '    'Dim objRtrn As New XmlDocument
        '    'objRtrn.LoadXml(strReturn)
        '    'Dim XQuery As XmlNode = objReturn.documentElement
        '    'lstMsgs(XQuery.InnerText)
        'End Try

    End Sub

End Class
