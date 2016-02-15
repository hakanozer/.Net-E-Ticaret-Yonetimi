<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="yerlesimDuzenle.aspx.cs" Inherits="WebProje.admin.yerlesimDuzenle" %>
<%@ Import Namespace="WebProje.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <!-- Page Content -->
        <div id="page-wrapper">
            <div class="container-fluid">
                <div class="row">
                <div class="col-lg-12">
                        <a href="mansetEkle.aspx" class="btn btn-outline btn-success" style="float:right;">Yeni Ekle</a>
                     <h1 class="page-header">Yerleşim Düzeni</h1>
                </div>
            </div>
            <!-- /.row -->

                <div class="panel-body">
                            <div class="table-responsive">
                                <table id="tblGrid" class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                        <td>Sayi</td>
                                        <td>Türkçe Başlık</td>
                                        <td>Manşet Haber</td>
                                        <td>Manşet Alt</td>
                                        <td>Son Haber</td>
                                        <td>Düzenle</td>
                                        <td>Sil</td>
                                        </tr>
                                    </thead>
                                    <tbody>
    
                            <% 
                                foreach(pYerlesimDuzenle item in lsy1) {    
                            %>

                                        <tr class="odd gradeX">
                                            <td><%=item.YerlesimID %></td>
                                            <td><%=item.Baslik %></td>
                                            <td><a href="yerlesimDuzenle.aspx?mansetsecID1=<%=item.YerlesimID %>&olayTuru1=<%=item.OlayTuru %>&olayAdi1=<%=item.OlayAdi %>"><img src="<%=item.Manset_yap %>"/></a></td>
                                            <td><a href="yerlesimDuzenle.aspx?mansetsecID2=<%=item.YerlesimID %>&olayTuru2=<%=item.OlayTuru %>&olayAdi2=<%=item.OlayAdi %>"><img src="<%=item.Manset_alt %>"/></a></td>
                                            <td><a href="yerlesimDuzenle.aspx?mansetsecID3=<%=item.YerlesimID %>&olayTuru3=<%=item.OlayTuru %>&olayAdi3=<%=item.OlayAdi %>"><img src="<%=item.Sonhaber %>"/></a></td>                                           
                                            <td><a href="mansetDuzenle.aspx?yerlesimID=<%=item.YerlesimID %>" class="btn btn-outline btn-warning">Düzenle</a></td>
                                            <td><a href="yerlesimDuzenle.aspx?silID=<%=item.YerlesimID %>" class="btn btn-outline btn-danger">Sil</a></td>
                                        </tr>
                            <%} %>
                                
                                     </tbody>
                                </table>
                            </div>
                            <!-- /.table-responsive -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-6 -->
                
</asp:Content>
