<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="Siparisler.aspx.cs" Inherits="WebProje.admin.Siparisler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Siparisler</h1>
                </div>
            </div>
            <!-- /.row -->

            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            Siparis Listesi
                       
                        </div>
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="dataTable_wrapper">
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                            <th>Sipariş ID</th>
                                            <th>Müşteri</th>
                                            <th>Ürünler</th>
                                            <th>Tutar</th>
                                            <th>Detay</th>
                                            <th>Adres</th>
                                            <th>Tarih</th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        <asp:Repeater ID="rpSiparisListesi" runat="server">
                                            <ItemTemplate>
                                                <tr class="odd gradeX">
                                                    <td><%#Eval("siparisID") %></td>
                                                    <td><%#Eval("mail") %></td>
                                                    <td>
                                                        <a href="SiparisUrunleri.aspx?siparisID=<%#Eval("siparisID") %>&musteriID=<%#Eval("musteriID")%>" title="sepete git">
                                                            <img src="images/bak.png" alt="" width="40" /></a></td>
                                                    <td><%#Eval("tutar") %></td>
                                                    <td><%#Eval("detay") %></td>
                                                    <td><%#Eval("adres") %></td>
                                                    <td><%#Eval("tarih") %></td>
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
        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->

</asp:Content>
