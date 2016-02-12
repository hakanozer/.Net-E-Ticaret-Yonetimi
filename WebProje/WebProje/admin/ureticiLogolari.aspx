<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="ureticiLogolari.aspx.cs" Inherits="WebProje.admin.ureticiLogolari" %>

<%@ Import Namespace="WebProje.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style2 {
            width: 257px;
        }
        .auto-style4 {
            width: 357px
        }
        .auto-style7 {
            width: 615px
        }
        .auto-style8 {
            width: 99px;
        }
        .auto-style12 {
            width: 340px
        }
        .auto-style13 {
            width: 719px
        }
        .auto-style14 {
            width: 2115px
        }
        .auto-style16 {
            padding: 15px;
            height: 197px;
            width: 970px;
            margin-top: 19px;
        }
        .auto-style17 {
            padding: 15px;
            height: 168px;
            width: 963px;
            margin-left: 0px;
        }
        .auto-style18 {
            width: 576px
        }
        .auto-style19 {
            width: 99px;
            height: 60px;
        }
        .auto-style20 {
            width: 340px;
            height: 60px;
        }
        .auto-style21 {
            width: 719px;
            height: 60px;
        }
        .auto-style22 {
            width: 576px;
            height: 60px;
        }
        .auto-style23 {
            padding: 10px 15px;
            border-bottom: 1px solid transparent;
            border-top-left-radius: 3px;
            border-top-right-radius: 3px;
            width: 970px;
            height: 19px;
        }
        .auto-style24 {
            margin-right: -15px;
            margin-left: 0px;
            width: 1231px;
            height: 769px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Üretici Logoları Yönetimi</h1>
                </div>
            </div>
            <!-- /.row -->
            <div class="auto-style24">
                <%--<div class="auto-style15">--%>
                    <div class="panel panel-default" style="width: 1016px; height: 498px">
                        <div class="auto-style23">
                            Üretici Logoları
                        </div>
                        <!-- /.panel-heading -->
                        <div class="auto-style17">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" style="width: 69%; height: 110px">
                                    <thead>
                                        <tr>
                                            <th class="auto-style2">Üretici ID</th>
                                            <th class="auto-style4">Üretici Adı</th>
                                            <th class="auto-style7">Üretici Logosu</th>
                                            <th class="auto-style14">Tarih</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <% foreach (pUreticiler item in logoList)
                                           {%>
                                        <tr>
                                            <td class="auto-style2"><%=item.UreticiID %></td>
                                            <td class="auto-style4">
                                                <asp:TextBox placeholder="adini girin" ID="adi" runat="server"></asp:TextBox></td>
                                            <td class="auto-style7">
                                                <asp:FileUpload ID="fluDosyaLogo" runat="server" Width="193px" /></td>
                                            <td class="auto-style14"><%=item.Tarih %></td>                                          
                                        </tr>

                                        <% } %>
                                    </tbody>
                                </table>
                            </div>
                            <asp:Button ID="btnYukle" runat="server" Text="Güncelle" OnClick="btnYukle_Click" class="btn btn-success" ForeColor="White" Height="30px" Width="123px" />
                            &nbsp;
                    <%--<a href="ureticiler.aspx" class="btn btn-success" style="float:left;">Yeni Ekle</a><br />--%>
                            &nbsp;<!-- /.table-responsive -->
                        </div>

                        
             
                        <!-- /.panel-body -->

                        
             
                        <div class="auto-style16">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" style="width: 69%; height: 89px">
                                    <thead>
                                        <tr>
                                            <th class="auto-style8">Üretici ID</th>
                                            <th class="auto-style12">Üretici Adı</th>
                                            <th class="auto-style13">Üretici Logosu</th>
                                            <th class="auto-style18">Tarih</th>
                                        </tr>
                                    </thead>
                                    <tbody>

                                        <% 
                                            foreach (pUreticiler item in logoList)
                                            {
                                        %>
                                        <tr>
                                            <td class="auto-style19"><%=item.UreticiID %></td>
                                            <td class="auto-style20"><%=item.UreticiAdi %></td>
                                            <td class="auto-style21">
                                                <img src="../resimler/<%=item.LogoAdi %>" width="60" />
                                            </td>
                                            <td class="auto-style22"><%=item.Tarih %></td>

                                        </tr>
                                        <% } %>
                                    </tbody>
                                </table><a href="ureticiler.aspx" class="btn btn-success" style="float: left; height: 27px; width: 124px;">Üreticiler Sayfası</a>
                            </div>
                            <br />
                            
                            <!-- /.table-responsive -->
                        </div>
                    </div>
                     </div>
                 </div>
                </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-6 -->

                <!-- /.col-lg-6 -->
         
    <!-- /#page-wrapper -->
</asp:Content>
