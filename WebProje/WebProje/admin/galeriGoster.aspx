<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="galeriGoster.aspx.cs" Inherits="SemaDincer_GalleryManagement.admin.galeriGoster" EnableEventValidation="false" ValidateRequest="false" %>

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
                        <% foreach (classResim item in lst)
                            { %>
                        <div class="col-md-6 thumb cf">
                            <a href="galeriGoster.aspx?galeriID=<%=item.RgaleriID%>&resimID=<%=item.ResimID%>" class="thumbnail">
                                <img src="../resimler/<%=item.Resim%>" />

                            </a>
                            <div class="info cf">
                                <div class="text pull-left">
                                    <a><%=item.ResimAdi%></a>
                                </div>
                                <div class="delete pull-right">
                                    <a href="resimSil.aspx?galeriID=<%=item.RgaleriID%>&resimID=<%=item.ResimID%>">
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
                            <h4 class="panel-title">Galeriye Resim Ekle</h4>
                        </div>
                        <div class="panel-body">


                            <form id="resimEkle" class="form-horizontal" action="?link=galeri&amp;islem=ekle&amp;albumId=34" method="post" enctype="multipart/form-data">

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <%--<input type="text" id="aciklama" name="alt" class="form-control" placeholder="Resim yazısı (alt)..">--%>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Button class="btn btn-primary" ID="btnResimEkle" runat="server" Text="Ekle" OnClick="btnResimEkle_Click" />
                                    </div>
                                </div>
                            </form>


                            <div class="alert alert-warning" role="alert">
                                <ul>
                                    <li>Yüklenecek resmin genişliği veya yüksekliği <b>400px</b>'den küçük olamaz..</li>
                                    <li>Resmin boyutu <b>2MB</b>'tan büyük olamaz</li>
                                    <li>İzin verilen türler : <b>jpg, jpeg, png</b></li>
                                </ul>
                            </div>
                        </div>
                    </div>


                    <div class="panel panel-primary">
                        <div class="panel-heading">
                            <h4 class="panel-title">Galeriyi Düzenle</h4>
                        </div>
                        <div class="panel-body">


                            <form class="form-horizontal" action="?link=galeri&amp;albumId=34&amp;islem=galeriDuzenle" method="post">
                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtYeniGaleriAdi" Enabled="true" placeholder="galeri adı" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:TextBox ID="txtYeniAciklama" Enabled="true" placeholder="yeni açıklama" class="form-control" runat="server"></asp:TextBox>
                                    </div>
                                </div>

                                

                                <div class="form-group">
                                    <div class="col-md-12">
                                        <asp:Button ID="btnDuzenle" class="btn btn-primary" runat="server" Text="Düzenle" OnClick="btnDuzenle_Click" />
                                    </div>
                                </div>

                            </form>
                        </div>
                    </div>



                </div>
            </div>




        </div>
    </div>

    <!-- /#page-wrapper -->
</asp:Content>
