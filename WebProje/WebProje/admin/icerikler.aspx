<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="icerikler.aspx.cs" Inherits="WebProje.admin.icerikler" %>

<%@ Import Namespace="WebProje.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    &nbsp;&nbsp;&nbsp;
                    <h1 class="page-header">İçerik Yönetimi</h1>


                </div>
               
                <a href="icerikEkle.aspx" class="btn btn-success" style="float: left;">Yeni Ekle>></a><br />
&nbsp;</div>
            <br />

            <!-- DataTables CSS -->
            <%-- <link href="../bower_components/datatables-plugins/integration/bootstrap/3/dataTables.bootstrap.css" rel="stylesheet">

    <!-- DataTables Responsive CSS -->
    <link href="../bower_components/datatables-responsive/css/dataTables.responsive.css" rel="stylesheet">--%>

            <!-- /.row -->

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                           <b> İçerik Listesi</b>
                       
                        </div>
                        <!-- /.panel-heading -->
                       
                                    <br />
                        <div class="panel-body">
                            <div class="table-responsive">
                        <center style="color: #FF0000; font-family: Arial"><asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="icerikID" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display." Height="150px" Width="966px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <Columns>
                                <asp:BoundField DataField="icerikID" HeaderText="İçerik ID" ReadOnly="True" SortExpression="icerikID" >
                                <ControlStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="baslik" HeaderText="Başlık" SortExpression="baslik" >
                                <ControlStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="kisaAciklama" HeaderText="Kısa Açıklama" SortExpression="kisaAciklama" >
                                <ControlStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="detay" HeaderText="Detay" SortExpression="detay" >
                                <ControlStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:BoundField DataField="eklenmeTarihi" HeaderText="Eklenme Tarihi" SortExpression="eklenmeTarihi" >
                                <ControlStyle Font-Bold="True" />
                                </asp:BoundField>
                                <asp:CommandField CancelText="İptal" DeleteText="     Sil" EditText="Düzenle" HeaderText="İşlem" InsertText="Ekle" NewText="Yeni" SelectText="" ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" UpdateText="Güncelle" > 
                                <ControlStyle Font-Bold="True" Font-Underline="True" ForeColor="Red" />
                                    
                                </asp:CommandField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView></center></div></div>

                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:webProjeConnectionString %>" DeleteCommand="DELETE FROM [icerikYonetimi] WHERE [icerikID] = @icerikID" InsertCommand="INSERT INTO [icerikYonetimi] ([baslik], [kisaAciklama], [detay], [eklenmeTarihi]) VALUES (@baslik, @kisaAciklama, @detay, @eklenmeTarihi)" ProviderName="<%$ ConnectionStrings:webProjeConnectionString.ProviderName %>" SelectCommand="SELECT [icerikID], [baslik], [kisaAciklama], [detay], [eklenmeTarihi] FROM [icerikYonetimi]" UpdateCommand="UPDATE [icerikYonetimi] SET [baslik] = @baslik, [kisaAciklama] = @kisaAciklama, [detay] = @detay, [eklenmeTarihi] = @eklenmeTarihi WHERE [icerikID] = @icerikID">
                            <DeleteParameters>
                                <asp:Parameter Name="icerikID" Type="Int32" />
                            </DeleteParameters>
                            <InsertParameters>
                                <asp:Parameter Name="durum" Type="Int32" />
                                <asp:Parameter Name="baslik" Type="String" />
                                <asp:Parameter Name="kisaAciklama" Type="String" />
                                <asp:Parameter Name="detay" Type="String" />
                                <asp:Parameter Name="eklenmeTarihi" Type="DateTime" />
                            </InsertParameters>
                            <UpdateParameters>
                                <asp:Parameter Name="durum" Type="Int32" />
                                <asp:Parameter Name="baslik" Type="String" />
                                <asp:Parameter Name="kisaAciklama" Type="String" />
                                <asp:Parameter Name="detay" Type="String" />
                                <asp:Parameter Name="eklenmeTarihi" Type="DateTime" />
                                <asp:Parameter Name="icerikID" Type="Int32" />
                            </UpdateParameters>
                        </asp:SqlDataSource>
                       

                                    <hr />


                              
        <!-- /.panel-body -->
        </div>
                    <!-- /.panel -->
        </div>
                <!-- /.col-lg-12 -->
        </div>
            <!-- /.row -->
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->



</asp:Content>
