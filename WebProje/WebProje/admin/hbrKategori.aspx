<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="hbrKategori.aspx.cs" Inherits="WebProje.admin.hbrKategori" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Haber Kategorileri</h1>
                </div>

            </div>
            <link href="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css" rel="stylesheet">

            <!-- DataTables Responsive CSS -->
            <link href="../bower_components/datatables-responsive/css/dataTables.responsive.css" rel="stylesheet">
            <!-- /.row -->

            <div class="form-group">
                <label>Kategori Adı</label>
                <asp:TextBox ID="txtHbrKtgr" class="form-control" runat="server"></asp:TextBox>
            </div>


            &nbsp;<asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Kaydet" OnClick="Button1_Click" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHbrKtgr" ErrorMessage="Lütfen Kategori Adı Giriniz" ForeColor="Red"></asp:RequiredFieldValidator>

            <hr />

            <div class="panel-body">
                            <div class="table-responsive">
            <asp:GridView  class="table table-striped table-bordered table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="adi" HeaderText="adi" SortExpression="adi" />
                    <asp:BoundField DataField="tarih" HeaderText="tarih" SortExpression="tarih" />
                </Columns>
            </asp:GridView>

            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webProjeConnectionString2 %>" DeleteCommand="DELETE FROM [hbrKategori] WHERE [ID] = @ID" InsertCommand="INSERT INTO [hbrKategori] ([adi], [tarih]) VALUES (@adi, @tarih)" SelectCommand="SELECT * FROM [hbrKategori]" UpdateCommand="UPDATE [hbrKategori] SET [adi] = @adi, [tarih] = @tarih WHERE [ID] = @ID">
                <DeleteParameters>
                    <asp:Parameter Name="ID" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="adi" Type="String" />
                    <asp:Parameter Name="tarih" Type="DateTime" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="adi" Type="String" />
                    <asp:Parameter Name="tarih" Type="DateTime" />
                    <asp:Parameter Name="ID" Type="Int32" />
                </UpdateParameters>
            </asp:SqlDataSource>
            </div></div>
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->

</asp:Content>
