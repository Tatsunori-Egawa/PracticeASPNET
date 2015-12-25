<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ErrorLinkList.ascx.cs" Inherits="WebApplication2.Components.ErrorLinkList" %>
<asp:Repeater ID="LinkList_Error" runat="server">
    <HeaderTemplate><ul class="__ERRORLIST__"><li>エラー<ul></HeaderTemplate>
    <ItemTemplate><li><%# Container.DataItem %></li></ItemTemplate>
    <FooterTemplate></ul></li></ul></FooterTemplate>
</asp:Repeater>
<asp:Repeater ID="LinkList_Warning" runat="server">
    <HeaderTemplate><ul class="__WARNINGLIST__"><li>警告<ul></HeaderTemplate>
    <ItemTemplate><li><%# Container.DataItem %></li></ItemTemplate>
    <FooterTemplate></ul></li></ul></FooterTemplate>
</asp:Repeater>

