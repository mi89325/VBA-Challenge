Sub ABC()
   Dim WS As Worksheet
       For Each WS In ActiveWorkbook.Worksheets
       WS.Activate
       LastRow = WS.Cells(Rows.Count, 1).End(xlUp).Row
   Range("I1").Value = "Ticker"
   Range("J1").Value = "Yearly Change"
   Range("K1").Value = "Percent Change"
   Range("L1").Value = "Total Stock Volume"
   Dim Open_Price As Double
   Dim Close_Price As Double
   Dim Yearly_Change As Double
   Dim Ticker_Name As String
   Dim Percent_Change As Double
   Dim Volume As Double
   Volume = 0
   Dim Row As Double
   Row = 2
   Dim Column As Integer
   Column = 1
   Dim i As Long
   Cells(2, Column + 2).Value = Open_Price
   For i = 2 To LastRow
   If Cells(i + 1, Column).Value <> Cells(i, Column).Value Then
   Ticker_Name = Cells(i, Column).Value
   Cells(Row, Column + 8).Value = Ticker_Name
   Close_Price = Cells(i, Column + 5).Value
   Yearly_Change = Close_Price - Open_Price
   Cells(Row, Column + 9).Value = Yearly_Change
   If (Open_Price = 0 And Close_Price = 0) Then
       Percent_Change = 0
   ElseIf (Open_Price = 0 And Close_Price <> 0) Then
       Percent_Change = 1
   Else
       Percent_Change = Yearly_Change / Open_Price
       Cells(Row, Column + 10).Value = Percent_Change
       Cells(Row, Column + 10).NumberFormat = "0.00%"
   End If
       Volume = Volume + Cells(i, Column + 6).Value
       Cells(Row, Column + 11).Value = Volume
       Row = Row + 1
   Open_Price = Cells(i + 1, Column + 2)
       Volume = 1
   Else
       Volume = Volume + Cells(i, Column + 6).Value
   End If
Next i
Yearly_ChangeLastRow = WS.Cells(Rows.Count, Column + 8).End(xlUp).Row
   For j = 2 To Yearly_ChangeLastRow
       If (Cells(j, Column + 9).Value > 0 Or Cells(j, Column + 9).Value = 0) Then
       Cells(j, Column + 9).Interior.Color = vbGreen
       ElseIf Cells(j, Column + 9).Value < 0 Then
       Cells(j, Column + 9).Interior.Color = vbRed
   End If
   Next j
   Next WS
End Sub