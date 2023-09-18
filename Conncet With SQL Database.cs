Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim productid As Integer = txtproductID.Text
        Dim itemname As String = txtitemname.Text
        Dim specification As String = txtspecification.Text
        Dim unit As String = Dropunit.SelectedValue
        Dim color As String = Radiocolor.SelectedValue
        Dim insertdate As DateTime = txtdate.Text
        Dim opening As Double = txtopeningqty.Text
        Dim status As String = ""
        If Checkregular.Checked = True Then
            status = "Regular"
        Else
            status = "Irregular"
        End If
        connect.Open()
        Dim command As New SqlCommand("Insert into ProductInfo_Tab values ('" & productid & "','" & itemname & "','" & specification & "','" & unit & "','" & color & "','" & insertdate & "','" & opening & "','" & status & "')", connect)
        command.ExecuteNonQuery()
        MsgBox("Successfully Inserted", MsgBoxStyle.Information, "Message")
        connect.Close()
        ListProduct()
    End Sub

    Private Sub ListProduct()
        Dim command As New SqlCommand("select * from ProductInfo_Tab", connect)
        Dim sd As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sd.Fill(dt)
        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub
