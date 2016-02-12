<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="haberler.aspx.cs" Inherits="WebProje.admin.haberler" %>

<%@ Import Namespace="WebProje.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Haber Yönetimi</h1>
                </div>

            </div>
            <!-- /.row -->
            <div class="form-group">
                <a href="hbrEkle.aspx" class="btn btn-success" id="btnKaydet">Haber Ekle</a>
            </div>

            <hr />

            <div class="form-group col-md-4">
                <asp:DropDownList ID="DropDownList1" runat="server" class="form-control">
                    <asp:ListItem Value="0">Bütün Kategoriler</asp:ListItem>
                </asp:DropDownList> 
            </div>
            <div class="form-group col-md-2">
                <asp:DropDownList ID="DropDownList2" runat="server" class="form-control">
                    <asp:ListItem Value="3">Hepsi</asp:ListItem>
                    <asp:ListItem Value="0">Aktif</asp:ListItem>
                    <asp:ListItem Value="1">Pasif</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group col-md-1">
                <asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Filtrele" OnClick="Button1_Click1" />
            </div>

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Haber Listesi                       
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="dataTable_wrapper">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                            <th>haberID</th>
                                            <th>haberKategoriId</th>
                                            <th>urunAcıklama</th>
                                            <th>hbrIcerik</th>
                                            <th>resimAdi</th>
                                            <th>durum</th>
                                            <th>tarih</th>
                                            <th>Sil</th>
                                            <th>Düzenle</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <% 
                                            foreach (pHaberler item in hbrLs)
                                            {
                                        %>
                                        <tr class="odd gradeX">
                                            <td><%=item.HbrID %></td>
                                            <td><%=item.HbrKatId %></td>
                                            <td><%=item.HbrAciklama %></td>
                                            <td><%=item.HbrIcerik %></td>
                                            <td>
                                                <img src="../resimler/hbrResim/<%=item.HbrResim %>" width="60" />
                                            </td>
                                            <td><%if (item.HbrDurum == 0) { Response.Write("Aktif"); }
                                                    else { Response.Write("Pasif"); } %></td>
                                            <td><%=item.HbrTarih %></td>
                                            <td><a href="haberler.aspx?hbrID=<%=item.HbrID %>&hbrResim=<%=item.HbrResim %>" class="btn btn-danger btn-circle"><i class="fa fa-times"></i>
                                            </a></td>
                                            <td><a href="hbrDuzenle.aspx?hbrID=<%=item.HbrID %>" class="btn btn-primary btn-circle"><i class="fa fa-list"></i></a></td>

                                        </tr>
                                        <%} %>
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
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->

</asp:Content>
