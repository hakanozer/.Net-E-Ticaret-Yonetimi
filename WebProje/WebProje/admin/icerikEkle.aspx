<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="icerikEkle.aspx.cs" Inherits="WebProje.admin.icerikEkle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                     <br />
                    <a href="icerikler.aspx" class="btn btn-success" style="float: right;"> << Geri Git</a>
                     <br />
                     <br />
                     <br />
                     <br />
               <div class="panel panel-primary" style="width: 75%; margin: 0 auto; margin-bottom: 50px">

            <div class="panel-heading" style="width: 75%; margin: 0 auto; margin-bottom: 50px">
                <h4 class="panel-title text-center" style="font-size: xx-large">&nbsp;Yeni İçerik Ekleme</h4>
            </div>

           

                <p class="text-center" style="font-size: large; font-family: Tahoma; font-weight: bold; color: #0000FF; font-style: italic;">İçerik bilgilerinizi aşağıda girebilirsiniz.</p>
                <hr>
                    <!-- Başlık -->
                <div class="form-group">
                <label>&nbsp;&nbsp;&nbsp;&nbsp; Başlık</label>
                <asp:TextBox class="form-control" ID="baslik" runat="server" Width="400px"></asp:TextBox>
                </div>
                    
                    <!-- Kısa Açıklama -->
                 <div class="form-group">
                <label>&nbsp;&nbsp;&nbsp;&nbsp; Kısa Açıklama</label>
                <asp:TextBox class="form-control" ID="kisaAciklama" runat="server" Width="400px"></asp:TextBox>
                </div>

                 <div class="form-group">
                <label>&nbsp;&nbsp;&nbsp; Detay</label>
                <CKEditor:CKEditorControl ID="detay" runat="server"></CKEditor:CKEditorControl>
                 </div>

                <div class="form-group">
                    <br />
                <asp:Button class="btn btn-success" ID="btnKaydet" runat="server" Text="Kaydet" OnClick="btnKaydet_Click" Width="182px" />
            </div>

           

            </div>
            </div>
            <!-- /.row -->
            <div class="form-group">
            </div>
            </div>

        </div>
        <!-- /.container-fluid -->
    </div>
    <!-- /#page-wrapper -->



</asp:Content>
