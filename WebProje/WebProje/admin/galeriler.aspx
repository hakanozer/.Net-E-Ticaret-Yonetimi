<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="galeriler.aspx.cs" Inherits="SemaDincer_GalleryManagement.admin.galeriler" %>

<%@ Import Namespace="SemaDincer_GalleryManagement.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <div class="row">
                        <% foreach (classGaleri item in ls)
                            { %>
                        <div class="col-md-6 thumb cf">
                            <a href="galeriGoster.aspx?galeriID=<%=item.GaleriID %>" class="thumbnail">
                                <img src="https://camo.githubusercontent.com/f8ea5eab7494f955e90f60abc1d13f2ce2c2e540/68747470733a2f2f662e636c6f75642e6769746875622e636f6d2f6173736574732f323037383234352f3235393331332f35653833313336322d386362612d313165322d383435332d6536626439353663383961342e706e67" alt="...">
                            </a>
                            <div class="info cf">
                                <div class="text pull-left">
                                    <a href="galeriGoster.aspx?galeriID=<%=item.GaleriID %>">
                                        <%=item.GaleriAdi%>
                                    </a>
                                </div>
                                <div class="delete pull-right">
                                    <a href="galeriSil.aspx?galeriID=<%=item.GaleriID%>">
                                        <i class="fa fa-trash-o"></i>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <% } %>
                    </div>
                </div>



                <div class="col-md-6">
                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">Yeni Galeri Oluştur</h4>
                        </div>

                        <div class="panel-body">

                            <div class="form-horizontal">

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <input type="text" name="galeriAdi" class="form-control" placeholder="Galerinin Adı">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <input type="text" name="galeriAciklama" class="form-control" placeholder="Galeri Açıklaması">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12">

                                        <div class="radio">
                                            <label>
                                                <input type="radio" name="aktif" value="1" checked="">Aktif</label>
                                        </div>

                                        <div class="radio">
                                            <label>
                                                <input type="radio" name="aktif" value="0">Pasif</label>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnGaleriOlustur" runat="server" class="btn btn-primary" Text="Galeri Oluştur" OnClick="btnGaleriOlustur_Click" />
                                    </div>
                                </div>


                            </div>


                        </div>
                        <!-- /.container-fluid -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /#page-wrapper -->
    </a>
</asp:Content>
