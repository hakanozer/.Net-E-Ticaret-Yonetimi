<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="SiparisUrunleri.aspx.cs" Inherits="WebProje.admin.SiparisUrunleri" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Sepet</h1>
                </div>
            </div>
            <!-- /.row -->

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Sepet Ürünleri
                       
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="dataTable_wrapper">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">

                                    <thead>
                                        <tr>
                                            <th>Ürün ID</th>
                                            <th>Ürün Adı</th>
                                            <th>Açıklama</th>
                                            <th>Fiyat</th>
                                            <th>Piyasa Fiyatı</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <asp:Repeater ID="rpSiparisUrunleriListesi" runat="server">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td><%#Eval("urunID") %></td>
                                                    <td><%#Eval("urunAdi") %></td>
                                                    <td><%#Eval("kisaAciklama") %></td>
                                                    <td><%#Eval("fiyat") %></td>
                                                    <td><%#Eval("piyasaFiyat") %></td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>

                                </table>
                            </div>
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->

            <div class="form-group">
                <label>Müşteri Bilgileri</label>
                <br />
                <asp:Label ID="lblMusteri" runat="server" Text="Label"></asp:Label>

            </div>


            <div class="form-group">
                <label>Sepetin Toplam Tutarı</label>
                <br />
                <asp:Label ID="lblTutar" runat="server" Text="Label"></asp:Label>
            </div>

             <div class="form-group">
                <label>Piyasa Fiyatları Toplam Tutarı</label>
                <br />
                <asp:Label ID="lblPiyasaTutar" runat="server" Text="Label"></asp:Label>
            </div>
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->
</asp:Content>
