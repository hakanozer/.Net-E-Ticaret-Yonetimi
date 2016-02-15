<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="mansetDuzenle.aspx.cs" Inherits="WebProje.admin.mansetDuzenle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <a href="yerlesimDuzenle.aspx" class="btn btn-success" style="float: right;">Geri</a>
                    <h1 class="page-header">Yeni Manşet Ekle</h1>
                </div>
            </div>
            <!-- /.row -->
             <div class="form-group">
                <label>Baslik</label>
                <asp:TextBox class="form-control" ID="txtBaslik" runat="server"></asp:TextBox>
            </div>


            <div class="form-group">
                <label>Resim Seç</label>
                <asp:TextBox class="form-control" ID="txtResimAdi" runat="server"></asp:TextBox>
                <asp:FileUpload ID="fluDosya" runat="server" />
            </div>


            <div class="form-group">
                <label>Aciklama</label>
                <CKEditor:CKEditorControl ID="txtAciklama" runat="server"></CKEditor:CKEditorControl>
            </div>


            <div class="form-group">
                <asp:Button class="btn btn-success"  ID="btnDuzenle" runat="server" Text="Düzenle" OnClick="btnDuzenle_Click" />
            </div>

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->

</asp:Content>
