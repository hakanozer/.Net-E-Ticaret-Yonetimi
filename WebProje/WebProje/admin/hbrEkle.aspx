<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="hbrEkle.aspx.cs" Inherits="WebProje.admin.hbrEkle" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Boş Sayfa</h1>
                </div>
            </div>
            <!-- /.row -->
            <div class="form-group">
                <label>Kategori Seç</label>
                <asp:DropDownList  class="form-control" ID="DropDownList1" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Haber Başlığı</label>
                <asp:TextBox class="form-control" ID="txthbrBaslik" runat="server"></asp:TextBox>
            </div>


            <div class="form-group">
                <label>Kısa Açıklama</label>
                <asp:TextBox class="form-control" ID="kisaAciklama" runat="server"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label>İçerik</label>
                <CKEditor:CKEditorControl ID="txtIcerik" runat="server"></CKEditor:CKEditorControl>
            </div>

            <div class="form-group">
                <label>Durum</label>
                <asp:DropDownList class="form-control" ID="DropDownList2" runat="server">
                    <asp:ListItem Value="0">Aktif</asp:ListItem>
                    <asp:ListItem Value="1">Pasif</asp:ListItem>
                </asp:DropDownList>
            </div>

             <div class="form-group">
                <label>Resim</label>
                <asp:FileUpload ID="fluDosya" runat="server" />
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fluDosya" ErrorMessage="Lütfen Resim Seçiniz" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <asp:Button class="btn btn-success" ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" />
            </div>

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->

</asp:Content>
