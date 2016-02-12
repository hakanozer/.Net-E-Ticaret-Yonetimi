<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="ureticiler.aspx.cs" Inherits="WebProje.admin.ureticiler" %>

<%@ Import Namespace="WebProje.admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            padding: 15px;
            height: 136px;
            width: 739px;
        }
        .auto-style2 {
            width: 154px;
        }
        .auto-style3 {
            width: 277px;
        }
        .auto-style5 {
            width: 165px;
        }
        .auto-style6 {
            width: 243px;
        }
        .auto-style7 {
            margin-right: -15px;
            margin-left: -15px;
            width: 1095px;
            height: 999px;
        }
        .auto-style8 {
            padding-right: 15px;
            padding-left: 15px;
            margin-right: 23px;
            width: 1160px;
            height: 1004px;
        }
    </style>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Content -->
    <div id="page-wrapper">
        <div class="auto-style8";width:1038; height:800px">
            <div class="auto-style7";width:1038; height:700px">
                <div class="col-lg-12">

                    <h1 class="page-header">Üreticiler</h1>
                </div>
                <div class="form-group">
                    <label>&nbsp;&nbsp;&nbsp;&nbsp; Üretici Adı</label>
                    <br />
                    <asp:TextBox ID="TextBox2" runat="server" Width="161px"></asp:TextBox>

                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Lütfen Üretici Adını Giriniz." Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>


                <div class="form-group">
                    &nbsp;&nbsp;
                <label>&nbsp; Logo Adı</label>
                    <asp:FileUpload ID="FileUpload1" runat="server" ForeColor="Red" />
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Lütfen Logo Seçiniz." Font-Bold="True" ForeColor="Red"></asp:RequiredFieldValidator>
                    <br />

                </div>


                &nbsp;<asp:Button class="btn btn-success" ID="Button1" runat="server" Text="Kaydet" OnClick="Button1_Click" Height="35px" Width="97px" />
                &nbsp;<br />
                <br />

                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Book Antiqua" Font-Size="Large" ForeColor="Red" Text="Üreticiler Listesi"></asp:Label>

                <br />



                                <div class="auto-style1">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-hover" style="width: 100%; height: 56px">
                                    <thead>
                                        <tr>
                                            <th>Üretici ID</th>
                                            <th class="auto-style5">Üretici Adı</th>
                                            <th class="auto-style3">Üretici Logosu</th>
                                            <th class="auto-style6">Tarih</th>
                                            <th class="auto-style2">Sil</th>
                                        </tr>
                                    </thead>
                                    <tbody>

<% 
    foreach (pUreticiler item in lst) { 
       
       
       %>
                                        <tr>
                                            <td><%=item.UreticiID %></td>
                                            <td class="auto-style5"><%=item.UreticiAdi %></td>
<td class="auto-style3"> 
    <a href="ureticiLogolari.aspx?ureticiID=<%=item.UreticiID%>&ureticiAdi=<%=item.UreticiAdi%>&logoAdi=<%=item.LogoAdi %>">
       <img src="../resimler/<%=item.LogoAdi %>" width="60" />

    </a></td>
                                            <td class="auto-style6"><%=item.Tarih %></td>

                                             <td class="auto-style2">
                                            <a href="ureticiler.aspx?ureticiID=<%=item.UreticiID%>" >Üretici Sil</a>
                                          
                                        </tr>
                                        <% } %>
                                       
                                          
                                    </tbody>
                                </table>
                            </div>
                            <br />
                            &nbsp;<!-- /.table-responsive --></div>




            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /#page-wrapper -->
    </div>

</asp:Content>
