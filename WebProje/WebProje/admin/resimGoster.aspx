<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="resimGoster.aspx.cs" Inherits="SemaDincer_GalleryManagement.resimGoster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-md-6">
                    <div class="panel panel-primary" style="width: 430px">
                        <div class="panel-heading">
                            <h4 class="panel-title text-center">Resim Düzenle</h4>
                        </div>
                        <div class="panel-body">
                            <script>
                                function action_degistir() {
                                    var galeriId = document.getElementById('galeriId').value;
                                    document.getElementById('myform').action = "?link=galeri&albumId=" + galeriId + "&resimId=93";
                                }
                            </script>
                            <form class="form-horizontal" id="myform" action="?link=galeri&amp;albumId=21&amp;resimId=93" method="post">
                                <img src="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcS-zGVTK4tH3nW_6zzrQkeNjnC5m74jNoPPkEkVI8EKwQW-9ZqC" alt="...">
                                <hr>
                                <div class="form-group">
                                    <div class="col-md-5">
                                        <label for="galeriId">Bulunduğu Galeri</label>
                                    </div>
                                    <div class="col-md-7">
                                        <select name="galeriId" class="form-control" id="galeriId" onchange="action_degistir();">
                                            <option value="21" selected="">Galeri Demo</option>
                                            <option value="24">yasemin</option>
                                            <option value="34">Metin</option>
                                            <option value="44">aaa</option>
                                            <option value="45">ss</option>
                                            <option value="46">aa</option>
                                        </select>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-5">
                                        <label for="alt">Resim Açıklaması</label>
                                    </div>
                                    <div class="col-md-7">
                                        <input type="text" name="alt" value="asd" class="form-control">
                                    </div>
                                </div>
                                <div class="form-group">

                                    <div class="col-md-7 col-md-offset-5">
                                        <input type="submit" name="sil" value="Sil" class="btn btn-danger">
                                        <input type="submit" name="kaydet" value="Kaydet" class="btn btn-primary">
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>


    </div>

    


</asp:Content>
